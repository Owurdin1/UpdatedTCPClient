using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tcpClientUpdate.Classes
{
    class StateSaverClass
    {
        public System.Net.Sockets.Socket sock = null;
        public int sentCounter = 0;
        public int receivecounter = 0;
        public string numMessages = string.Empty;
        public string pace = string.Empty;
        public string serverIP = string.Empty;
        public System.Diagnostics.Stopwatch stpWatch = new System.Diagnostics.Stopwatch();
        public LogBuilder lb = new LogBuilder();
        public string path = @"C:\Logs\";
    }
}
