using System.Collections.Generic;
using LS.Domain.StoreContext.Entities;
using LS.Domain.StoreContext.ValueObjects;

namespace LS.Domain.BackOfficeContext.Entities
{
    public class Customer
    {
        public IReadOnlyCollection<Product> Products { get; set; }

        public Name Name { get; set; }
    }
}