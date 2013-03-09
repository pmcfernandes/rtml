using System;

namespace Rtml.Server
{
    public class ErrorEventArgs : EventArgs
    {
        public ErrorEventArgs()
        {

        }

        public ErrorEventArgs(int statusCode)
            : this()
        {
            this.StatusCode = statusCode;
        }

        public int StatusCode
        {
            get;
            set;
        }
    }
}
