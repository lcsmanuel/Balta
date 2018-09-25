using LS.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LS.Test
{
    [TestClass]
    public class NameTest
    {
        [TestMethod]
        public void ShouldReturnNotNotificationWhenNameIsValid()
        {
            var name = new Name("", "Ferreira");
            Assert.AreEqual(false, name.IsValid);
            Assert.AreEqual(1, name.Notifications.Count);
        }
    }
}