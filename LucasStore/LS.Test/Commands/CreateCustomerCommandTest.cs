using LS.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LS.Test.Commands
{
    [TestClass]
    public class CreateCustomerCommandTest
    {
        [TestMethod]
        public void ShouldValidateWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Lucas";
            command.LastName = "Ferreira";
            command.Document = "35823954808";
            command.Email = "lcsmanuel@gmail.com";
            command.Phone = "11992361748";

            Assert.AreEqual(true, command.Valid());
        }
    }
}