using DataLayer.Entities;
using DevelopmentSystemTest.Forms.ParkingCars;
using DevelopmentSystemTest.ThreadClasses.DateChanger;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using Tools.ExportImportService;
using Tools.FileSaver.JSON;
using Tools.ProbabilityChanger;

namespace DevelopmentSystemTest.Forms.GeneralForm
{
    public partial class GeneralForm : Form
    {
        private readonly ICityProbabilityChanger cityProbabilityChanger;
        private readonly IDateChanger dateChanger;
        private readonly City city;
        private readonly IExportImportService exportImportService;

        public GeneralForm(
            ICityProbabilityChanger cityProbabilityChanger,
            IDateChanger dateChanger,
            City city,
            IExportImportService exportImportService)
        {
            InitializeComponent();

            this.cityProbabilityChanger = cityProbabilityChanger;
            this.dateChanger = dateChanger;
            this.city = city;
            this.exportImportService = exportImportService;

            InitTextBoxesInfo();
        }

        private void GeneralForm_Load(object sender, EventArgs e)
        {
            
            dateChanger.HourChangeNotify += cityProbabilityChanger.NewCarAction;
            dateChanger.HourChangeNotify += CarCountTextBoxUpdate;

            dateChanger.DayChangeNotify += city.SetCountNewCarsAction;
            dateChanger.DayChangeNotify += cityProbabilityChanger.CarsStatusChangeAction;
            dateChanger.DayChangeNotify += city.SetCountLookingParkingAction;
            dateChanger.DayChangeNotify += UpdateParkingInfo;

            dateChanger.MonthChangeNotify += cityProbabilityChanger.CarsUtilizationAction;
            dateChanger.MonthChangeNotify += city.SetCountUtilizedCarsAction;
            dateChanger.MonthChangeNotify += UpdateMonthInfo;
        }

        private void GeneralForm_Closing(object sender, EventArgs e)
        {
            Program.container.Release(this);
        }

        private void Pause_Click(object sender, EventArgs e)
        {
            dateChanger.WaitHandle.Reset();
        }

        private void Start_Click(object sender, EventArgs e)
        {
            dateChanger.WaitHandle.Set();
        }

        private void ShowParkingCarsForm_Click(object sender, EventArgs e)
        {
            Program.container.Resolve<ParkingCarsForm>().Show();
        }

        private async void Export_Click(object sender, EventArgs e)
        {
            var saveData = new ProjectInfoDto
            {
                Cars = city.Cars,
                ParkingCars = city.Parking.Cars,
                ParkingCapacity = city.Parking.Capacity,
                LookingParkingCars = city.LookingParkingCarsCount,
                NewCarsPerMonth = city.NewCarsPerMonthCount,
                UtilizedCarsPerMonth = city.UtilizeCarsPerMonthCount,

                NewCarChance = cityProbabilityChanger.NewCarChance,
                CarsUtilizationChance = cityProbabilityChanger.CarsUtilizationChance,
                CarsStatusChance = cityProbabilityChanger.CarsStatusChance
            };

            try
            {
                await exportImportService.Export(saveData, "exportData.json");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Export data exception! Exception: { ex.Message }");
            }
        }

        private async void Import_Click(object sender, EventArgs e)
        {
            try
            {
                var data = await exportImportService.Import<ProjectInfoDto>("exportData.json");

                city.Cars = data.Cars;
                city.Parking.Cars = data.ParkingCars;
                city.Parking.Capacity = data.ParkingCapacity;
                city.LookingParkingCarsCount = data.LookingParkingCars;
                city.NewCarsPerMonthCount = data.NewCarsPerMonth;
                city.UtilizeCarsPerMonthCount = data.UtilizedCarsPerMonth;
                city.NewCarsCounter = city.Cars.Count;

                cityProbabilityChanger.NewCarChance = data.NewCarChance;
                cityProbabilityChanger.CarsUtilizationChance = data.CarsUtilizationChance;
                cityProbabilityChanger.CarsStatusChance = data.CarsStatusChance;

                InitTextBoxesInfo();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Import data exception! Exception: { ex.Message }");
            }
        }

        private void CarCountTextBoxUpdate()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(CarCountTextBoxUpdate));
                return;
            }

            this.textBox1.Text = city.Cars.Count.ToString();
        }

        private void UpdateParkingInfo()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(UpdateParkingInfo));
                return;
            }

            textBox5.Text = city.Parking.Cars.Count.ToString();
            textBox6.Text = city.LookingParkingCarsCount.ToString();
        }

        private void UpdateMonthInfo()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(UpdateMonthInfo));
                return;
            }

            textBox2.Text = city.NewCarsPerMonthCount.ToString();
            textBox3.Text = city.UtilizeCarsPerMonthCount.ToString();
        }

        private void InitTextBoxesInfo()
        {
            textBox1.Text = city.Cars.Count.ToString();
            textBox7.Text = cityProbabilityChanger.CarsStatusChance.ToString();
            textBox8.Text = cityProbabilityChanger.CarsUtilizationChance.ToString();
            textBox9.Text = cityProbabilityChanger.NewCarChance.ToString();
            textBox4.Text = city.Parking.Capacity.ToString();
            textBox5.Text = city.Parking.Cars.Count.ToString();
            textBox6.Text = city.LookingParkingCarsCount.ToString();
            textBox2.Text = city.NewCarsPerMonthCount.ToString();
            textBox3.Text = city.UtilizeCarsPerMonthCount.ToString();
        }
    }
}
