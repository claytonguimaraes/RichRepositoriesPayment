using Microsoft.VisualStudio.TestTools.UnitTesting;
using Payment.Domain.Commands;

namespace Payment.Tests.Commands
{
    [TestClass]
    public class CreatePayPalSubscriptionCommandTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenNameIsInvalid(){
            var command = new CreatePayPalSubscriptionCommand();
            command.FirstName = "";

            command.Validate();
            Assert.AreEqual(false, command.IsValid);
        }

    }
}