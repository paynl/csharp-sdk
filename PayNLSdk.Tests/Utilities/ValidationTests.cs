using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PAYNLSDK.Utilities;

namespace PayNLSdk.Tests.Utilities
{
    [TestClass]
    public class ValidationTests
    {
        [TestMethod]
        public void IsNotEmpty_DoesNotThrow_AbcInput()
        {
            // Arrange
            var input = "abc";

            // Act
            try
            {
                ParameterValidator.IsNotEmpty(input, "someParamName");
            }
            catch (ArgumentException)
            {
                Assert.Fail("should not throw");
            }

            // Assert
        }

        [ExpectedException(typeof(ArgumentException), "We expected an exception")]
        [TestMethod]
        public void IsNotEmpty_ThrowsException_EmptyString()
        {
            // Arrange
            var input = "";

            // Act
            ParameterValidator.IsNotEmpty(input, "someParamName");
            
            // Assert
        }

        [TestMethod]
        public void IsEmpty_False_AbcInput()
        {
            // Arrange
            var input = "abc";

            // Act
            var result = ParameterValidator.IsEmpty(input);
            
            // Assert
            Assert.IsFalse(result);
        }

         [TestMethod]
        public void IsEmpty_True_EmptyString()
        {
            // Arrange
            var input = "";

            // Act
            var result = ParameterValidator.IsEmpty(input);

            // Assert
            Assert.IsTrue(result);
        }
    }
}
