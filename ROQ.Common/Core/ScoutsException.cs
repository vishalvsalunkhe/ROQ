using System;
using System.Runtime.Serialization;

namespace ROQ.Common.Core
{
    public class ROQException : Exception
    {
        
        public ROQException()
        {

        }

        public ROQException(string message) 
            : base(message)
        {
        }

        public ROQException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        protected ROQException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}
