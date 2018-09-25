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
            var command = new CreateCustomerCommand
            {
                FirstName = "Lucas",
                LastName = "Ferreira",
                Document = "35823954808",
                Email = "lcsmanuel@gmail.com",
                Phone = "11992361748"
            };

            Assert.AreEqual(true, command.Valid());
        }
    }
}