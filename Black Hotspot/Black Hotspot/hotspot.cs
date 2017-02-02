using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Black_Hotspot
{
    class hotspot
    {
        ProcessStartInfo ps = null;
        private dynamic netSharingManager = null;
        private dynamic everyConnections = null;
        private bool hasNetSharingManager = false;
        
        private string message = "";
        public hotspot()
        {
            Init();
        }

        private void Init()
        {
            ps = new ProcessStartInfo("cmd.exe");
            ps.UseShellExecute = false;
            ps.RedirectStandardOutput = true;
            ps.CreateNoWindow = true;
            ps.FileName = "netsh";

            netSharingManager = Activator.CreateInstance(Type.GetTypeFromProgID("HNetCfg.HnetShare.1"));

            if (netSharingManager == null)
            {
                this.message = "HNetCfg.HnetShare.1 was not found! \n";
                hasNetSharingManager = true;
            }
            else
            {
                hasNetSharingManager = false;
            }

            if (netSharingManager.SharingInstalled == false )
            {
                this.message = "Sharing not available! \n";
                hasNetSharingManager = false;
            }
            else
            {
                hasNetSharingManager = true;
            }

            if (hasNetSharingManager)
            {
                everyConnections = netSharingManager.EnumEveryConnection;
            }
        }


        public List<String> GetConnections()
        {

            dynamic everyConnection = null;
            dynamic connectionProp = null;
            everyConnections = netSharingManager.EnumEveryConnection;
            List<String> connections = new List<string>();

            foreach (dynamic conn in everyConnections)
            {
                everyConnection = netSharingManager.INetSharingConfigurationForINetConnection(conn);
                connectionProp = netSharingManager.NetConnectionProps(conn);
                connections.Add(connectionProp.Name);
            }
            return connections;
        }

        public void ShareInternet(string pubConnectionName, string priConnectionName, bool isEnabled)
        {
            dynamic everyConnection = null;
            dynamic connectionProp = null;
            everyConnections = netSharingManager.EnumEveryConnection;

            foreach (dynamic conn in everyConnections)
            {
                everyConnection = netSharingManager.INetSharingConfigurationForINetConnection(conn);
                connectionProp = netSharingManager.NetConnectionProps(conn);

                if(connectionProp.Name == pubConnectionName)
                {
                    //this.message += string.Format("Setting ICS Public {0} on connection: {1}",isEnabled, pubConnectionName);
                    if (isEnabled)
                    {
                        everyConnection.EnableSharing(0);
                    }
                    else
                    {
                        everyConnection.DisableSharing();
                    }
                }

                if (connectionProp.Name == priConnectionName)
                {
                    //this.message += string.Format("Setting ICS Private {0} on connection: {1}", isEnabled, priConnectionName);
                    if (isEnabled)
                    {
                        everyConnection.EnableSharing(1);
                    }
                    else
                    {
                        everyConnection.DisableSharing();
                    }
                }
            }
        }

        public void Start()
        {
            ps.Arguments = "wlan start hostednetwork";
            Execute(ps);

        }

        public void Stop()
        {
            ps.Arguments = "wlan stop hostednetwork";
            Execute(ps);
        }

        public void Create(string ssid, string pass)
        {
            ps.Arguments = String.Format("wlan set hostednetwork mode=allow ssid={0} key={1}",ssid,pass);
            Execute(ps); 
        }

        private void Execute(ProcessStartInfo ps)
        {
            message = "";
            try
            {
                using (Process p = Process.Start(ps))
                {
                    message += p.StandardOutput.ReadToEnd();
                    p.WaitForExit();
                }
            }
            catch(Exception e)
            {
                message = "";
                message += e.Message;
            }
        }

        public string Status
        {
            get
            {
                return this.message;
            }
            set
            {
                this.message = value;
            }
        }
    }
}
