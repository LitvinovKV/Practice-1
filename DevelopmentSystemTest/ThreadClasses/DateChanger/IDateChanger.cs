using System;

namespace DevelopmentSystemTest.ThreadClasses.DateChanger
{
    public interface IDateChanger : IThreadRunnable
    {
        event Action HourChangeNotify;
        event Action DayChangeNotify;
        event Action MonthChangeNotify;
        event Action YearChangeNotify;
    }
}
