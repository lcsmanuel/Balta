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
using LS.Shared.Commands;

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
        [Route("v1/customers")]
        [ResponseCache(Location = ResponseCacheLocation.Client, Duration = 60)]
        public IEnumerable<ListCostumerQueryResult> Get()
        {
            return _repository.Get();
        }

        [HttpGet]
        [Route("v1/customers/{id}")]
        public CostumerQueryResult GetById(Guid id)
        {
            return _repository.GetCostumer(id);
        }

        [HttpGet]
        [Route("v2/customers/{document}")]
        public CostumerQueryResult GetByDocument(Guid id)
        {
            return _repository.GetCostumer(id);
        }

        [HttpGet]
        [Route("v1/customers/{id}/orders")]
        public IEnumerable<ListOrdersQueryResult> GetOrdersById(Guid id)
        {
            return _repository.GetOrders(id);
        }

        [HttpPost]
        [Route("v1/customers")]
        public ICommandResult Post([FromBody]CreateCustomerCommand command)
        {
            var result = (CreateCustomerCommandResult)_handler.Handle(command);
            return result;
        }

        [HttpPut]
        [Route("v1/customers/{id}")]
        public ICommandResult Put([FromBody]UpdateCustomerCommand command)
        {
            var result = (UpdateCustomerCommandResult)_handler.Handle(command);
            return result;
        }

        [HttpDelete]
        [Route("v1/customers/{id}")]
        public object Delete(Guid Id)
        {
            _repository.Delete(Id);

            return new { message = "Cliente removido com sucesso." };
        }
    }
}