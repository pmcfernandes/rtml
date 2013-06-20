using SuperWebSocket.SubProtocol;
using System;

namespace Realtime.Server.Command
{
    public class SUB : SubCommandBase<RealtimeSession>
    {
        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="requestInfo">The request info.</param>
        public override void ExecuteCommand(RealtimeSession session, SubRequestInfo requestInfo)
        {
            Console.WriteLine("Saving match state " + requestInfo.Body + " ... Succeed");
            session.Matching = requestInfo.Body;
        }
    }
}
