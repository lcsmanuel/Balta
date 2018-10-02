using FluentValidator;
using PaymentContext.Domain.Commands;
using PaymentContext.Domain.Repositories;
using PaymentContext.Shared.Commands;
using PaymentContext.Shared.Handlers;

namespace PaymentContext.Domain.Handlers
{
    public class SubscriptionHandler : Notifiable, IHandler<CreateBoletoSubscriptionCommand>
    {
        private readonly IStudentRepository _repository;

        public SubscriptionHandler(IStudentRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateBoletoSubscriptionCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}