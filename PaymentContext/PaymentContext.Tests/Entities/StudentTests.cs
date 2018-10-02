using PaymentContext.Domain.Enums;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PaymentContext.Tests.Entities
{
    [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void AddSub()
        {
            var name = new Name("Lucas", "Ferreira");
            var document = new Document("35823954808", EDocumentType.cpf);
            var email = new Email("lcsmanuel@gmail.com");
            var sub = new Subscription(null);
            var address = new Address("Rua Coronel Evaristo de Campos", "79", "Santana", "São Paulo", "São Paulo", "Brasil", "02450020");
            var student = new Student(name, document, email, address);
            student.AddSubscription(sub);

            if (name.Notifications.Count > 0)
            {
                foreach (var item in name.Notifications)
                {
                    
                }
            }

        }
    }
}