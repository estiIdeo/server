using Health.Core.Types.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
