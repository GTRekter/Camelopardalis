using System;
using System.Linq;

namespace AbacusNext
{
    public abstract class Stay : IStay
    {
        #region Fields and Properties
        private double _rate;
        public double Rate
        {
            get
            {
                return _rate;
            }
            set
            {
                if (value < 0)
                {
                    throw new IndexOutOfRangeException("The rate cannot be negative");
                }
                _rate = value;
            }
        }
        public DateTime ArrivalDate { get; set; } 
        public DateTime LeaveDate { get; set; } 
        #endregion
        #region Constructor
        public Stay(double rate, DateTime arrivalDate, DateTime leaveDate) 
        {
            Rate = rate;
            ArrivalDate = arrivalDate;
            LeaveDate = leaveDate;
            if(ArrivalDate > LeaveDate)
            {
                throw new IndexOutOfRangeException("The arrival date cannot be after the leave date");
            }
        }
        #endregion
        #region Public Methods
        public virtual double CalculateCharge()
        {
            return (LeaveDate.TimeOfDay.TotalSeconds - ArrivalDate.TimeOfDay.TotalSeconds) * Rate;
        }
        #endregion
    }
}
