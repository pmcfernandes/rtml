using SuperWebSocket.SubProtocol;

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
            session.Matching = requestInfo.Body;
        }
    }
}
