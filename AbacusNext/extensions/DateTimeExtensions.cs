using System;
using System.Linq;

namespace AbacusNext
{
    public static class DateTimeExtensions
    {   
        public static bool IsWeekend(this DateTime date){
            if ((date.DayOfWeek == DayOfWeek.Saturday) || (date.DayOfWeek == DayOfWeek.Sunday)) {
                return true;
            }
            return false;
        }
        public static int GetDaysBetweenDates(this DateTime end, DateTime start, bool countEndDate = true){
            var daysBetween = end.Date.Subtract(start.Date).Days;
            return countEndDate ? daysBetween += 1 : daysBetween;
        }
        public static int GetWeekdaysBetweenDates(this DateTime end, DateTime start, bool countEndDate = true)
        {
            var daysBetween = end.Date.Subtract(start.Date).Days;
            daysBetween = countEndDate ? daysBetween += 1 : daysBetween;
            return Enumerable.Range(0, daysBetween).Count(d => (start.AddDays(d).DayOfWeek != DayOfWeek.Saturday && start.AddDays(d).DayOfWeek != DayOfWeek.Sunday));
        }
    }
}
