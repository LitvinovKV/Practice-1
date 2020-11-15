using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace DevelopmentSystemTest.ThreadClasses.DateChanger
{
    public class DateChanger : IDateChanger
    {
        private DateTime currentDateTime = DateTime.Now;

        private readonly double secondsInOneHour = 0.5;
        private readonly int hoursInOneDay = 24;
        private readonly int daysInOneMonth = 30;
        private readonly int monthsInOneYear = 12;

        private int HoursBeforeDayCounter = 0;
        private int DaysBeforeMonthCounter = 0;
        private int MonthBeforeYearCounter = 0;

        public EventWaitHandle WaitHandle { get; } = new ManualResetEvent(initialState: false);

        public event Action HourChangeNotify;
        public event Action DayChangeNotify;
        public event Action MonthChangeNotify;
        public event Action YearChangeNotify;

        public void Run()
        {
            while (true)
            {
                WaitHandle.WaitOne();
             
                if ((DateTime.Now - currentDateTime).TotalSeconds >= secondsInOneHour)
                {
                    Debug.WriteLine($"Час {HoursBeforeDayCounter + 1}/24");
                    currentDateTime = DateTime.Now;

                    if (HourChangeNotify != null)
                    {
                        Task.Run(() => HourChangeNotify());
                    }

                    HoursBeforeDayCounter++;
                }

                if (HoursBeforeDayCounter == hoursInOneDay)
                {
                    Debug.WriteLine("Новый день");

                    if (DayChangeNotify != null)
                    {
                        Task.Run(() => DayChangeNotify());
                    }

                    HoursBeforeDayCounter = 0;
                    DaysBeforeMonthCounter++;
                }

                if (DaysBeforeMonthCounter == daysInOneMonth)
                {
                    Debug.WriteLine("Новый месяц");

                    if (MonthChangeNotify != null)
                    {
                        Task.Run(() => MonthChangeNotify());
                    }

                    DaysBeforeMonthCounter = 0;
                    MonthBeforeYearCounter++;
                }

                if (MonthBeforeYearCounter == monthsInOneYear)
                {
                    Debug.WriteLine("Новый год");

                    if (YearChangeNotify != null)
                    {
                        Task.Run(() => YearChangeNotify());
                    }

                    MonthBeforeYearCounter = 0;
                }
            }
        }
    }
}