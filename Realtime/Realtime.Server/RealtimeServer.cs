using SuperWebSocket;
using System;
using System.Collections.Generic;

namespace Realtime.Server
{
    public class RealtimeServer : WebSocketServer<RealtimeSession>
    {

        public RealtimeServer()
        {
            this.NewSessionConnected += RealtimeServer_NewSessionConnected;
            this.NewMessageReceived += RealtimeServer_NewMessageReceived;
        }

        void RealtimeServer_NewMessageReceived(RealtimeSession session, string value)
        {
           
        }

        void RealtimeServer_NewSessionConnected(RealtimeSession session)
        {
            this.RegisterSession(session.SessionID, session);
        }

    }
}
