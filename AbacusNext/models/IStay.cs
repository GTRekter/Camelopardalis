using System;

namespace AbacusNext
{
    public interface IStay
    {
        DateTime ArrivalDate { get; set; }
        DateTime LeaveDate { get; set; }   
        double CalculateCharge();
    }
}
