using System;
using Fare.Models.Interfaces;

namespace Fare.Models
{
    public class NYCost : ICost
    {
        public decimal BaseFee
        {
            get
            {
                return 3.00m;
            }
        }

        public decimal PerDistance
        {
            get
            {
                return 0.2m;
            }
        }

        public decimal PerMinute
        {
            get
            {
                return 1;
            }
        }

        public decimal NightTimeRate
        {
            get
            {
                return 0.50m;
            }
        }

        public decimal PeakCost
        {
            get
            {
               return 1.00m;
            }
        }

        public decimal Rate
        {
            get
            {
                return 0.35m;
            }
        }

        public decimal Tax
        {
            get
            {
                return 0.50m;
            }
        }
    }
}
