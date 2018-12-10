using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PayNLSdk.API.Statistics.GetManagement;
using PAYNLSDK.Net;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace PayNLSdk.Tests.Api.Statistics
{
    [TestClass]
    public class GetStatsRequestTests
    {
        private PayNLSdk.API.Statistics.GetManagement.Request _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            var clientMock = new Mock<IClient>();
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
            Assert.IsNotNull(_sut.SortByFieldNames);
            Assert.AreEqual(0, _sut.SortByFieldNames.Count);
        }

        [TestMethod]
        public void GetParameters_ContainsGroupBy_IfSortByFieldNamesPropertyIsUsed()
        {
            // Arrange
            _sut.SortByFieldNames.Add("ABC");

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
