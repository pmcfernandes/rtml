// Subscriber.cs

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

namespace Realtime.Subscriber
{
    public class Subscriber : ISubscriber, IDisposable
    {
        private WebSocket4Net.WebSocket _socket;
        private ServerConfig _config;
        private string _match;

        /// <summary>
        /// Initializes a new instance of the <see cref="Subscriber" /> class.
        /// </summary>
        public Subscriber()
        {
            this.UniqueID = Guid.NewGuid();

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
        public Subscriber(Guid id, ServerConfig config)
            : this()
        {
            this.UniqueID = id;
            this._config = config;
        }

        /// <summary>
        /// Gets or sets the unique ID of current customer.
        /// </summary>
        /// <value>
        /// The unique ID.
        /// </value>
        public Guid UniqueID
        {
            get;
            set;
        }

        /// <summary>
        /// Check if the real-time connection was established
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is connected; otherwise, <c>false</c>.
        /// </returns>
        public bool IsConnected()
        {
            if (_socket == null)
            {
                return false;
            }

            return (_socket.State == WebSocket4Net.WebSocketState.Open);
        }

        /// <summary>
        /// Subscribes with the specified match.
        /// </summary>
        /// <param name="match">The match.</param>
        public void Subscribe(string match = null)
        {
            if (match == null)
            {
                this._match = "*";
            }
            else
            {
                this._match = match;
            }

            this.Send(new {
                subscribe = match
            });
        }

        /// <summary>
        /// Open a real-time connection with the server
        /// </summary>
        public void Open()
        {
            _socket = new WebSocket4Net.WebSocket(_config.ToString());
            _socket.EnableAutoSendPing = true;
            _socket.AutoSendPingInterval = (1000 * 60); // 1 Minute                                                  

            this.On("open"
                , (msg) =>
                    {
                        if (_config.Debug == true) Console.WriteLine(String.Format("Client {0} is connected.", this.UniqueID));
                    });

            this.On("close"
                , (msg) =>
                    {
                        if (_config.Debug == true) Console.WriteLine(String.Format("Client {0} is closed.", this.UniqueID));                
                    });

            this.On("receive"
                , (msg) =>
                    {
                        if (_config.Debug == true) Console.WriteLine(msg.Message);
                    });

            _socket.Open();
        }

        /// <summary>
        /// Close the existing connection
        /// </summary>
        public void Close()
        {
            if (this.IsConnected()) _socket.Close();            
        }

        /// <summary>
        /// Sends the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        public void Send(object message)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            if (!this.IsConnected())
            {
                this.Open();
            }

            this.Send(RealtimeMessage.Stringify(new RealtimeMessage(message)));
        }

        /// <summary>
        /// Send a message to the server
        /// </summary>
        /// <param name="message">The message.</param>
        public void Send(string message)
        {
            this.Send(message);
        }

        /// <summary>
        /// Raises an event related with the connection
        /// </summary>
        /// <param name="event">The event.</param>
        /// <param name="callback">The callback.</param>
        public void On(string @event, Action<RealtimeMessage> callback)
        {
            switch (@event.ToLower())
            {
                case "open":
                    _socket.Opened += ((sender, e)
                        =>
                            {
                                callback.Invoke(null);
                            });

                    break;

                case "close":
                    _socket.Closed += ((sender, e)
                        =>
                            {
                                callback.Invoke(null);
                            });

                    break;

                case "receive":
                    _socket.MessageReceived += ((sender, e)
                        =>
                            {
                                callback.Invoke(new RealtimeMessage(e.Message));
                            });

                    break;
            }
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
