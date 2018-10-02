using FluentValidator.Validation;
using PaymentContext.Shared.ValueObjects;

namespace PaymentContext.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            AddNotifications(new ValidationContract()
                .Requires()
                .IsNullOrEmpty(FirstName, "Nome", "Nome inválido")
                .HasMinLen(FirstName, 3, "Nome", "Nome deve conter ao menos três caracteres.")
                .IsNullOrEmpty(LastName, "Sobrenome", "Sobrenome inválido")
                .HasMinLen(LastName, 3, "Sobrenome", "Sobrenome deve conter ao menos três caracteres."));
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}