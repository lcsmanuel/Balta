using LS.Domain.StoreContext.Services;

namespace LS.Infra.StoreContext.Services
{
    public class EmailService : IEmailService
    {
        public void Send(string to, string from, string subject, string body) { }
    }
}