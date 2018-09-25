using LS.Domain.StoreContext.Entities;
using LS.Domain.StoreContext.Queries;

namespace LS.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);

        bool CheckEmail(string email);

        void Save(Customer customer);

        CustomerOrdersCountResult GetCustomerOrdersCount(string document);
    }
}