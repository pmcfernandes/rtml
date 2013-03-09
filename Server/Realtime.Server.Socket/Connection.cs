using System;
using System.Collections.Generic;

namespace Rtml.Server
{
    public class Connection : IConnection
    {
        public event EventHandler<ReceivedEventArgs> Received;
        public event EventHandler<ErrorEventArgs> Error;
        public event EventHandler<EventArgs> Opened;
        public event EventHandler<EventArgs> Closed;

        private const int size = 1024 * 4;

        public Connection(ISocket socket)
        {
            this.Socket = socket;
        }

        public ISocket Socket 
        { 
            get; 
            set; 
        }

        private ITransfer Transfer
        {
            get;
            set;
        }

        public IConnectionInfo ConnectionInfo 
        { 
            get;
            set;
        }

        public void Start()
        {
            this.Read(new List<byte>(size), new byte[size]);
        }

        private void Read(List<byte> data, byte[] buffer)
        {
            if (!this.Socket.Connected)
            {
                return;
            }

            throw new NotImplementedException();
        }

        public void Send(string message)
        {
            if (!this.Socket.Connected)
            {
                return;
            }

            this.Send(this.Transfer.Text(message));
        }

        public void Send(byte[] message)
        {
            if (!Socket.Connected)
            {
                return;
            }

            try
            {
                this.Socket.Send(this.Transfer.Binary(message));
            }
            catch (Exception ex)
            {
                this.Close();
            }            
        }

        public void Close(int code)
        {
            if (this.Transfer.Destroy().Length != 0) this.Send(this.Transfer.Destroy());

            this.Close();
        }

        public void Close()
        {
            if (this.Socket == null)
            {
                return;
            }

            this.Socket.Close();
            this.Socket.Dispose();
        }
    }
}
