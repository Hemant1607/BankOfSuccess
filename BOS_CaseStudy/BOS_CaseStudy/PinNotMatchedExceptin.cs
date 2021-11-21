using System;
using System.Runtime.Serialization;

namespace BOS_CaseStudy
{
    [Serializable]
    public class PinNotMatchedExceptin : ApplicationException
    {
        public PinNotMatchedExceptin()
        {
        }

        public PinNotMatchedExceptin(string message) : base(message)
        {
        }

        public PinNotMatchedExceptin(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected PinNotMatchedExceptin(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}