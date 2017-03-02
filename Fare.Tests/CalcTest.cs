using System;
using Fare.Models;
using Fare.Models.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Fare.Tests
{
    [TestClass()]
    public class CalcTest
    {
        private ICalculator _calculator;
        public CalcTest()
        {
            _calculator = new Calculator();
        }

        [TestMethod()]
        public void CalculateIsPeakTest()
        {
            Ride ride =
                new Ride
                {
                    Miles = 2,
                    Minutes = 5,
                    StartDateTime = DateTime.Parse("2010-10-08 05:30 pm"),
                    State = States.NewYork
                };

            Assert.AreEqual(_calculator.Calculate(ride), 9.75m);
        }

        [TestMethod()]
        public void CalculateIsNonPeakTest()
        {
            Ride ride =
                new Ride
                {
                    Miles = 2,
                    Minutes = 5,
                    StartDateTime = DateTime.Parse("2010-10-08 07:30 am"),
                    State = States.NewYork
                };

            Assert.AreEqual(_calculator.Calculate(ride), 8.75m);
        }

        [TestMethod()]
        public void CalculateWeekendTest()
        {
            Ride ride =
                new Ride
                {
                    Miles = 2,
                    Minutes = 5,
                    StartDateTime = DateTime.Parse("2017-03-04 05:30 pm"),
                    State = States.NewYork
                };

            Assert.AreEqual(_calculator.Calculate(ride), 8.75m);
        }

   
        [TestMethod()]
        public void CalculateDayTimeTest()
        {
            Ride ride =
                new Ride
                {
                    Miles = 2,
                    Minutes = 5,
                    StartDateTime = DateTime.Parse("2010-10-08 06:30 am"),
                    State = States.NewYork
                };

            Assert.AreEqual(_calculator.Calculate(ride), 8.75m);
        }

        [TestMethod()]
        public void CalculateNightTimeTest()
        {
            Ride ride =
                new Ride
                {
                    Miles = 2,
                    Minutes = 5,
                    StartDateTime = DateTime.Parse("2010-10-08 09:30 pm"),
                    State = States.NewYork
                };

            Assert.AreEqual(_calculator.Calculate(ride), 9.25m);
        }

        /// <summary>
        /// We assume each state has different cost and rates.
        /// </summary>
        [TestMethod()]
        public void CalculateDifferentStates()
        {
            var ride1 =
                new Ride
                {
                    Miles = 2,
                    Minutes = 5,
                    StartDateTime = DateTime.Parse("2010-10-08 05:30 pm"),
                    State = States.NewYork
                };
            var cost1 = _calculator.Calculate(ride1);

            var ride2 =
                new Ride
                {
                    Miles = 2,
                    Minutes = 5,
                    StartDateTime = DateTime.Parse("2010-10-08 05:30 pm"),
                    State = States.Other
                };
            var cost2 = _calculator.Calculate(ride2);

            Assert.AreNotEqual(cost1,cost2);
        }


    }

}
