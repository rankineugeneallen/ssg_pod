using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSGPodRetrieval.model
{
    public class Connect
    {
        public Connect(string username, string password, string connType)
        {
            this.username = username;
            this.password = password;
            setConnType(connType);
        }

        public string ip { get; set; }
        
        public string username { get; set; }
        public string password { get; set; }

        //External
        //Eraserhead
        //Pi
        private void setConnType(string connTypeStr) 
        {
            switch (connTypeStr)
            {
                case "External":
                    ip = Properties.Settings.Default.externalDBIP;
                    break;
                case "Eraserhead":
                    ip = Properties.Settings.Default.localDBIPe;
                    break;
                case "Pi":
                    ip = Properties.Settings.Default.localDBIP;
                    break;
                default:
                    ip = null;
                    break;
            }
        }
    }
}
