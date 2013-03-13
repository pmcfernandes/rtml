using Realtime.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Realtime.Publisher
{
    public interface IPublisher
    {
        /// <summary>
        /// Publishes the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="callback">The callback.</param>
        void Publish(string message, Action<string> callback);

        /// <summary>
        /// Publishes the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="callback">The callback.</param>
        void Publish(object message, Action callback);
    }
}
