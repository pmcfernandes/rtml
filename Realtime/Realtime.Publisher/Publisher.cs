// Publisher.cs

// Copyright (C) 2013 Pedro Fernandes

// This program is free software; you can redistribute it and/or modify it under the terms of the GNU 
// General Public License as published by the Free Software Foundation; either version 2 of the 
// License, or (at your option) any later version.

// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without 
// even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See 
// the GNU General Public License for more details. You should have received a copy of the GNU 
// General Public License along with this program; if not, write to the Free Software Foundation, Inc., 59 
// Temple Place, Suite 330, Boston, MA 02111-1307 USA

using Realtime.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Realtime.Publisher
{
    public class Publisher : IPublisher, IDisposable
    {
        private WebSocket4Net.WebSocket _socket;
        private ServerConfig _config;

        /// <summary>
        /// Initializes a new instance of the <see cref="Subscriber" /> class.
        /// </summary>
        public Publisher()
        {
            _config = new ServerConfig() {
                Host = "localhost",
                Port = 8080,
                Route = "/",
                Debug = true
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Subscriber" /> class.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="config">The config.</param>
        public Publisher(ServerConfig config)
            : this()
        {
            this._config = config;
        }

        /// <summary>
        /// Check if the real-time connection was established
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is connected; otherwise, <c>false</c>.
        /// </returns>
        private bool IsConnected()
        {
            if (_socket == null)
            {
                return false;
            }

            return (_socket.State == WebSocket4Net.WebSocketState.Open);
        }

        /// <summary>
        /// Open a real-time connection with the server
        /// </summary>
        private void Open()
        {
            _socket = new WebSocket4Net.WebSocket(_config.ToString());
            _socket.EnableAutoSendPing = true;
            _socket.AutoSendPingInterval = (1000 * 60); // 1 Minute                                      
            _socket.Open();
        }

        /// <summary>
        /// Publishes the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="callback">The callback.</param>
        public void Publish(string message, Action<string> callback)
        {
            this.Publish(message, callback);
        }

        /// <summary>
        /// Publishes the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="callback">The callback.</param>
        public void Publish(object message, Action callback)
        {
            if (_socket == null)
            {
                this.Open();
            }

            while (!this.IsConnected())
            {
                Thread.Sleep(100);
            }

            _socket.Send("--PUBLISH " + RealtimeMessage.Stringify(new RealtimeMessage(message)));
            callback.Invoke();
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (_socket != null) _socket.Close();
            if (_socket != null) _socket = null;
            if (_config != null) _config = null;
        }
    }
}
