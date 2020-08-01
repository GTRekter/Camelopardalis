using System;

namespace AbacusNext
{
    public class LongStay : Stay
    {
        #region Constructor
        public LongStay(double rate, DateTime arrivalDate, DateTime leaveDate)
            : base(rate, arrivalDate, leaveDate)
        { 
        }
        #endregion
        #region Public Methods
        public override double CalculateCharge()
        {
            int days = LeaveDate.GetDaysBetweenDates(ArrivalDate);
            if(days <= 1)
            {
                return Rate;
            } 
            else
            {
                return days * Rate;
            }
        }
        #endregion
    }
}
