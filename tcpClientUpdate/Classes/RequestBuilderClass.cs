using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;

namespace tcpClientUpdate.Classes
{
    class RequestBuilderClass
    {
        public byte[] BuildRequest(StateSaverClass stateSaver)
        {
            byte[] msg = null;
            StringBuilder sb = new StringBuilder();

            sb.Append("REQ|");
            sb.Append(stateSaver.stpWatch.ElapsedMilliseconds.ToString());
            sb.Append("|RequestNo: ");
            sb.Append(stateSaver.sentCounter.ToString());
            sb.Append("|WurdingerO|19-3410|0|");
            sb.Append(Dns.GetHostAddresses(Dns.GetHostName()).Where(
                address => address.AddressFamily == 
                    AddressFamily.InterNetwork).First().ToString());
            sb.Append("|2605|");
            sb.Append(stateSaver.sock.Handle.ToString());
            sb.Append("|");
            sb.Append(stateSaver.serverIP);
            sb.Append("|2605|StudentData: ");
            sb.Append(stateSaver.sentCounter.ToString());
            sb.Append("|1|");

            msg = SetSize(sb.ToString());


            //string msgString = "REQ|" + msTime
            //    + "|RequestNo:" + i + "|WurdingerO|19-3410|" + "0|" + ip.ToString()
            //    + "|" + portNum + "|" + sock.Handle.ToString() + "|" + serverIP + "|"
            //    + serverPort + "|StudentData:" + i + "|1|";

            return msg;
        }

        private byte[] SetSize(string msgString)
        {
            byte[] msg = null;

            msg = System.Text.Encoding.ASCII.GetBytes(msgString);
            
            short msgLength = (short)msg.Length;
            byte[] bitSize = BitConverter.GetBytes(msgLength);

            byte[] sendMsg = new byte[msgLength + bitSize.Length];

            if (BitConverter.IsLittleEndian)
            {
                Array.Reverse(bitSize);
            }

            Array.Copy(bitSize, sendMsg, bitSize.Length);
            Array.Copy(msg, 0, sendMsg, bitSize.Length, msg.Length);
            //Array.Copy(msg, 0, sendMsg, 0, msgLength);

            return sendMsg;
        }
    }
}
