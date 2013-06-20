using SuperWebSocket.SubProtocol;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Realtime.Server.Command
{
    public class PUB : SubCommandBase<RealtimeSession>
    {
        /// <summary>
        /// Executes the command.
        /// </summary>
        /// <param name="session">The session.</param>
        /// <param name="requestInfo">The request info.</param>
        public override void ExecuteCommand(RealtimeSession session, SubRequestInfo requestInfo)
        {
            string route = session.Path;

            Parallel.ForEach<RealtimeSession>(session.AppServer.GetSessions((s) =>
            {
                if (s.Path == route)
                {
                    Console.WriteLine("Founded a route match with " + s.Path + " ... Succeed");
                    return true;
                }
                else
                {
                    return false;
                }
            }), (ss) =>
            {
                if (session.Matching == null)
                {
                    ss.Send(requestInfo.Body);                   
                }
                else
                {
                    Regex regex = new Regex(session.Matching ?? "*", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                    if (regex.IsMatch(requestInfo.Body))
                    {
                        ss.Send(requestInfo.Body);
                    }
                }

                Console.WriteLine("Sending message with matching " + (session.Matching == null ? "*" : session.Matching) + " ... Succeed");
            });
        }
    }
}
