using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fare.Models.Interfaces;
using Fare.Models.Extensions;

namespace Fare.Models
{
    public class Calculator : ICalculator
    {
        private ICost cost;

        public decimal Calculate(Ride ride)
        {
            cost = CostFactory.GetRateInstance(ride.State);

            var timed = ride.Minutes / cost.PerMinute;
            var traveled = ride.Miles / cost.PerDistance;

            var total = cost.BaseFee 
                + cost.Tax 
                + ((timed + traveled) * cost.Rate);

            if (ride.StartDateTime.IsPeakHour())
            {
                total += cost.PeakCost;
            }
            if (ride.StartDateTime.IsNight())
            {
                total += cost.NightTimeRate;
            }
            return total;
        }
    }
}