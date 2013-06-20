using SuperWebSocket.SubProtocol;
using System;

namespace Realtime.Server
{
    public class RealtimeProtocol : BasicSubProtocol<RealtimeSession>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RealtimeProtocol"/> class.
        /// </summary>
        public RealtimeProtocol()
            : base(typeof(RealtimeProtocol).Assembly)
        {
            Console.WriteLine("Reading protocols ... Succeed");
            Console.WriteLine("");
        }

    }
}
