using LS.Domain.StoreContext.Entities;
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

        public void Save(Customer customer) { }
    }
}