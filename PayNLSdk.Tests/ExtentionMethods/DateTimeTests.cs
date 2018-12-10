using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PayNLSdk.ExtentionMethods;

namespace PayNLSdk.Tests.ExtentionMethods
{
    [TestClass]
    public class DateTimeTests
    {
        [TestInitialize]
        public void TestInitialize()
        {

        }

        [TestMethod]
        public void LastMonthFirstDay_February_CurrentlyMarch()
        {
            // Arrange
            var initialDate = new DateTime(2018,2,5);

            // Act
            var result = initialDate.LastMonthFirstDay();

            // Assert
            Assert.AreEqual(2018, result.Year);
            Assert.AreEqual(1, result.Month);
            Assert.AreEqual(1, result.Day);
        }

        [TestMethod]
        public void LastMonthFirstDay_DecemberPreviousYear_CurrentlyFirstJanuary()
        {
            // Arrange
            var initialDate = new DateTime(2018, 1, 1);

            // Act
            var result = initialDate.LastMonthFirstDay();

            // Assert
            Assert.AreEqual(2017, result.Year);
            Assert.AreEqual(12, result.Month);
            Assert.AreEqual(1, result.Day);
        }

        [TestMethod]
        public void LastMonthFirstDay_PreviousMonth_LastDayOfTheMonth()
        {
            // Arrange
            var initialDate = new DateTime(2018, 1, 31);

            // Act
            var result = initialDate.LastMonthFirstDay();

            // Assert
            Assert.AreEqual(2017, result.Year);
            Assert.AreEqual(12, result.Month);
            Assert.AreEqual(1, result.Day);
        }

        [TestMethod]
        public void LastWeek_PreviousMonday_TodaySaturday()
        {
            // Arrange
            var initialDate = new DateTime(2018,10,13);

            // Act
            var result = initialDate.LastWeek(DayOfWeek.Monday);

            // Assert
            Assert.AreEqual(new DateTime(2018,10,1), result);
            Assert.AreEqual(DayOfWeek.Monday, result.DayOfWeek);
        }

        [TestMethod]
        public void LastWeek_PreviousMonday_TodayMonday()
        {
            // Arrange
            var initialDate = new DateTime(2018, 12, 10);

            // Act
            var result = initialDate.LastWeek(DayOfWeek.Monday);

            // Assert
            Assert.AreEqual(new DateTime(2018, 12, 3), result);
            Assert.AreEqual(DayOfWeek.Monday, result.DayOfWeek);
        }

        [TestMethod]
        public void LastWeek_PreviousMonday_TodaySunday()
        {
            // Arrange
            var initialDate = new DateTime(2018, 12, 9);

            // Act
            var result = initialDate.LastWeek(DayOfWeek.Monday);

            // Assert
            Assert.AreEqual(new DateTime(2018, 11, 26), result);
            Assert.AreEqual(DayOfWeek.Monday, result.DayOfWeek);
        }

        [TestMethod]
        public void LastMonthLastDay_Lastday_normalconditions()
        {
            // Arrange
            var initialDate = new DateTime(2018, 7, 19);

            // Act
            var result = initialDate.LastMonthLastDay();

            // Assert
            Assert.AreEqual(2018, result.Year);
            Assert.AreEqual(6, result.Month);
            Assert.AreEqual(30, result.Day);
        }


        [TestMethod]
        public void LastMonthLastDay_31DecemberPreviousYear_CurrentlyFirstJanuary()
        {
            // Arrange
            var initialDate = new DateTime(2018, 1, 1);

            // Act
            var result = initialDate.LastMonthLastDay();

            // Assert
            Assert.AreEqual(2017, result.Year);
            Assert.AreEqual(12, result.Month);
            Assert.AreEqual(31, result.Day);
        }

        [TestMethod]
        public void LastMonthLastDay_1March_LeapYear()
        {
            // Arrange
            var initialDate = new DateTime(2004, 3, 15);

            // Act
            var result = initialDate.LastMonthLastDay();

            // Assert
            Assert.AreEqual(2004, result.Year);
            Assert.AreEqual(2, result.Month);
            Assert.AreEqual(29, result.Day);
        }
    }
}
