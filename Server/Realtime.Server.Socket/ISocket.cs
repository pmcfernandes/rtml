using System.IO;
using System.Net;

namespace Rtml.Server
{
    public interface ISocket
    {
        bool Connected
        {
            get;
        }

        string IP
        {
            get;
        }

        int Port
        {
            get;
        }

        Stream Stream
        {
            get;
        }

        void Bind(EndPoint endPoint);

        void Close();
        
        void Listen();

        bool Send(byte[] buffer);
        
        void Dispose();
    }
}
