using FluentResults;

namespace CodeTest.Domain.FluentErrors
{
    public class NotFoundError : Error
    {
        public NotFoundError(string message) : base(message)
        {
        }
    }
}