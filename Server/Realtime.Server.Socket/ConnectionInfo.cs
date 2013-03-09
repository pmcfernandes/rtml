using System;

namespace Rtml.Server
{
    public class ConnectionInfo : IConnectionInfo
    {
        public ConnectionInfo()
        {
            this.UniqueID = Guid.NewGuid();
        }

        public Guid UniqueID
        {
            get;
            private set;
        }

        public string Host
        {
            get;
            private set;
        }

        public string Route
        {
            get;
            private set;
        }

        public string IP
        {
            get;
            private set;
        }

        public int Port
        {
            get;
            private set;
        }

        public static ConnectionInfo Create(HttpRequest request, string IP, int Port)
        {
            ConnectionInfo connectionInfo = new ConnectionInfo();
            connectionInfo.IP = IP;
            connectionInfo.Port = Port;
            connectionInfo.Host = request["Host"];
            connectionInfo.Route = request.Route;

            return connectionInfo;
        }
    }
}
