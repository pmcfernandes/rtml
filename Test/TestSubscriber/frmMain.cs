using Realtime.Common;
using Realtime.Subscriber;
using System;
using System.Windows.Forms;

namespace TestSubscriber
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ISubscriber subscriber = new Subscriber(Guid.NewGuid(), new ServerConfig()
            {
                Host = "localhost",
                Port = 8081,
                Route = "/demo",
                Debug = true
            });

            subscriber.Open();
            subscriber.On("open"
                , (msg) =>
                    {
                        subscriber.Subscribe("*");
                    });

            subscriber.On("receive"
                , (msg) =>
                    {
                        if (textBox1.InvokeRequired)
                        {
                            textBox1.Invoke((MethodInvoker)delegate
                                {
                                    textBox1.Text += msg + Environment.NewLine;
                                });
                        }                                    
                    });            
        }
    }
}
