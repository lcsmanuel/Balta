using System;
using FluentValidator;
using LS.Shared.Commands;
using LS.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using LS.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using LS.Domain.StoreContext.ValueObjects;
using LS.Domain.StoreContext.Entities;
using LS.Domain.StoreContext.Repositories;
using LS.Domain.StoreContext.Services;

namespace LS.Domain.StoreContext.Handlers
{

    public class CustomerHandler : Notifiable, ICommandHandler<CreateCustomerCommand>, ICommandHandler<AddAddressCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;

        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            if (_repository.CheckDocument(command.Document))
                AddNotification("Document", "Este CPF já está em uso.");

            if (_repository.CheckEmail(command.Email))
                AddNotification("Email", "Este Email já está em uso.");

            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer(name, document, email, command.Phone);

            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if(Invalid)
                return null;
            
            _repository.Save(customer);

            _emailService.Send(email.Address, "hello@ls.store", "Bem vindo", "Seja bem vindo a LS Store");

            return new CreateCustomerCommandResult(Guid.NewGuid(), name.ToString(), email.Address);
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}