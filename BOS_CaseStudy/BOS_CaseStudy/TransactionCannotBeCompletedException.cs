using System;
using System.Runtime.Serialization;

namespace BOS_CaseStudy
{
    [Serializable]
    public class TransactionCannotBeCompletedException : ApplicationException
    {
        public TransactionCannotBeCompletedException()
        {
        }

        public TransactionCannotBeCompletedException(string message) : base(message)
        {
        }

        public TransactionCannotBeCompletedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TransactionCannotBeCompletedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}