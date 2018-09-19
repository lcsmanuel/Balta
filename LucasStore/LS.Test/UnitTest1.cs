using LS.Domain.StoreContext.Entities;
using LS.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LS.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {

            var name = new Name("Lucas", "Ferreira");
            var doc = new Document("12345678910");
            var email = new Email("lcsmanuel@gmail.com");

            var c = new Customer(name, doc, email, "11992361748");

            var mouse = new Product("Mouse", "rato", "image.png", 59.90M, 10);
            var teclado = new Product("Keyboard", "teclado", "image.png", 159.90M, 10);
            var impressora = new Product("Printer", "impressora", "image.png", 359.90M, 10);
            var cadeira = new Product("Chair", "cadeira", "image.png", 559.90M, 10);

            var order = new Order(c);
            order.AddItem(mouse, 5);
            order.AddItem(teclado, 5);
            order.AddItem(impressora, 5);
            order.AddItem(cadeira, 5);

            order.Place();

            var valid = order.Valid;

            order.Pay();

            order.Ship();

            order.Cancel();

        }
    }
}
