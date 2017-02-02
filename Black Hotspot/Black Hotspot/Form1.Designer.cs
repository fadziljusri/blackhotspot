namespace Black_Hotspot
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnSS = new System.Windows.Forms.Button();
            this.key = new System.Windows.Forms.Label();
            this.pass = new System.Windows.Forms.Label();
            this.txtSSID = new System.Windows.Forms.TextBox();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnShare = new System.Windows.Forms.Button();
            this.cmbConnection = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdHide = new System.Windows.Forms.RadioButton();
            this.rdShow = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSS
            // 
            this.btnSS.Location = new System.Drawing.Point(6, 125);
            this.btnSS.Name = "btnSS";
            this.btnSS.Size = new System.Drawing.Size(248, 23);
            this.btnSS.TabIndex = 0;
            this.btnSS.Text = "Start";
            this.btnSS.UseVisualStyleBackColor = true;
            this.btnSS.Click += new System.EventHandler(this.btnSS_Click);
            // 
            // key
            // 
            this.key.AutoSize = true;
            this.key.Location = new System.Drawing.Point(8, 36);
            this.key.Name = "key";
            this.key.Size = new System.Drawing.Size(75, 13);
            this.key.TabIndex = 1;
            this.key.Text = "Hotspot Name";
            this.key.Click += new System.EventHandler(this.label1_Click);
            // 
            // pass
            // 
            this.pass.AutoSize = true;
            this.pass.Location = new System.Drawing.Point(8, 62);
            this.pass.Name = "pass";
            this.pass.Size = new System.Drawing.Size(53, 13);
            this.pass.TabIndex = 2;
            this.pass.Text = "Password";
            // 
            // txtSSID
            // 
            this.txtSSID.Location = new System.Drawing.Point(100, 33);
            this.txtSSID.Name = "txtSSID";
            this.txtSSID.Size = new System.Drawing.Size(154, 20);
            this.txtSSID.TabIndex = 3;
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(100, 59);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(154, 20);
            this.txtPass.TabIndex = 4;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(6, 167);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(65, 13);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Not started..";
            this.lblStatus.Click += new System.EventHandler(this.lblStatus_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdShow);
            this.groupBox1.Controls.Add(this.rdHide);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnShare);
            this.groupBox1.Controls.Add(this.txtSSID);
            this.groupBox1.Controls.Add(this.cmbConnection);
            this.groupBox1.Controls.Add(this.lblStatus);
            this.groupBox1.Controls.Add(this.btnSS);
            this.groupBox1.Controls.Add(this.txtPass);
            this.groupBox1.Controls.Add(this.key);
            this.groupBox1.Controls.Add(this.pass);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 315);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setup";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 232);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Internet Sharing";
            // 
            // btnShare
            // 
            this.btnShare.Location = new System.Drawing.Point(6, 268);
            this.btnShare.Name = "btnShare";
            this.btnShare.Size = new System.Drawing.Size(248, 23);
            this.btnShare.TabIndex = 8;
            this.btnShare.Text = "Apply";
            this.btnShare.UseVisualStyleBackColor = true;
            this.btnShare.Click += new System.EventHandler(this.btnShare_Click);
            // 
            // cmbConnection
            // 
            this.cmbConnection.FormattingEnabled = true;
            this.cmbConnection.Location = new System.Drawing.Point(100, 229);
            this.cmbConnection.Name = "cmbConnection";
            this.cmbConnection.Size = new System.Drawing.Size(154, 21);
            this.cmbConnection.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(224, 358);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 33);
            this.label1.TabIndex = 7;
            this.label1.Text = "FJ";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // rdHide
            // 
            this.rdHide.AutoSize = true;
            this.rdHide.Location = new System.Drawing.Point(182, 83);
            this.rdHide.Name = "rdHide";
            this.rdHide.Size = new System.Drawing.Size(47, 17);
            this.rdHide.TabIndex = 10;
            this.rdHide.TabStop = true;
            this.rdHide.Text = "Hide";
            this.rdHide.UseVisualStyleBackColor = true;
            this.rdHide.CheckedChanged += new System.EventHandler(this.rdHide_CheckedChanged);
            // 
            // rdShow
            // 
            this.rdShow.AutoSize = true;
            this.rdShow.Location = new System.Drawing.Point(100, 83);
            this.rdShow.Name = "rdShow";
            this.rdShow.Size = new System.Drawing.Size(52, 17);
            this.rdShow.TabIndex = 11;
            this.rdShow.TabStop = true;
            this.rdShow.Text = "Show";
            this.rdShow.UseVisualStyleBackColor = true;
            this.rdShow.CheckedChanged += new System.EventHandler(this.rdShow_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 407);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Black Hotspot";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSS;
        private System.Windows.Forms.Label key;
        private System.Windows.Forms.Label pass;
        private System.Windows.Forms.TextBox txtSSID;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbConnection;
        private System.Windows.Forms.Button btnShare;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton rdShow;
        private System.Windows.Forms.RadioButton rdHide;
    }
}

