// rtml.js

// Copyright (C) 2013 Pedro Fernandes

// This program is free software; you can redistribute it and/or modify it under the terms of the GNU 
// General Public License as published by the Free Software Foundation; either version 2 of the 
// License, or (at your option) any later version.

// This program is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without 
// even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See 
// the GNU General Public License for more details. You should have received a copy of the GNU 
// General Public License along with this program; if not, write to the Free Software Foundation, Inc., 59 
// Temple Place, Suite 330, Boston, MA 02111-1307 USA


var rtml = Class.create();

rtml.prototype = {
	
	/**
	 * Creates a new instance of the rtml object 
	 * 
	 * @param {string} id
	 * @param {json} options
	 * @return
	 */
	initialize: function (id, options) {						
		this.opt = {			
			host: window.location.hostname,
			port: 80,
			debug: false
		}
		
		Object.extend(this.opt, options);
		
		this.id = id;
		this.host = "ws://" + this.opt.host + ":" + this.opt.port;
	},
	
	/**
	 * Gets the id of the current customer
	 * 
	 * @return {string} id
	 */
	id: function() {
		return this.id;
	},	
	
	/**
	 * 
	 * 
	 * @return {boolean}
	 */
	connected: function() {
		if (typeof this.socket == "undefined") {
			return false;
		} else {
			return !(this.socket.readyState == 2);
		}			
	}
	
	/**
	 * Set contents to subscribe in message
	 * 
	 * @param {regex} match
	 * return
	 */
	subscribe: function(match) {
		this.match = match || "*";
		
		if (this.connected()) {
			this.destroy();
			this.open(this.channel);
		}		
	},
	
	/**
	 * Open a real-time connection with the server
	 * 
	 * @param {string} channel
	 * @return
	 */
	open: function(channel) {				
		if(!("WebSocket" in window)) {  
			console.error("WebSocket is not supported.");
			return;
		}
		
		if (channel.substring(0, 1) == "/") {
			this.channel = channel.substring(0, channel.length - 1);
		} else {
			this.channel = channel;
		}
		
		this.socket = new WebSocket(this.host + "/" + this.channel);		
		
		this.on("close", function() { 
			if (this.opt.debug) {
				console.log ("Client " + this.id + " is closed.");
			}
		});
		
		this.on("open", function()  { 
			if (this.opt.debug) {
				console.log ("Client " + this.id + " is connected to " + this.host + "/" + this.channel + ".");
			}
			
			this.send({ 
				uniqueID: this.id 
			});
			
		});		
	},
		
	/**
	 * Close the existing connection
	 * 
	 * @return
	 */
	destroy: function() {
		if (this.connected()) this.socket.close();
	},
	
	/**
	 * Send a message to the server
	 * 
	 * @param {json} msg
	 * @return
	 */
	send: function(msg) {
		if (!this.connected()) this.open(this.channel);
		
		this.socket.send(Object.toJSON(msg));
	},
	
	/**
	 * Raises an event related with the connection
	 * 
	 * @param {string} event
	 * @param {function} callback
	 * @return
	 */
	on: function(event, callback) {
		if (event == "open")    { this.socket.onopen = callback    || function() { };    }	
		if (event == "close")   { this.socket.onclose = callback   || function() { };    }
		if (event == "receive") { this.socket.onmessage = callback || function(msg) { }; }
	}
		
};