using Realtime.Common;
using Realtime.Publisher;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            Noticia noticia = new Noticia();
            noticia.Noticia1 = "Estado já pagou 1000 milhões aos bancos envolvidos nos swaps";
            noticia.Resumo = "Falta apenas chegar a acordo com o Santander, com o qual decorrem negociações.";
            noticia.Descricao = "<p>O Estado já pagou cerca de 1000 milhões de euros a bancos que comercializaram swaps a empresas públicas, avançou fonte oficial do Ministério das Finanças. Este valor resultou das negociações iniciadas em Novembro de 2012 com a maioria das instituições envolvidas neste caso e representa uma poupança de perto de 500 milhões de euros face às perdas potenciais associadas aos contratos.<br /><br />Essas perdas, que só se concretizariam caso os bancos cancelassem antecipadamente os swaps ou estes atingissem a maturidade, rondavam os 1500 milhões de euros a valores actualizados (metade dos 3000 milhões de risco de prejuízo acumulado com estes produtos). Com o processo negocial aberto entre o Estado e os bancos, conseguiu-se um desconto global de cerca de 31%, o que significa que foram pagos 1000 milhões e poupados perto de 500 milhões, adiantou a mesma fonte.</p>";
            noticia.Imagem = "http://imagens3.publico.pt/imagens.aspx/369743?tp=UH&db=IMAGENS&w=749";
            noticia.Data = DateTime.Now;

            while (true)
            {
                Console.ReadLine();
                string str = noticia.Stringfy();

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
                                Debug.Assert(true, "Message sent ... Succeed");
                                Console.WriteLine("message sended sucessfuly.");
                            });
                }
            }
        }
    }
}
