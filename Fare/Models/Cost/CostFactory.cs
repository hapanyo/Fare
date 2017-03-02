using Fare.Models.Interfaces;
using System;

namespace Fare.Models.Cost
{
    public static class CostFactory
    {
        /// <summary>
        /// Factory returns implementation of Cost
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public static ICost GetRateInstance(States state)
        {
            switch (state)
            {
                case States.NewYork:
                    return new NewYorkCost();
                case States.Other:
                default:
                    return new OtherCost();
            }
        }
    }
}