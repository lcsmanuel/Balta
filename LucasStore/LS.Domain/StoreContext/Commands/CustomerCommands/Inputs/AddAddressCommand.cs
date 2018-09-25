using System;
using FluentValidator;
using LS.Shared.Commands;
using FluentValidator.Validation;
using LS.Domain.StoreContext.ValueObjects;

namespace LS.Domain.StoreContext.Commands.CustomerCommands.Inputs
{
    public class AddAddressCommand : Notifiable, ICommand
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; private set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public EAddressType Type { get; set; }

        public bool Valid()
        {
            return base.IsValid;
        }
    }
}