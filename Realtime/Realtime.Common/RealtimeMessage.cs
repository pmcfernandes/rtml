// RealtimeMessage.cs

// Copyright (C) 2013 Pedro Fernandes

// This program is free software; you can redistribute it and/or modify it under the terms of the GNU 
// General Public License as published by the Free Software Foundation; either version 2 of the 
// License, or (at your option) any later version.

// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without 
// even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See 
// the GNU General Public License for more details. You should have received a copy of the GNU 
// General Public License along with this program; if not, write to the Free Software Foundation, Inc., 59 
// Temple Place, Suite 330, Boston, MA 02111-1307 USA

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace Realtime.Common
{
    public class RealtimeMessage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RealtimeMessage" /> class.
        /// </summary>
        /// <param name="message">The message.</param>
        public RealtimeMessage(object message)
        {
            this.Message = message;
        }

        /// <summary>
        /// Gets or sets the message.
        /// </summary>
        /// <value>
        /// The message.
        /// </value>
        public object Message
        {
            get;
            set;
        }

        /// <summary>
        /// Stringifies the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns></returns>
        public static string Stringify(RealtimeMessage message)
        {
            return Stringify(message.Message);
        }

        /// <summary>
        /// Stringifies the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns></returns>
        public static string Stringify(object data)
        {
            dynamic d = new {
                msg = data
            };

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(d);
        }
    }
}
