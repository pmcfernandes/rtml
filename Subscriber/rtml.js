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
	 * @param {string} id       Unique identifier for client
	 * @param {json}   options  Server connections options
	 * @return
	 * 
	 * <code>
	 *    var subscriber = new rtml('B3CD21CE-3A52-4F8E-904D-2BB80E44FFD6', { host: 'www.pfernandes.pt', port: 8080, debug: true });
	 * </code>
	 */
	initialize: function (uniqueID, options) {						
		this._opt = {			
			host: window.location.hostname,			
			port: 80,
			route: '/',
			debug: false
		}
		
		Object.extend(this._opt, options);
		
		this._uniqueID = uniqueID;
		this._host = "ws://" + this._opt.host + ":" + this._opt.port;
	},
	
	/**
	 * Gets the id of the current customer
	 * 
	 * @return {string} id  
	 * 
	 * <code>
	 *    var subscriber = new rtml(...); (...)
	 *    alert(subscriber.id()); 
	 * </code>
	 */
	uniqueID: function() {
		return this._uniqueID;
	},	
	
	/**
	 * Check if the real-time connection was established
	 * 
	 * @return {boolean}  
	 * 
	 * <code>
	 *    var subscriber = new rtml(...); (...)
	 *    alert(subscriber.connected()); 
	 * </code>
	 */
	connected: function() {
		if (!this._socket) {
			return false;
		} else {
			return !(this._socket.readyState == 2);
		}			
	},
	
	/**
	 * Set contents to subscribe in message
	 * 
	 * @param {regex} match    Regular expression to filter messages
	 * return {string}
	 * 
	 * <code>
	 *    var subscriber = new rtml(...);
	 *    subscriber.open('/realtime/server');
	 * 	  subscriber.on('open', function() {
	 *			subscriber.subscribe(/\[A-Z]\);
	 *	  });
	 * </code>
	 */
	subscribe: function(match) {
		if (typeof match == 'undefined') {
			return this._match;
		}
	
		this._match = match || "*";
		this.send({
			msg: {
				match: match
			}
		});
	},
	
	/**
	 * Open a real-time connection with the server
	 * 
	 * @return
	 * 
	 * <code>
	 *    var subscriber = new rtml(...);
	 *    subscriber.open('/realtime/server');
	 * </code>
	 */
	open: function() {	
		var _debug = this._opt.debug;
		var _id = this.uniqueID();
		
		if(!("WebSocket" in window)) {  
			console.error("WebSocket is not supported.");
			return;
		}
			
		this._socket = new WebSocket(this._host + this._opt.route);		
				
		this.on("close", function() { 
			if (_debug == true) {
				console.log ("Client " + _id + " is closed.");
			}
		});
		
		this.on('receive', function(msg) {
			console.log(msg);
		});
		
		this.on("open", function() {
			if (_debug == true) {
				console.log ("Client " + _id + " is connected.");
			}
			
			this.send({
				msg: {
					uniqueID: _id
				}
			});
			
		});		
	},
		
	/**
	 * Close the existing connection
	 * 
	 * @return
	 * 
	 * <code>
	 *    var subscriber = new rtml(...); (...)
	 *    subscriber.destroy();
	 * </code>	 
	 */
	destroy: function() {
		if (this.connected()) this._socket.close();
	},
	
	/**
	 * Send a message to the server
	 * 
	 * @param {json} msg   Message to send to server
	 * @return
	 * 
	 * <code>
	 *    var subscriber = new rtml(...);
	 *    subscriber.open('/realtime/server');
	 *    subscriber.send({
	 *    	msg: {
	 *    		(...)
	 *    	}
	 *    })
	 * </code>	 
	 */
	send: function(msg) {
		if (!this.connected()) this.open();
		
		this._socket.send(Object.toJSON(msg));
	},
	
	/**
	 * Raises an event related with the connection
	 * 
	 * @param {string}   event     Event want to fire
	 * @param {function} callback  Function that returns the server response
	 * @return
	 * 
	 * <code>
	 *    var subscriber = new rtml(...); (...)
	 *    subscriber.open('/realtime/server');
	 *    subscriber.on('receive', function(msg) { 
	 *    	(...) 
	 *    });
	 *    subscriber.on('open', function()  { 
	 *    	(...) 
	 *    });
	 *    subscriber.on('close', function() { 
	 *    	(...) 
	 *    });
	 * </code>		 
	 */
	on: function(event, callback) {	
		if (event == "open") { 
			this._socket.onopen = function() { 
				callback();
			};    
		}	
		
		if (event == "close") { 
			this._socket.onclose = function() { 
				callback();
			};    
		}
		
		if (event == "receive") { 
			this._socket.onmessage = function(msg) { 				
				callback(msg.data.toString().evalJSON());
			}; 
		}
	}
		
};