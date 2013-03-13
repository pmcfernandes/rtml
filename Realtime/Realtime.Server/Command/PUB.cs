using SuperWebSocket.SubProtocol;
using System.Threading.Tasks;

namespace Realtime.Server.Command
{
    public class PUB : SubCommandBase<RealtimeSession>
    {
        public override void ExecuteCommand(RealtimeSession session, SubRequestInfo requestInfo)
        {
            string route = session.Path;

            Parallel.ForEach<RealtimeSession>(session.AppServer.GetSessions((s) =>
            {
                return s.Path == route;
            }), (ss) =>
            {

                ss.Send(requestInfo.Body);

            });
        }
    }
}
