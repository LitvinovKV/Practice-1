using System;

namespace Tools.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime RandomDate(DateTime startDate)
        {
            var random = new Random();

            var countDays = (DateTime.Today - startDate).Days;
            
            return startDate.AddDays(random.Next(countDays));
        }
    }
}
