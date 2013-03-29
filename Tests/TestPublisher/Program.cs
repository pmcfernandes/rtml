using Realtime.Common;
using Realtime.Publisher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestPublisher
{
    class Program
    {
        /// <summary>
        /// Mains the specified args.
        /// </summary>
        /// <param name="args">The args.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("The publisher started successfully, press key 'ctrl+c' to stop it!");

            while (true)
            {
                string str = Console.ReadLine();

                using (Publisher pub = new Publisher(new ServerConfig()
                {
                    Host = "localhost",
                    Port = 8081,
                    Route = "/demo",
                    Debug = true
                }))
                {
                    pub.Publish(str
                        , () =>
                            {
                                Console.WriteLine("message sended sucessfuly.");
                            });
                }
            }
        }
    }
}
