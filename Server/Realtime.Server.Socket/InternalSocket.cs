using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Rtml.Server
{
    internal class InternalSocket : ISocket
    {
        private readonly System.Net.Sockets.Socket _socket;
        private Stream _stream;

        public InternalSocket(System.Net.Sockets.Socket socket)
        {
            this._socket = socket;

            if (this._socket.Connected) this._stream = new NetworkStream(this._socket);
        }

        public bool Connected
        {
            get
            {
                return this._socket.Connected;
            }
        }

        public string IP
        {
            get
            {
                return ((IPEndPoint)this._socket.RemoteEndPoint).Address.ToString();
            }
        }

        public int Port
        {
            get
            {
                return ((IPEndPoint)this._socket.RemoteEndPoint).Port;
            }
        }

        public System.IO.Stream Stream
        {
            get
            {
                return this._stream;
            }
        }
        
        public void Close()
        {
            if (this._stream != null) this._stream.Close();
            if (this._socket != null) this._socket.Close();
        }

        public void Bind(System.Net.EndPoint endPoint)
        {
            this._socket.Bind(endPoint);
        }

        public void Listen()
        {
            this._socket.Listen(100);
        }

        public ISocket Accept()
        {
            return new InternalSocket(this._socket.Accept());
        }

        public bool Send(byte[] buffer)
        {
            return this._socket.Send(buffer) == 0;
        }

        public void Dispose()
        {
            if (this._stream != null) this._stream.Dispose();
            if (this._socket != null) this._socket.Dispose();
        }
    }
}
