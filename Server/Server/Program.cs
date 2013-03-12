using Realtime.Server.Impl;
using SuperSocket.SocketBase;
using System;

namespace Realtime.Server
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            RealtimeServer server = new RealtimeServer(); 

            if (!server.Setup(8081))
            {
                Console.WriteLine("Failed to setup!");
                Console.ReadKey();
                return;
            }

            if (!server.Start())
            {
                Console.WriteLine("Failed to start!");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("The server started successfully, press key 'q' to stop it!");

            while (Console.ReadKey().KeyChar != 'q')
            {
                Console.WriteLine();
                continue;
            }

            Console.WriteLine();
            server.Stop();

            Console.WriteLine("The server was stopped!");
        }

        static void server_SessionClosed(AppSession session, CloseReason value)
        {
            session.Send("Reason: " + value.ToString());
        }

        static void server_NewRequestReceived(AppSession session, SuperSocket.SocketBase.Protocol.StringRequestInfo requestInfo)
        {
            session.Send("Welcome to SuperSocket Telnet Server");
        }

        static void server_NewSessionConnected(AppSession session)
        {
            session.Send("Welcome");
        }
    }
}
