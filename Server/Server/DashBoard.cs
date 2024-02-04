using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
namespace Server
{
    public partial class DashBoardForm : Form
    {

        TcpListener server;
        TcpListener klogServer;
        TcpListener ShareScreenServer;
        TcpListener FileTransServer;
        Thread Listen;
        TcpClient client;
        TcpClient klogClient;
        TcpClient ShareScreenClient;
        TcpClient FileTransClient;

        public DashBoardForm()
        {
            server = new TcpListener(IPAddress.Any, 9000);
            klogServer = new TcpListener(IPAddress.Any, 9001);
            ShareScreenServer = new TcpListener(IPAddress.Any, 9002);
            FileTransServer = new TcpListener(IPAddress.Any, 9003);


            CheckForIllegalCrossThreadCalls = false;

            Listen = new Thread(ListenFunc);
            Listen.IsBackground = true;
            Listen.Start();

            InitializeComponent();
        }



        void ListenFunc()
        {
            try
            {
                server.Start();
                klogServer.Start();
                ShareScreenServer.Start();
                FileTransServer.Start();
                while (true)
                {
                    client = server.AcceptTcpClient();
                    klogClient = klogServer.AcceptTcpClient();
                    ShareScreenClient = ShareScreenServer.AcceptTcpClient();
                    FileTransClient = FileTransServer.AcceptTcpClient();

                    ConnectBx.Text += "Connected to " + client.Client.RemoteEndPoint.ToString() + "\r\n";
                    Thread t = new Thread(ClientThread);
                    t.IsBackground = true;
                    t.Start();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Listen end.");
                StopListen();
                MessageBox.Show(ex.Message);
            }
        }

        void StopListen()
        {
            ShareScreenServer.Stop();
            server.Stop();
            klogServer.Stop();
            FileTransServer.Stop();
            if (Listen.IsAlive)
                Listen.Abort();
        }

        void ClientThread()
        {
            try
            {
                string clientID = client.Client.RemoteEndPoint.ToString();
                Form manageForm = new ManageForm(klogClient, ShareScreenClient, client, FileTransClient, clientID);
                manageForm.Show();
                Application.Run();
            }

            catch (Exception e)
            {
                MessageBox.Show("Client end connect");
                MessageBox.Show(e.Message);
                
            }


        }
        private void DashBoardForm_Load(object sender, EventArgs e)
        {
            

        }

        private void DashBoardForm_Load_1(object sender, EventArgs e)
        {

        }
    }
}