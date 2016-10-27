using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security.Principal;
using System.IO;

namespace Black_Hotspot
{
    public partial class Main : Form
    {
        string path;
        bool connect = false;

        public Main()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            pwd.PasswordChar = '#';

            string curr = Directory.GetCurrentDirectory();
            path = curr + "\\conf.txt";
            //MessageBox.Show(path, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (!File.Exists(path))
            {
                // Create a file to write to.
                StreamWriter sw = File.CreateText(path);
            }
            else
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    string s = "";
                    s = sr.ReadLine();
                    hname.Text = s;
                    s = sr.ReadLine();
                    pwd.Text = s;
                }
            }
        }

        public static bool IsAdmin()
        {
            WindowsIdentity id = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(id);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        public void Start()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = true;
            startInfo.CreateNoWindow = true;
            startInfo.WorkingDirectory = Environment.CurrentDirectory;
            startInfo.FileName = System.Windows.Forms.Application.ExecutablePath;
            startInfo.Verb = "runas";
            try
            {
                Process p = Process.Start(startInfo);
            }
            catch
            {

            }

            System.Windows.Forms.Application.Exit();
        }


        private void Start_Stop_Click(object sender, EventArgs e)
        {
            string ssid = hname.Text, key = pwd.Text;

            if (!connect)
            {
                if (String.IsNullOrEmpty(hname.Text))
                {
                    MessageBox.Show("Hotspot Name cannot be left blank !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (pwd.Text == null || pwd.Text == "")
                    {
                        MessageBox.Show("Password cannot be left blank !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (key.Length < 8)
                        {
                            MessageBox.Show("Password should be more than or equal to 8 !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            Hotspot(ssid, key, true);
                            hname.Enabled = false;
                            pwd.Enabled = false;
                            Start_Stop.Text = "Stop";
                            connect = true;
                        }
                    }
                }
            }
            else
            {
                Hotspot(null, null, false);
                hname.Enabled = true;
                pwd.Enabled = true;
                Start_Stop.Text = "Start";
                connect = false;
            }
        }

        private void Hotspot(string ssid, string key, bool status)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe");
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.CreateNoWindow = true;
            processStartInfo.UseShellExecute = false;
            Process process = Process.Start(processStartInfo);

            if (process != null)
            {
                if (status)
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine(ssid);
                        sw.Write(key);
                    }
                    process.StandardInput.WriteLine("netsh wlan set hostednetwork mode=allow ssid=" + ssid + " key=" + key);
                    process.StandardInput.WriteLine("netsh wlan start hosted network");
                    process.StandardInput.Close();
                }
                else
                {
                    process.StandardInput.WriteLine("netsh wlan stop hostednetwork");
                    process.StandardInput.Close();
                }
            }
        }

        private void hint_CheckedChanged(object sender, EventArgs e)
        {
            if (hint.Checked == false)
            {
                hint.Text = "Show";
                pwd.PasswordChar = '#';
            }
            else
            {
                hint.Text = "Hide";
                pwd.PasswordChar = '\0';
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            if (!IsAdmin())
            {
                Start();
            }
        }

        //private void Main_Closed(object sender, EventArgs e)
        //{
            //MessageBox.Show("aaaa");
            //Hotspot(null, null, false);
            //Application.Exit();
        //}
    }
}
