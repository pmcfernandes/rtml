using System;
using System.Runtime.Serialization;

namespace Rtml.Server
{
    public class RealtimeException : Exception
    {

        #region Inherited Constructor

        public RealtimeException()
            : base()
        {

        }

        public RealtimeException(string message)
            : base(message)
        {

        }

        public RealtimeException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        public RealtimeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }

        #endregion

        #region Constructor

        public RealtimeException(int statusCode)
            : base()
        {
            this.StatusCode = statusCode;
        }

        public RealtimeException(int statusCode, string message)
            : base(message)
        {
            this.StatusCode = statusCode;
        }

        #endregion

        public int StatusCode 
        { 
            get; 
            set; 
        }
    }
}
