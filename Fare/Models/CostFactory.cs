using Fare.Models.Interfaces;
using System;

namespace Fare.Models
{
    public static class CostFactory
    {
        public static ICost GetRateInstance(States state)
        {
            switch (state)
            {
                case States.NewYork:
                    return new NYCost();
                case States.Other:
                default:
                    return new OtherCost();
            }
        }
    }
}