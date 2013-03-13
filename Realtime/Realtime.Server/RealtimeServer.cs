using SuperWebSocket;

namespace Realtime.Server
{
    public class RealtimeServer : WebSocketServer<RealtimeSession>
    {
        public RealtimeServer()
            : base(new RealtimeProtocol())
        {
            this.NewSessionConnected += RealtimeServer_NewSessionConnected;

        }

        void RealtimeServer_NewSessionConnected(RealtimeSession session)
        {
            this.RegisterSession(session.SessionID, session);
        }
    }
}
