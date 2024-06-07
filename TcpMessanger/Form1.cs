using Networking;
using System.Text;

namespace TcpMessanger
{
    public partial class Form1 : Form
    {
        private TcpManager _tcpManager;

        public Form1()
        {
            InitializeComponent();
            _tcpManager = new TcpManager();
            _tcpManager.Received += _tcpManager_Received;
        }

        private void _tcpManager_Received(Request request)
        {
            string message = "";
            switch (request.Path)
            {
                case "message":
                    message = Encoding.UTF8.GetString(request.Data);
                    break;

                case "name":
                    MessageBox.Show("This nickname is taken!");
                    connectBtn.Enabled = true;
                    addressTb.Enabled = true;
                    portTb.Enabled = true;
                    nameTb.Enabled = true;
                    button1.Enabled = false;
                    button2.Enabled = false;
                    break;
            }

            this.Invoke(() => listBox.Items.Add(message));
        }

        private void connectBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(nameTb.Text.Trim()))
                {
                    MessageBox.Show("Not valide nickname!");
                    return;
                }

                _tcpManager.Connect(addressTb.Text.Trim(), int.Parse(portTb.Text.Trim()));
                Request request = new Request()
                {
                    Path = "login",
                    Nickname = Encoding.UTF8.GetBytes(nameTb.Text.Trim()),
                    Data = Encoding.UTF8.GetBytes(nameTb.Text.Trim())
                };
                _tcpManager.Send(request);
                connectBtn.Enabled = false;
                addressTb.Enabled = false;
                portTb.Enabled = false;
                nameTb.Enabled = false;
                button1.Enabled = true;
                button2.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(messageTb.Text.Trim())) // Nickname validation
                {
                    MessageBox.Show("Not valide message!");
                    return;
                }

                Request request = new Request()
                {
                    Path = "message",
                    Nickname = Encoding.UTF8.GetBytes(nameTb.Text.Trim()),
                    Data = Encoding.UTF8.GetBytes(messageTb.Text.Trim())
                };
                _tcpManager.Send(request);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string path = openFileDialog.FileName;
                    using var fs = new FileStream(path, FileMode.Open, FileAccess.Read);
                    using var ms = new MemoryStream();
                    fs.CopyTo(ms);
                    Request request = new Request()
                    {
                        Path = "file",
                        Nickname = Encoding.UTF8.GetBytes(nameTb.Text.Trim()),
                        Data = ms.ToArray()
                    };
                    _tcpManager.Send(request);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
