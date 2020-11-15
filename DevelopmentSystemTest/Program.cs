using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using DataLayer.Entities;
using DevelopmentSystemTest.Forms.GeneralForm;
using DevelopmentSystemTest.Forms.ParkingCars;
using DevelopmentSystemTest.ThreadClasses;
using DevelopmentSystemTest.ThreadClasses.DateChanger;
using Tools.CarGenerator;
using Tools.CarNumberGenerator;
using Tools.ExportImportService;
using Tools.ExportImportService.JSON;
using Tools.Extensions;
using Tools.Factories.CarFactory;
using Tools.Factories.MakeFactory;
using Tools.Factories.ModelFactory;
using Tools.ProbabilityChanger;

namespace DevelopmentSystemTest
{
    static class Program
    {
        public readonly static WindsorContainer container;
        
        static Program()
        {
            container = new WindsorContainer();
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Bootstrap();
            StartRunnable();

            Application.Run(container.Resolve<GeneralForm>());
        }

        private static void Bootstrap()
        {
            //https://stackoverflow.com/questions/10333997/proper-class-modeling-with-uml

            //var bootstrapTypes = AppDomain.CurrentDomain.GetAssemblies()
            //    .SelectMany(assembly => assembly.GetTypes())
            //    .Where(type => typeof(IWindsorInstaller).IsAssignableFrom(type) && !type.IsInterface && !type.IsAbstract)
            //    //.Select(type => type.GetMethod("Bootstrap"))
            //    .ToArray();

            container.Register(Component.For<GeneralForm>().LifestyleTransient());
            container.Register(Component.For<ParkingCarsForm>().LifestyleTransient());

            container.Register(Component.For<IExportImportService>().ImplementedBy<JsonExportImportService>().LifestyleSingleton());

            container.Register(Component.For<IMakeFactory>().ImplementedBy<MakeFactory>().LifestyleSingleton());
            container.Register(Component.For<IModelFactory>().ImplementedBy<ModelFactory>().LifestyleSingleton());
            container.Register(Component.For<ICarNumberGenerator>().ImplementedBy<CarRuNumberGenerator>().LifestyleSingleton());
            container.Register(Component.For<ICarFactory>().ImplementedBy<CarFactory>().LifestyleSingleton());
            container.Register(Component.For<ICarGenerator>().ImplementedBy<CarGenerator>().LifestyleSingleton());
            container.Register(Component.For<IDateChanger>().ImplementedBy<DateChanger>().LifestyleSingleton());
            container.Register(Component.For<ICityProbabilityChanger>().ImplementedBy<CityProbabilityChanger>().LifestyleSingleton());

            container.Register(Component.For<Parking>().LifestyleSingleton());
            container.Register(Component.For<City>().LifestyleSingleton());
        }

        private static void StartRunnable()
        {
            var interfaceTypes = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(assembly => assembly.GetInterfacesImplementedBy<IThreadRunnable>())
                .ToArray();

            foreach(var type in interfaceTypes)
            {
                var runnableObj = container.Resolve(type) as IThreadRunnable;
                
                if(runnableObj != null)
                {
                    var newThread = new Thread(runnableObj.Run)
                    { 
                        IsBackground = true
                    };

                    newThread.Start();
                }
            }
        }
    }
}