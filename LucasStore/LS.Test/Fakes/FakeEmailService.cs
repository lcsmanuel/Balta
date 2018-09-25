using LS.Domain.StoreContext.Services;

namespace LS.Test.Fakes
{
    public class FakeEmailService : IEmailService
    {
        public void Send(string to, string from, string subject, string body) { }
    }
}