using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PayNLSdk.Tests.Api.Alliance
{
    [TestClass]
    public class AddInvoiceRequestTests
    {
        private PAYNLSDK.API.Alliance.AddInvoice.Request _sut;

        [TestInitialize]
        public void TestInitialize()
        {
            _sut = new PAYNLSDK.API.Alliance.AddInvoice.Request(
                "Dummy",
                "Dummy",
                "Dummy",
                "Dummy",
                12345
                );
        }
        
        [TestMethod]
        public void GetParameters_ReturnMandatoryProperties_OnCalled()
        {
            // Arrange
            
            // Act
            var parameters = _sut.GetParameters();

            // Assert
            Assert.IsNotNull(parameters["serviceId"]);
            Assert.IsNotNull(parameters["merchantId"]);
            Assert.IsNotNull(parameters["invoiceId"]);
            Assert.IsNotNull(parameters["amount"]);
            Assert.IsNotNull(parameters["description"]);
        }

        #region Optional parameters
        [TestMethod]
        public void MakeYesterday_internalPropertySet_True()
        {
            // Arrange

            // Act
            _sut.MakeYesterday = true;

            // Assert
            Assert.AreEqual("true", _sut.GetParameters()["makeYesterday"]);
        }

        [TestMethod]
        public void MakeYesterday_propertyNotAvailableInInParameters_PropertyIsNotSet()
        {
            // Arrange
            //_sut.MakeYesterday = null;

            // Act
            var parameter = _sut.GetParameters()["makeYesterday"];

            // Assert
            Assert.IsNull(parameter);
        }

        [TestMethod]
        public void InvoiceUrl_internalPropertySet_True()
        {
            // Arrange

            // Act
            _sut.InvoiceUrl = "http://url.to/invoice";

            // Assert
            Assert.AreEqual("true", _sut.GetParameters()["invoiceUrl"]);
        }

        [TestMethod]
        public void InvoiceUrl_propertyNotAvailableInInParameters_PropertyIsNotSet()
        {
            // Arrange
            //_sut.MakeYesterday = null;

            // Act
            var parameter = _sut.GetParameters()["invoiceUrl"];

            // Assert
            Assert.IsNull(parameter);
        }
        #endregion
    }
}
