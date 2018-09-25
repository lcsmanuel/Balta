using System;
using System.Collections.Generic;
using LS.Domain.StoreContext.Entities;
using LS.Domain.StoreContext.Queries;
using LS.Domain.StoreContext.Repositories;

namespace LS.Test.Fakes
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public bool CheckDocument(string document)
        {
            return false;
        }

        public bool CheckEmail(string email)
        {
            return false;
        }

        public void Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ListCostumerQueryResult> Get()
        {
            throw new NotImplementedException();
        }

        public CostumerQueryResult GetCostumer(Guid Id)
        {
            throw new NotImplementedException();
        }

        public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
        {
            return new CustomerOrdersCountResult
            {
                Id = Guid.NewGuid(),
                Name = "",
                Document = "",
                Orders = 0

            };
        }

        public IEnumerable<ListOrdersQueryResult> GetOrders(Guid Id)
        {
            throw new NotImplementedException();
        }

        public void Save(Customer customer) { }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}