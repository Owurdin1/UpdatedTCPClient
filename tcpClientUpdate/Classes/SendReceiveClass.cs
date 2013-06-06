using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace tcpClientUpdate.Classes
{
    class SendReceiveClass
    {
        // private global const variables
        private const int BUFFER_SIZE = 1024;
        private const int LENGTH_BITS = 2;

        // private global variables
        private Object sockLock = new Object();

        /// <summary>
        /// Begins the client send receive thread functions
        /// </summary>
        /// <param name="stateSaver">
        /// StateSaver class object
        /// </param>
        internal void Begin(StateSaverClass stateSaver)
        {
            //System.Windows.Forms.MessageBox.Show("Sending and receiving beginning");

            stateSaver.stpWatch.Start();

            Thread receiveThread = new Thread(delegate()
                {
                    ReceivingHandler(stateSaver);
                });

            receiveThread.Start();

            Thread sendThread = new Thread(delegate()
                {
                    ConnectionHandler(stateSaver);
                });

            sendThread.Start();

            //System.Windows.Forms.MessageBox.Show("Waiting on join");
            sendThread.Join();
            receiveThread.Join();
            stateSaver.sock.Shutdown(System.Net.Sockets.SocketShutdown.Receive);
            stateSaver.sock.Shutdown(System.Net.Sockets.SocketShutdown.Send);
            //System.Windows.Forms.MessageBox.Show("Joined threads");

            stateSaver.lb.PrintLogs(stateSaver);
        }

        private void ConnectionHandler(StateSaverClass stateSaver)
        {
            RequestBuilderClass reqBuilder = new RequestBuilderClass();
            byte[] msg;
            try
            {
                while (stateSaver.sentCounter < Convert.ToInt32(stateSaver.numMessages))
                {
                    msg = reqBuilder.BuildRequest(stateSaver);
                    stateSaver.sock.Send(msg);

                    stateSaver.lb.sentMessages.Add(msg);

                    Thread.Sleep(Convert.ToInt32(stateSaver.pace));
                    stateSaver.sentCounter++;
                }

                //System.Windows.Forms.MessageBox.Show("Finished Sending");
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
        }

        private void ReceivingHandler(StateSaverClass stateSaver)
        {
            byte[] buffer = new byte[BUFFER_SIZE];
            byte[] byteSize = new byte[LENGTH_BITS];
            int testsize = 0;

            try
            {
                while (stateSaver.receivecounter < Convert.ToInt16(stateSaver.numMessages))
                {
                    int offset = 0;
                    int size = 0;
                    int bytesRead = 0;
                    byte[] receivedMsg;

                    bytesRead = stateSaver.sock.Receive(buffer, offset, 
                        LENGTH_BITS, System.Net.Sockets.SocketFlags.None);

                    Array.Copy(buffer, offset, byteSize, 0, LENGTH_BITS);

                    if (BitConverter.IsLittleEndian)
                    {
                        Array.Reverse(byteSize);
                    }

                    size = BitConverter.ToInt16(byteSize, 0);
                    
                    
                    testsize = size;


                    offset += LENGTH_BITS;

                    bytesRead = stateSaver.sock.Receive(buffer, offset, 
                        size, System.Net.Sockets.SocketFlags.None);

                    receivedMsg = new byte[bytesRead];
                    Array.Copy(buffer, offset, receivedMsg, 0, bytesRead);

                    stateSaver.lb.receivedMessages.Add(receivedMsg);
                    stateSaver.receivecounter++;
                }

                //System.Windows.Forms.MessageBox.Show("Finished Receiving");
            }
            catch (Exception e)
            {
                testsize.ToString();
                buffer.ToString();
                e.Message.ToString();
            }
        }
    }
}
