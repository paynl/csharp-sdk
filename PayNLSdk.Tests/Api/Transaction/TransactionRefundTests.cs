using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PayNLSdk.Tests.Api.Transaction
{
    [TestClass]
    public class TransactionRefundTests
    {
        [TestMethod]
        public void Request_AmountInCents_PassedInAsDecimal()
        {
            // Arrange
            var sut = new PAYNLSDK.API.Transaction.Refund.Request
            {
                TransactionId = "DUMMY",
                Amount = 3.50m
            };

            // Act
            var result = sut.GetParameters();

            // Assert
            Assert.AreEqual("350", result["amount"]);
        }

        [TestMethod]
        public void Request_NoAmountSupplied_NoParameterWithAmount()
        {
            // Arrange
            var sut = new PAYNLSDK.API.Transaction.Refund.Request
            {
                TransactionId = "DUMMY",
                Amount = null
            };

            // Act
            var result = sut.GetParameters();

            // Assert
            Assert.IsNull(result["amount"]);
        }


    }
}
