using System;

namespace Rtml.Server
{
    public class ReceivedEventArgs : EventArgs
    {
        public ReceivedEventArgs(bool isBinary)
        {
            this.IsBinary = isBinary;
        }

        public ReceivedEventArgs(bool isBinary, object data)
        {
            this.Data = data;
            this.IsBinary = isBinary;
        }

        public object Data
        {
            get;
            set;
        }

        public bool IsBinary
        {
            get;
            private set;
        }
    }
}
