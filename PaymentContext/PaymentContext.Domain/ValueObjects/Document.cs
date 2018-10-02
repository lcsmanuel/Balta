using FluentValidator.Validation;
using PaymentContext.Domain.Enums;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Document : ValueObject
    {
        public Document (string number, EDocumentType type)
        {
            Number = number;
            Type = type;

            AddNotifications(new ValidationContract()
                .Requires()
                .IsTrue(Validate(), "Documento", "Documento inválido"));
        }

        private bool Validate()
        {
            if (Type == EDocumentType.cnpj && Number.Length == 14)
                return true;

            if (Type == EDocumentType.cpf && Number.Length == 11)
                return true;
            
            return false;
        }

        public string Number { get; private set; }
        public EDocumentType Type { get; set; }
    }
}