using System;

namespace Rtml.Server
{
    public interface IConnection
    {
        event EventHandler<ReceivedEventArgs> Received;
        event EventHandler<ErrorEventArgs> Error;
        event EventHandler<EventArgs> Opened;
        event EventHandler<EventArgs> Closed;

        void Send(string message);
        void Send(byte[] message);

        void Close();
        void Close(int code);

        IConnectionInfo ConnectionInfo
        {
            get;
        }
    }
}
