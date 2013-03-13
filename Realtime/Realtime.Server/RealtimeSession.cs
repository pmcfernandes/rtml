using SuperSocket.SocketBase;
using SuperWebSocket;
using System;

namespace Realtime.Server
{
    public class RealtimeSession : WebSocketSession<RealtimeSession>
    {
        public string UniqueID
        {
            get { return SessionID; }
        }

        public string Route
        {
            get { return Path; }
        }

        public string Matching
        { 
            get; 
            set; 
        }

        protected override void OnSessionStarted()
        {
            this.Send("{ \"msg\": \"Welcome to Realtime Server\" }");
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
