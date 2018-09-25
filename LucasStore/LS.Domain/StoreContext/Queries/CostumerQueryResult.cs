using System;

namespace LS.Domain.StoreContext.Queries
{
    public class CostumerQueryResult
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
    }
}