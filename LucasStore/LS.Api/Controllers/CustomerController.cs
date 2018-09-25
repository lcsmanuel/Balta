using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using LS.Domain.StoreContext.Queries;
using LS.Domain.StoreContext.Entities;
using LS.Domain.StoreContext.Handlers;
using LS.Domain.StoreContext.ValueObjects;
using LS.Domain.StoreContext.Repositories;
using LS.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using LS.Domain.StoreContext.Commands.CustomerCommands.Outputs;

namespace LS.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;
        private readonly CustomerHandler _handler;

        public CustomerController(ICustomerRepository repository, CustomerHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }
        
        [HttpGet]
        [Route("customers")]
        public IEnumerable<ListCostumerQueryResult> Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("customers/{id}")]
        public CostumerQueryResult GetById(Guid id)
        {
            return _repository.GetCostumer(id);
        }

        [HttpGet]
        [Route("customers/{id}/orders")]
        public IEnumerable<ListOrdersQueryResult> GetOrdersById(Guid id)
        {
            return _repository.GetOrders(id);
        }

        [HttpPost]
        [Route("customers")]
        public object Post([FromBody]CreateCustomerCommand command)
        {
            var result = (CreateCustomerCommandResult)_handler.Handle(command);

            if(_handler.Invalid)
                return BadRequest(_handler.Notifications);

            return result;
        }

        [HttpPut]
        [Route("customers/{id}")]
        public object Put([FromBody]UpdateCustomerCommand command)
        {
            var result = (UpdateCustomerCommand)_handler.Handle(command);

            if(_handler.Invalid)
                return BadRequest(_handler.Notifications);

            return result;
        }

        [HttpDelete]
        [Route("customers/{id}")]
        public object Delete(Guid Id)
        {
            _repository.Delete(Id);

            return new { message = "Cliente removido com sucesso." };
        }
    }
}