using SuperWebSocket.SubProtocol;

namespace Realtime.Server
{
    public class RealtimeProtocol : BasicSubProtocol<RealtimeSession>
    {
        public RealtimeProtocol()
            : base(typeof(RealtimeProtocol).Assembly)
        {
         
        }

    }
}
