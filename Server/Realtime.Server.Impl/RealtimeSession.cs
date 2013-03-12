using SuperSocket.SocketBase;
using SuperWebSocket;
using System;

namespace Realtime.Server.Impl
{
    public class RealtimeSession : WebSocketSession<RealtimeSession>
    {
        protected override void OnSessionStarted()
        {
            this.Send("{ \"msg\": \"Welcome to SuperSocket Telnet Server\" }");
        }


        protected override void HandleException(Exception e)
        {
            this.Send("Application error: {0}", e.Message);
        }

        protected override void OnSessionClosed(CloseReason reason)
        {
            base.OnSessionClosed(reason);
        }
    }
}
