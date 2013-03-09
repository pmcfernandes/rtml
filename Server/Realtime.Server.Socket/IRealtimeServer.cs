using System;

namespace Rtml.Server
{
    public interface IRealtimeServer
    {
        void Start(Action<IConnection> config);
    }
}
