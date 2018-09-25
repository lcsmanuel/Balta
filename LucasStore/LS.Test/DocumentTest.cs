using LS.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LS.Test
{
    [TestClass]
    public class DocumentTest
    {
        private Document vDoc;
        private Document iDoc;

        public DocumentTest()
        {
            vDoc = new Document("358.239.548-08");
            iDoc = new Document("12312312312312");
        }

        [TestMethod]
        public void ShouldReturnNotNotificationWhenDocumentIsValid()
        {
            Assert.AreEqual(true, vDoc.IsValid);
            Assert.AreEqual(0, vDoc.Notifications.Count);
        }

        [TestMethod]
        public void ShouldReturnNotificationWhenDocumentIsInvalid()
        {
            Assert.AreEqual(false, iDoc.IsValid);
            Assert.AreEqual(1, iDoc.Notifications.Count);
        }
    }
}