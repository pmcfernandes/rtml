using SuperWebSocket;

namespace Realtime.Server
{
    public class RealtimeServer : WebSocketServer<RealtimeSession>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RealtimeServer"/> class.
        /// </summary>
        public RealtimeServer()
            : base(new RealtimeProtocol())
        {
            this.NewSessionConnected += RealtimeServer_NewSessionConnected;

        }

        /// <summary>
        /// Realtimes the server_ new session connected.
        /// </summary>
        /// <param name="session">The session.</param>
        void RealtimeServer_NewSessionConnected(RealtimeSession session)
        {
            this.RegisterSession(session.SessionID, session);
        }
    }
}
