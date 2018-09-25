using LS.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using LS.Domain.StoreContext.Handlers;
using LS.Test.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LS.Test.Handler
{
    [TestClass]
    public class CustomerHandlerTest
    {
        [TestMethod]
        public void ShouldRegisterCustomerWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand
            {
                FirstName = "Lucas",
                LastName = "Ferreira",
                Document = "35823954808",
                Email = "lcsmanuel@gmail.com",
                Phone = "11992361748"
            };

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.IsValid);
        }
    }
}