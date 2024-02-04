using System;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;

namespace Server
{
    public partial class HenGio : Form
    {
        NetworkStream hengioStream;
        public HenGio(NetworkStream mainStream, string ID)
        {
            InitializeComponent();
            hengioStream = mainStream;
            this.Name += ' ' + ID;
            this.Text += ' ' + ID;
        }
        private void btnShutdown_Click(object sender, EventArgs e)
        {
            try
            {
                decimal secondtoShutdown = (Hour.Value) * 3600 + (Minute.Value) * 60 + Second.Value;
                string command = "shutdown -s -t " + secondtoShutdown.ToString();
                Byte[] ShutdownCommand = Encoding.ASCII.GetBytes(command);
                hengioStream.Write(ShutdownCommand, 0, ShutdownCommand.Length);
                MessageBox.Show("Client sẽ tắt máy sau " + secondtoShutdown.ToString() + "s");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                string command = "shutdown -a";
                Byte[] CancelShutdownCommand = Encoding.ASCII.GetBytes(command);
                hengioStream.Write(CancelShutdownCommand, 0, CancelShutdownCommand.Length);
                MessageBox.Show("Đã hủy tắt máy");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        private void HenGio_Load(object sender, EventArgs e)
        {

        }
    }
}