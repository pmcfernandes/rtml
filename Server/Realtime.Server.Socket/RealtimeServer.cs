using System;
using System.Net;
using System.Net.Sockets;

namespace Rtml.Server
{
    public class RealtimeServer : IRealtimeServer
    {
        public RealtimeServer()
        {

        }

        public RealtimeServer(string host, int port)
            : this()
        {
            this.Host = host;
            this.Port = port;

            System.Net.Sockets.Socket socket = new System.Net.Sockets.Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            this.Listener = new InternalSocket(socket);
        }

        public string Host
        {
            get;
            set;
        }

        public int Port 
        { 
            get; 
            set; 
        }

        public ISocket Listener 
        {
            get;
            set;
        }

        public void Start(Action<IConnection> config)
        {
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, this.Port);
            this.Listener.Bind(endPoint);
            this.Listener.Listen();

            throw new NotImplementedException();
        }

        public void Dispose()
        {
            this.Listener.Dispose();
        }
    }
}
