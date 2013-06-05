using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcpClientUpdate.Classes
{
    class LogBuilder
    {
        // private contant global variables
        private const int RECEIVE_FLAG = 0;
        private const int SEND_FLAG = 1;

        public List<byte[]> receivedMessages = new List<byte[]>();
        public List<byte[]> sentMessages = new List<byte[]>();

        public void PrintLogs(StateSaverClass stateSaver)
        {
            //string path = @"C:\Logs\ClientLog.txt";
            System.IO.StreamWriter sw = new System.IO.StreamWriter(stateSaver.path, true);
            string[] recievedStrings = new string[receivedMessages.Count];
            string[] sentStrings = new string [sentMessages.Count];
            //System.IO.StreamWriter sw = System.IO.File.AppendText(path);

            if (receivedMessages.Count == sentMessages.Count)
            {
                for (int i = 0; i < receivedMessages.Count; i++)
                {
                    string recStr = System.Text.Encoding.ASCII.GetString(receivedMessages[i]);
                    byte[] choppedRec = new byte[sentMessages[i].Length - 2];
                    Array.Copy(sentMessages[i], 2, choppedRec, 0, choppedRec.Length);

                    string sentStr = System.Text.Encoding.ASCII.GetString(choppedRec);

                    //string sentStr = System.Text.Encoding.ASCII.GetString(sentMessages[i]);

                    sw.Write(sentStr + "\n\r");
                    sw.Write(recStr + "\n\r");
                }

            }
            else
            {
                int count = receivedMessages.Count;
                int flag = RECEIVE_FLAG;
                if (count > sentMessages.Count)
                {
                    count = sentMessages.Count;
                    flag = SEND_FLAG;
                }

                for (int i = 0; i < count; i++)
                {
                    string recStr = System.Text.Encoding.ASCII.GetString(receivedMessages[i]);
                    byte[] choppedRec = new byte[sentMessages[i].Length - 2];
                    Array.Copy(sentMessages[i], 2, choppedRec, 0, choppedRec.Length);

                    string sentStr = System.Text.Encoding.ASCII.GetString(choppedRec);

                    //string sentStr = System.Text.Encoding.ASCII.GetString(sentMessages[i]);

                    sw.Write(sentStr + "\n\r");
                    sw.Write(recStr + "\n\r");

                }

                switch (flag)
                {
                    case RECEIVE_FLAG:
                        for (int i = count; i < receivedMessages.Count; i++)
                        {
                            string recStr = System.Text.Encoding.ASCII.GetString(receivedMessages[i]);
                            byte[] choppedRec = new byte[receivedMessages[i].Length - 2];
                            Array.Copy(receivedMessages[i], 2, choppedRec, 0, choppedRec.Length);
                            sw.Write(recStr + "\n\r");
                        }
                        break;

                    case SEND_FLAG:
                        for (int i = count; i < sentMessages.Count; i++)
                        {
                            string sentStr = System.Text.Encoding.ASCII.GetString(sentMessages[i]);
                            byte[] choppedRec = new byte[sentMessages[i].Length - 2];
                            Array.Copy(sentMessages[i], 2, choppedRec, 0, choppedRec.Length);
                            sw.Write(sentStr + "\n\r");
                        }
                        break;
                }

            }

            // Trailer Record:
            // MMDDYYYY | HHMMSS | 0 | 0 | 0
            StringBuilder trailerSB = new StringBuilder();
            trailerSB.Append(System.DateTime.Now.ToString("MMddyyyy"));
            trailerSB.Append("|");
            trailerSB.Append(System.DateTime.Now.ToString("HHmmss"));
            trailerSB.Append("|0|0|0");
            sw.Write(trailerSB.ToString());

            sw.Close();
            System.Windows.Forms.MessageBox.Show("Finished logging Received Count: " + receivedMessages.Count.ToString() + " Sent Count: " + sentMessages.Count.ToString());
        }
    }
}
