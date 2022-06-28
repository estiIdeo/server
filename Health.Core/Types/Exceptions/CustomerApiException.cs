using Health.Core.Types.Enums;

namespace Health.Core.Types.Exceptions
{
    public class CustomerApiException : Exception
    {
        public CustomerApiException(MessageTypeEnum exceptionType, string message) : base(message)
        {
            ExceptionType = exceptionType;
        }

        public MessageTypeEnum ExceptionType { get; }
    }
}
