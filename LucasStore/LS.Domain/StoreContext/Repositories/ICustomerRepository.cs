using LS.Domain.StoreContext.Entities;

namespace LS.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
        bool CheckDocument(string document);

        bool CheckEmail(string email);

        void Save(Customer customer);
    }
}