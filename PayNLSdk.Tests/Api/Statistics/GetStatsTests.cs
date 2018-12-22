using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PayNLSdk.API.Statistics.GetManagement;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace PayNLSdk.Tests.Api.Statistics
{
    [TestClass]
    [SuppressMessage("ReSharper", "RedundantNameQualifier", Justification = "We need to be sure the correct object is called in the tests")]
    public class GetStatsRequestTests
    {
        private PayNLSdk.API.Statistics.GetManagement.Request _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _sut = new PayNLSdk.API.Statistics.GetManagement.Request();
        }

        [TestMethod]
        public void Ctor_FilterPropertyNotTempty_Always()
        {
            // Arrange


            // Act

            // Assert
            Assert.IsNotNull(_sut.Filters);
            Assert.AreEqual(0, _sut.Filters.Count);
        }

        [TestMethod]
        public void Ctor_GroupByPropertyNotTempty_Always()
        {
            // Arrange


            // Act

            // Assert
            Assert.IsNotNull(_sut.GroupByFieldNames);
            Assert.AreEqual(0, _sut.GroupByFieldNames.Count);
        }

        [TestMethod]
        public void GetParameters_ContainsGroupBy_IfSortByFieldNamesPropertyIsUsed()
        {
            // Arrange
            _sut.GroupByFieldNames.Add("ABC");

            // Act
            var result = _sut.GetParameters();

            // Assert
            Assert.AreEqual("ABC", result.Get("groupBy[0]"));

        }

        [TestMethod]
        public void GetParameters_ContainsFilters_MultipleFiltersAdded()
        {
            // Arrange
            _sut.Filters.Add(new Request.FilterItem { Key = "KEY1", Value = "VAL1" });
            _sut.Filters.Add(new Request.FilterItem { Key = "KEY2", Value = "VAL2" });

            // Act
            var result = _sut.GetParameters();

            // Assert
            Assert.IsTrue(GetWithPartialKey(result, "filterType[").Contains("KEY1"));
            Assert.IsTrue(GetWithPartialKey(result, "filterType[").Contains("KEY2"));
            Assert.IsTrue(GetWithPartialKey(result, "filterValue[").Contains("VAL1"));
            Assert.IsTrue(GetWithPartialKey(result, "filterValue[").Contains("VAL2"));
        }

        [TestMethod]
        public void Create_CorrectStartEndDate_LastWeek()
        {
            // Arrange
            var dateTime = new Mock<IDateTime>();
            dateTime.SetupGet(p => p.Now).Returns(new DateTime(2018, 12, 11));

            // Act
            var result = Request.Create(dateTime.Object, Request.StatsPeriod.LastWeek);

            // Assert
            Assert.AreEqual(new DateTime(2018,12,3), result.StartDate);
            Assert.AreEqual(new DateTime(2018,12,9), result.EndDate);
        }

        [TestMethod]
        public void Create_CorrectStartEndDate_LastMonth()
        {
            // Arrange
            var dateTime = new Mock<IDateTime>();
            dateTime.SetupGet(p => p.Now).Returns(new DateTime(2018, 12, 11));

            // Act
            var result = Request.Create(dateTime.Object, Request.StatsPeriod.LastMonth);

            // Assert
            Assert.AreEqual(new DateTime(2018, 11, 1), result.StartDate);
            Assert.AreEqual(new DateTime(2018, 11, 30), result.EndDate);
        }

        [TestMethod]
        public void Create_CorrectStartEndDate_ThisWeek()
        {
            // Arrange
            var dateTime = new Mock<IDateTime>();
            dateTime.SetupGet(p => p.Now).Returns(new DateTime(2018, 12, 11));

            // Act
            var result = Request.Create(dateTime.Object, Request.StatsPeriod.ThisWeek);

            // Assert
            Assert.AreEqual(new DateTime(2018, 12, 10), result.StartDate);
            Assert.AreEqual(new DateTime(2018, 12, 16), result.EndDate);
        }

        [TestMethod]
        public void Create_CorrectStartEndDate_ThisMonth()
        {
            // Arrange
            var dateTime = new Mock<IDateTime>();
            dateTime.SetupGet(p => p.Now).Returns(new DateTime(2018, 12, 11));

            // Act
            var result = Request.Create(dateTime.Object, Request.StatsPeriod.ThisMonth);

            // Assert
            Assert.AreEqual(new DateTime(2018, 12, 1), result.StartDate);
            Assert.AreEqual(new DateTime(2018, 12, 11), result.EndDate);
        }

        /// <summary>
        /// Loops all items in a <see cref="NameValueCollection"/> and
        /// return all values from all keys which start with the <paramref name="keyStartsWith"/>
        /// </summary>
        /// <param name="nvc"></param>
        /// <param name="keyStartsWith"></param>
        /// <returns></returns>
        private static IEnumerable<string> GetWithPartialKey(NameValueCollection nvc, string keyStartsWith)
        {
            if (nvc == null)
            {
                yield break;
            }

            foreach (var s in nvc.AllKeys)
            {
                if (s.ToLower().StartsWith(keyStartsWith.ToLower()))
                {
                    yield return nvc.Get(s);
                }
            }
        }
    }
}
