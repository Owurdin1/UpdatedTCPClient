using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace tcpClientUpdate.Classes
{
    class ConnectClass
    {
        // Private const global variables
        private const int PORT = 2605;

        public Socket Connect(string ipAddress)
        {
            Socket sock = new Socket(AddressFamily.InterNetwork, 
                SocketType.Stream, ProtocolType.Tcp);

            try
            {
                sock.Connect(IPAddress.Parse(ipAddress), PORT);

                sock.SetSocketOption(SocketOptionLevel.Tcp, 
                    SocketOptionName.NoDelay, true);

                //System.Windows.Forms.MessageBox.Show("Connected!");
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }

            return sock;
        }
    }
}
