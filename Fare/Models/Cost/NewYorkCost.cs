using System;
using Fare.Models.Interfaces;

namespace Fare.Models.Cost
{
    public class NewYorkCost : ICost
    { 
        public decimal BaseFee => 3.00m;

        public decimal PerDistance => 0.2m;

        public decimal PerMinute => 1;

        public decimal NightTimeRate => 0.50m;

        public decimal PeakCost => 1.00m;

        public decimal Rate => 0.35m;

        public decimal Tax => 0.50m;
    }
}
