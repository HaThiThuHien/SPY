using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class ShareScreenForm : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        Thread ShowThread;

        public ShareScreenForm(TcpClient ssclient)
        {
            client = ssclient;
            ShowThread = new Thread(ScreenShow);
            ShowThread.Start();
            ShowThread.IsBackground = true;

            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
        }

        private void ScreenShow()
        {
            
            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();

                while (client.Connected && Thread.CurrentThread.IsAlive)
                { 
                    stream = client.GetStream();
                    ScreenPicture.Image = (Image)binaryFormatter.Deserialize(stream);
                }
            }
            catch
            {
                MessageBox.Show("Client disconnected");
                EndConnect();
            }
        }

        void EndConnect()
        {
           if (client != null)
            {
                client.Close();
                client = null;
            }
            if (stream != null)
            {
                stream.Close();
                stream = null;
            }
            if (ShowThread != null)
            {
                ShowThread.Abort();
                ShowThread = null;
            }
            this.Close();
        }   
    }
}
