using System;
using System.Collections.Generic;
using LS.Domain.StoreContext.Entities;
using LS.Domain.StoreContext.Queries;

namespace LS.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);

        bool CheckEmail(string email);

        void Save(Customer customer);

        void Update(Customer customer);

        void Delete(Guid Id);

        CustomerOrdersCountResult GetCustomerOrdersCount(string document);

        IEnumerable<ListCostumerQueryResult> Get();

        CostumerQueryResult GetCostumer(Guid Id);

        IEnumerable<ListOrdersQueryResult> GetOrders(Guid Id);
    }
}