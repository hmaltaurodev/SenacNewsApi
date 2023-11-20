using SenacNews.Domain.Interfaces.Shared;

namespace SenacNews.Application.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult(bool success, string? message = null, object? data = null, int? statusCode = null)
        {
            Success = success;
            Message = message;
            Data = data;
            StatusCode = statusCode;
        }

        public bool Success { get; set; }

        public string? Message { get; set; }

        public object? Data { get; set; }

        public int? StatusCode { get; set; }
    }
}
