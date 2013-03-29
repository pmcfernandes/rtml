using SuperSocket.SocketBase;
using SuperWebSocket;
using System;

namespace Realtime.Server
{
    public class RealtimeSession : WebSocketSession<RealtimeSession>
    {
        /// <summary>
        /// Gets the unique ID.
        /// </summary>
        /// <value>
        /// The unique ID.
        /// </value>
        public string UniqueID
        {
            get { return SessionID; }
        }

        /// <summary>
        /// Gets the route.
        /// </summary>
        /// <value>
        /// The route.
        /// </value>
        public string Route
        {
            get { return Path; }
        }

        /// <summary>
        /// Gets or sets the matching.
        /// </summary>
        /// <value>
        /// The matching.
        /// </value>
        public string Matching
        { 
            get; 
            set; 
        }

        /// <summary>
        /// Called when [session started].
        /// </summary>
        protected override void OnSessionStarted()
        {
            this.Send("{ \"msg\": \"Welcome to Realtime Server\" }");
        }

        /// <summary>
        /// Handles the exception.
        /// </summary>
        /// <param name="e">The e.</param>
        protected override void HandleException(Exception e)
        {
            this.Send("Application error: {0}", e.Message);
        }

        /// <summary>
        /// Called when [session closed].
        /// </summary>
        /// <param name="reason">The reason.</param>
        protected override void OnSessionClosed(CloseReason reason)
        {
            base.OnSessionClosed(reason);
        }
    }
}
