using Dapper;
using System.Linq;
using LS.Domain.StoreContext.Entities;
using LS.Domain.StoreContext.Repositories;
using LS.Domain.StoreContext.Queries;

namespace LS.Infra.StoreContext.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly LsDataContext _context;
        private string sql = "";

        public CustomerRepository(LsDataContext context)
        {
            _context = context;
        }

        public bool CheckDocument(string document)
        {
            sql = $"SELECT CASE WHEN EXISTS (SELECT [Id] FROM [Customer] WHERE [Document] = {document}) THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END";
            return CheckBool();
        }

        public bool CheckEmail(string email)
        {
            sql = $"SELECT CASE WHEN EXISTS (SELECT [Id] FROM [Customer] WHERE [Email] = {email}) THEN CAST(1 AS BIT) ELSE CAST(0 AS BIT) END";
            return CheckBool();
        }

        private bool CheckBool()
        {
            return _context.Connection.Query<bool>(sql).FirstOrDefault();
        }

        public void Save(Customer customer)
        {
            sql = $"INSERT INTO [Customer] ([Id], [FirstName], [LastName], [Document], [Email], [Phone]) VALUES ({customer.Id}, {customer.Name.FirstName}, {customer.Name.LastName}, {customer.Document.Number}, {customer.Email.Address}, {customer.Phone})";
            _context.Connection.Execute(sql);

            foreach(var adr in customer.Addresses)
            {
                sql = $"INSERT INTO [Address] ([Id], [CustomerId], [Number], [Complement], [District], [City], [State], [Country], [ZipCode], [Type]) VALUES ({adr.Id}, {customer.Id}, {adr.Number}, {adr.Complement}, {adr.District}, {adr.City}, {adr.State}, {adr.Country}, {adr.ZipCode}, {adr.Type})";
                _context.Connection.Execute(sql);
            }
        }

        public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
        {
            sql = $"SELECT c.[Id], c.[FirstName] + ' ' + c.[LastName] AS [Name], c.[Document], COUNT(c.[Id]) AS [Orders] FROM [Customer] c INNER JOIN [Order] o ON o.[CustomerId] = c.[Id] WHERE c.[Document] = '{document}' GROUP BY c.[Id], c.[FirstName], c.[LastName], c.[Document];";
            return _context.Connection.Query<CustomerOrdersCountResult>(sql).FirstOrDefault();
        }
    }
}