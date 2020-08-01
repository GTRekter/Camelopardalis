using System;
using System.Linq;

namespace AbacusNext
{
    public class ShortStay : Stay
    {
        #region Fields and Properties
        public TimeSpan StartCharge { get; set; } 
        public TimeSpan EndCharge { get; set; }
        #endregion
        #region Constructor
        public ShortStay(double rate, DateTime arrivalDate, DateTime leaveDate, TimeSpan startCharge, TimeSpan endCharge)
            : base(rate, arrivalDate, leaveDate)
        { 
            StartCharge = startCharge;
            EndCharge = endCharge;
        }
        #endregion
        #region Public Methods
        public override double CalculateCharge()
        {
            int days = LeaveDate.GetWeekdaysBetweenDates(ArrivalDate); 
            double totalChargedSeconds = 0;
            if(days < 1)
            {
                return 0;
            }
            switch(days){
                case 1:
                    totalChargedSeconds = GetChargedSecondsPerDay(ArrivalDate.TimeOfDay, LeaveDate.TimeOfDay);
                    break;
                case 2: 
                    totalChargedSeconds += GetChargedSecondsPerDay(ArrivalDate.TimeOfDay, EndCharge);
                    totalChargedSeconds += GetChargedSecondsPerDay(StartCharge, LeaveDate.TimeOfDay);
                    break;
                default:
                    totalChargedSeconds += (days-2)*GetChargedSecondsPerDay();
                    totalChargedSeconds += GetChargedSecondsPerDay(ArrivalDate.TimeOfDay, EndCharge);
                    totalChargedSeconds += GetChargedSecondsPerDay(StartCharge, LeaveDate.TimeOfDay);
                    break;
            }
            return totalChargedSeconds*(Rate/3600);
        }
        #endregion
        #region Private Methods
        private double GetChargedSecondsPerDay()
        {
            return EndCharge.TotalSeconds - StartCharge.TotalSeconds;
        }
        private double GetChargedSecondsPerDay(TimeSpan start, TimeSpan end)
        {
            double startTotalSeconds = StartCharge.TotalSeconds;
            double endTotalSeconds = EndCharge.TotalSeconds;
            if(start.TotalSeconds <= EndCharge.TotalSeconds)
            {
                if(start.TotalSeconds > StartCharge.TotalSeconds)
                {
                    startTotalSeconds = start.TotalSeconds;
                } 
                if(end.TotalSeconds < EndCharge.TotalSeconds)
                {
                    endTotalSeconds = end.TotalSeconds;
                }
                return endTotalSeconds - startTotalSeconds;
            }
            return 0;
        }
        #endregion
    }
}
