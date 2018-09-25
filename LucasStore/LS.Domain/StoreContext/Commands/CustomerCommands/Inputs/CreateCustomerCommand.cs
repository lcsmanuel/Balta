using FluentValidator;
using LS.Shared.Commands;
using FluentValidator.Validation;

namespace LS.Domain.StoreContext.Commands.CustomerCommands.Inputs
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .Requires()
                .HasMinLen(FirstName, 3, "FirstName", "O nome deve conter ao menos três caracteres.")
                .HasMaxLen(FirstName, 40, "FirstName", "O nome deve conter ao máximo quarenta caracteres.")
                .HasMinLen(LastName, 3, "LastName", "O sobrenome deve conter ao menos três caracteres.")
                .HasMaxLen(LastName, 40, "LastName", "O sobrenome deve conter ao máximo quarenta caracteres.")
                .IsEmail(Email, "Email", "O E-mal é inválido")
                .HasLen(Document, 11, "Document", "CPF inválido")
            );
            return IsValid;
        }
    }
}