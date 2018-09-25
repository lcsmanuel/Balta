using System;
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

        public void Save(Customer customer) { }
    }
}