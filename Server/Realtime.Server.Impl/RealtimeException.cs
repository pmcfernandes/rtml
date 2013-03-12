// RealtimeException.cs

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
using System.Runtime.Serialization;

namespace Realtime.Server
{
    public class RealtimeException : Exception
    {

        #region Inherited Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RealtimeException"/> class.
        /// </summary>
        public RealtimeException()
            : base()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RealtimeException"/> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public RealtimeException(string message)
            : base(message)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RealtimeException"/> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference (Nothing in Visual Basic) if no inner exception is specified.</param>
        public RealtimeException(string message, Exception innerException)
            : base(message, innerException)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RealtimeException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
        public RealtimeException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="RealtimeException"/> class.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        public RealtimeException(int statusCode)
            : base()
        {
            this.StatusCode = statusCode;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RealtimeException"/> class.
        /// </summary>
        /// <param name="statusCode">The status code.</param>
        /// <param name="message">The message.</param>
        public RealtimeException(int statusCode, string message)
            : base(message)
        {
            this.StatusCode = statusCode;
        }

        #endregion

        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        /// <value>
        /// The status code.
        /// </value>
        public int StatusCode 
        { 
            get; 
            set; 
        }
    }
}
