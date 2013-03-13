// ISubscriber.cs

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
    public interface ISubscriber
    {
        /// <summary>
        /// Gets or sets the unique ID of current customer.
        /// </summary>
        /// <value>
        /// The unique ID.
        /// </value>
        Guid UniqueID { get; set; }

        /// <summary>
        /// Check if the real-time connection was established
        /// </summary>
        /// <returns>
        /// <c>true</c> if this instance is connected; otherwise, <c>false</c>.
        /// </returns>
        bool IsConnected();

        /// <summary>
        /// Subscribes with the specified match.
        /// </summary>
        /// <param name="match">The match.</param>
        void Subscribe(string match = null);

        /// <summary>
        /// Open a real-time connection with the server
        /// </summary>
        void Open();

        /// <summary>
        /// Close the existing connection
        /// </summary>
        void Close();

        /// <summary>
        /// Sends the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        void Send(object message);

        /// <summary>
        /// Send a message to the server
        /// </summary>
        /// <param name="message">The message.</param>
        void Send(string message);

        /// <summary>
        /// Raises an event related with the connection
        /// </summary>
        /// <param name="event">The event.</param>
        /// <param name="callback">The callback.</param>
        void On(string @event, Action<RealtimeMessage> callback);
    }
}
