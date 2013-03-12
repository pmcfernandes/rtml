using SuperSocket.SocketBase.Config;
using SuperWebSocket;

namespace Realtime.Server.Impl
{
    public class RealtimeServer : WebSocketServer<RealtimeSession>
    {
        protected override bool Setup(IRootConfig rootConfig, IServerConfig config)
        {
            return base.Setup(rootConfig, config);
        }

        protected override void OnStartup()
        {
            base.OnStartup();
        }

        protected override void OnStopped()
        {
            base.OnStopped();
        }
    }
}
