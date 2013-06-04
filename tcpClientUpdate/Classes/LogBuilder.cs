using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcpClientUpdate.Classes
{
    class LogBuilder
    {
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

                // Trailer Record:
                // MMDDYYYY | HHMMSS | 0 | 0 | 0
                StringBuilder trailerSB = new StringBuilder();
                trailerSB.Append(System.DateTime.Now.ToString("MMddyyyy"));
                trailerSB.Append("|");
                trailerSB.Append(System.DateTime.Now.ToString("HHmmss"));
                trailerSB.Append("|0|0|0");
                sw.Write(trailerSB.ToString());
            }

            sw.Close();
            System.Windows.Forms.MessageBox.Show("Finished logging Received Count: " + receivedMessages.Count.ToString() + " Sent Count: " + sentMessages.Count.ToString());
        }
    }
}
