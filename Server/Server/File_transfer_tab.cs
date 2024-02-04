using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Server
{
    public partial class File_transfer_tab : Form
    {
        TcpClient FileTransferClient;
        Thread GetFile;
        NetworkStream stream;
        public File_transfer_tab()
        {
            InitializeComponent();
        }
        public File_transfer_tab(TcpClient IPclient)
        {
            InitializeComponent();
            FileTransferClient = IPclient;
            CheckForIllegalCrossThreadCalls = false;
            GetFile = new Thread(BrowseFile);
            GetFile.IsBackground = true;
            GetFile.Start();
        }

        OpenFileDialog openFileDialog;
        private void BrowseFile()
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All Files (*.*)|*.*";
            string n = string.Empty;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                tb_path_server_send.Invoke((MethodInvoker)(() => tb_path_server_send.Text = openFileDialog.FileName));
                string url = openFileDialog.FileName;
                FileInfo fi = new FileInfo(url);
                n = fi.Name;

                // Gửi tên tệp
                StreamWriter sw = new StreamWriter(FileTransferClient.GetStream());
                sw.WriteLine(n);
                sw.Flush();
            }
        }



        void EndConnect()
        {
            stream?.Close();
            FileTransferClient?.Close();
            GetFile?.Abort();
            this.Close();
        }

        private void btn_BROWSE_Click(object sender, EventArgs e)
        {
            Thread browseThread = new Thread(BrowseFile);
            browseThread.SetApartmentState(ApartmentState.STA);
            browseThread.Start();
        }

        private void btn_SEND_Click(object sender, EventArgs e)
        {
            if (openFileDialog.FileName != string.Empty)
            {
                try
                {
                    stream = FileTransferClient.GetStream();
                    FileStream fs = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);

                    long length = fs.Length;
                    byte[] buffer = new byte[1024];
                    int bytesRead = 0;

                    BinaryWriter writer = new BinaryWriter(stream);
                    writer.Write(length);

                    while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        stream.Write(buffer, 0, bytesRead);
                    }

                    stream.Flush();
                    fs.Close();

                    MessageBox.Show("File transfer completed successfully");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Please select a file to send");
            }
        }
    }
}
