using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PaymentContext.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var doc = new Document("123", EDocumentType.cnpj);
            Assert.IsFalse(doc.IsValid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenCNPJIsValid()
        {
            var doc = new Document("12345678911234", EDocumentType.cnpj);
            Assert.IsTrue(doc.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            var doc = new Document("123", EDocumentType.cpf);
            Assert.IsFalse(doc.IsValid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenCPFIsValid()
        {
            var doc = new Document("35823954808", EDocumentType.cpf);
            Assert.IsTrue(doc.IsValid);
        }
    }
}