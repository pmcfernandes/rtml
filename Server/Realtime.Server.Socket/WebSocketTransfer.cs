using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rtml.Server
{
    public class WebSocketTransfer : ITransfer
    {
        public event EventHandler<ReceivedEventArgs> Received;

        private const byte END = 255;
        private const byte START = 0;
        private const int MAX = 1024 * 1024 * 5;

        public byte[] Shake(HttpRequest request)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("HTTP/1.1 101 WebSocket Protocol Handshake\r\n");
            builder.Append("Upgrade: WebSocket\r\n");
            builder.Append("Connection: Upgrade\r\n");
            builder.AppendFormat("Sec-WebSocket-Origin: {0}\r\n", request["Origin"]);
            builder.AppendFormat("Sec-WebSocket-Location: ws://{0}{1}\r\n", request["Host"], request.Route);
            builder.Append("\r\n");

            return Encoding.ASCII.GetBytes(builder.ToString());
        }

        public void Receive(List<byte> data)
        {
            while (data.Count > 0)
            {
                if (data[0] != START)
                {
                    throw new RealtimeException();
                }

                var endIndex = data.IndexOf(END);
                if (endIndex < 0)
                {
                    return;
                }

                if (endIndex > MAX)
                {
                    throw new RealtimeException();
                }

                var bytes = data.Skip(1).Take(endIndex - 1).ToArray();
                data.RemoveRange(0, endIndex + 1);

                this.OnReceived(Encoding.UTF8.GetString(bytes));
            }
        }

        public void OnReceived(string message)
        {
            if (Received != null) Received(this, new ReceivedEventArgs(false, message));
        }

        public byte[] Text(string text)
        {
            byte[] tb = Encoding.UTF8.GetBytes(text);

            var b = new byte[tb.Length + 2];
            b[0] = START;
            b[b.Length - 1] = END;

            Array.Copy(tb, 0, b, 1, tb.Length);
            return b;
        }

        public byte[] Binary(byte[] bytes)
        {
            return new byte[0];
        }

        public byte[] Destroy()
        {
            return new byte[0];
        }
    }
}
