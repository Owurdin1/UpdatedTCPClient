using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace tcpClientUpdate
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            Classes.ConnectClass connClass = new Classes.ConnectClass();
            Classes.SendReceiveClass sendClass = new Classes.SendReceiveClass();
            Classes.StateSaverClass stateSaver = new Classes.StateSaverClass();
            stateSaver.serverIP = ipTextbox.Text;
            stateSaver.numMessages = msgCountTextbox.Text;
            stateSaver.pace = paceTextbox.Text;
            stateSaver.path += logNameTextbox.Text;

            stateSaver.sock = connClass.Connect(ipTextbox.Text);
            //stateSaver.sock.ReceiveTimeout = 4000;
            sendClass.Begin(stateSaver);
        }
    }
}
