using LS.Shared.Commands;

namespace LS.Domain.StoreContext.Commands.CustomerCommands.Outputs
{
    public class UpdateCustomerCommandResult : ICommandResult
    {
        public UpdateCustomerCommandResult() { }

        public UpdateCustomerCommandResult(bool success, string message, object data)
        {
            Success = success;
            Message = message;
            Data = data;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}