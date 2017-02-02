using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Black_Hotspot
{
    public partial class Main : Form
    {
        hotspot bh = null;
        bool isStarted = false;
        string path;

        public Main()
        {
            bh = new hotspot();
            this.FormClosing += Form1_FormClosing;
            InitializeComponent();
            txtPass.PasswordChar = '*';

            string curr = Directory.GetCurrentDirectory();
            path = curr + "\\conf";
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
                    txtSSID.Text = s;
                    s = sr.ReadLine();
                    txtPass.Text = s;
                }
            }
        }

        public static bool IsAdmin()
        {
            WindowsIdentity id = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(id);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);
        }

        public void StartAdmin()
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

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!IsAdmin())
            {
                StartAdmin();
            }
            bh.Stop();
            populateConnections();
        }

        public void populateConnections()
        {
            cmbConnection.Items.Clear();
            bh.GetConnections().ForEach(conProp => { cmbConnection.Items.Add(conProp); });
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isStarted)
            {
                MessageBox.Show("Hotspot stopped !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bh.Stop();
                /*
                DialogResult dr = MessageBox.Show("Black hotspot akan stop, sure ke ni?", "Warning!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                if (dr == DialogResult.Cancel)
                {
                    e.Cancel = true;
                    return;
                }
                else if (dr == DialogResult.OK)
                {
                    bh.Stop();
                }
                */
            }

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnSS_Click(object sender, EventArgs e)
        {
            if (!isStarted)
            {
                if (String.IsNullOrEmpty(txtSSID.Text))
                {
                    MessageBox.Show("Cannot Blank !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    if (String.IsNullOrEmpty(txtPass.Text))
                    {
                        MessageBox.Show("Cannot Blank !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (txtPass.TextLength < 8)
                        {
                            MessageBox.Show("Password length >= 8 !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            bh.Create(txtSSID.Text, txtPass.Text);
                            bh.Start();
                            populateConnections();
                            btnSS.Text = "Stop";
                            lblStatus.Text = bh.Status;
                            isStarted = true;

                            using (StreamWriter sw = File.CreateText(path))
                            {
                                sw.WriteLine(txtSSID.Text);
                                sw.Write(txtPass.Text);
                            }
                        }
                    }
                }

            }
            else
            {
                bh.Stop();
                populateConnections();
                btnSS.Text = "Start";
                lblStatus.Text = bh.Status;
                isStarted = false;
            }


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnShare_Click(object sender, EventArgs e)
        {
            bh.ShareInternet("Ethernet", cmbConnection.SelectedItem.ToString(), true);
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void rdHide_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.PasswordChar = '*';
        }

        private void rdShow_CheckedChanged(object sender, EventArgs e)
        {
            txtPass.PasswordChar = '\0';
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }


    }
}
