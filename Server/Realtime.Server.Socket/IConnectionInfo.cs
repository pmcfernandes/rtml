using System;

namespace Rtml.Server
{
    public interface IConnectionInfo
    {
        Guid UniqueID
        {
            get;
        }

        string Host
        {
            get;
        }

        string Route
        {
            get;
        }

        string IP
        {
            get;
        }

        int Port
        {
            get;
        }
    }
}
