
namespace SerialPortComm.Frames
{
    partial class MainForm
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
            this.panelTreeMenu = new System.Windows.Forms.Panel();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnSendSettings = new System.Windows.Forms.Button();
            this.btnComSettings = new System.Windows.Forms.Button();
            this.btnGeneralSettings = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.lbLogo = new System.Windows.Forms.Label();
            this.panelTitle = new System.Windows.Forms.Panel();
            this.lbTitle = new System.Windows.Forms.Label();
            this.panelChildFrame = new System.Windows.Forms.Panel();
            this.panelTreeMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelTitle.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTreeMenu
            // 
            this.panelTreeMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.panelTreeMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTreeMenu.Controls.Add(this.btnInfo);
            this.panelTreeMenu.Controls.Add(this.btnSendSettings);
            this.panelTreeMenu.Controls.Add(this.btnComSettings);
            this.panelTreeMenu.Controls.Add(this.btnGeneralSettings);
            this.panelTreeMenu.Controls.Add(this.panelLogo);
            this.panelTreeMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelTreeMenu.ForeColor = System.Drawing.Color.Gainsboro;
            this.panelTreeMenu.Location = new System.Drawing.Point(0, 0);
            this.panelTreeMenu.Name = "panelTreeMenu";
            this.panelTreeMenu.Size = new System.Drawing.Size(150, 361);
            this.panelTreeMenu.TabIndex = 0;
            // 
            // btnInfo
            // 
            this.btnInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnInfo.FlatAppearance.BorderSize = 0;
            this.btnInfo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInfo.Location = new System.Drawing.Point(0, 230);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnInfo.Size = new System.Drawing.Size(148, 60);
            this.btnInfo.TabIndex = 6;
            this.btnInfo.Text = "Справка";
            this.btnInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnInfo.UseVisualStyleBackColor = true;
            this.btnInfo.Click += new System.EventHandler(this.btnInfo_Click);
            // 
            // btnSendSettings
            // 
            this.btnSendSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSendSettings.FlatAppearance.BorderSize = 0;
            this.btnSendSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSendSettings.Location = new System.Drawing.Point(0, 170);
            this.btnSendSettings.Name = "btnSendSettings";
            this.btnSendSettings.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnSendSettings.Size = new System.Drawing.Size(148, 60);
            this.btnSendSettings.TabIndex = 5;
            this.btnSendSettings.Text = "Настройки запросов";
            this.btnSendSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSendSettings.UseVisualStyleBackColor = true;
            this.btnSendSettings.Click += new System.EventHandler(this.btnSendSettings_Click);
            // 
            // btnComSettings
            // 
            this.btnComSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnComSettings.FlatAppearance.BorderSize = 0;
            this.btnComSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnComSettings.Location = new System.Drawing.Point(0, 110);
            this.btnComSettings.Name = "btnComSettings";
            this.btnComSettings.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnComSettings.Size = new System.Drawing.Size(148, 60);
            this.btnComSettings.TabIndex = 4;
            this.btnComSettings.Text = "Настройки COM";
            this.btnComSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnComSettings.UseVisualStyleBackColor = true;
            this.btnComSettings.Click += new System.EventHandler(this.btnComSettings_Click);
            // 
            // btnGeneralSettings
            // 
            this.btnGeneralSettings.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnGeneralSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGeneralSettings.FlatAppearance.BorderSize = 0;
            this.btnGeneralSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeneralSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGeneralSettings.Location = new System.Drawing.Point(0, 50);
            this.btnGeneralSettings.Name = "btnGeneralSettings";
            this.btnGeneralSettings.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.btnGeneralSettings.Size = new System.Drawing.Size(148, 60);
            this.btnGeneralSettings.TabIndex = 3;
            this.btnGeneralSettings.Text = "Общие настройки";
            this.btnGeneralSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGeneralSettings.UseVisualStyleBackColor = false;
            this.btnGeneralSettings.Click += new System.EventHandler(this.btnGeneralSettings_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(58)))));
            this.panelLogo.Controls.Add(this.lbLogo);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(148, 50);
            this.panelLogo.TabIndex = 0;
            // 
            // lbLogo
            // 
            this.lbLogo.AutoSize = true;
            this.lbLogo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbLogo.Location = new System.Drawing.Point(37, 15);
            this.lbLogo.Name = "lbLogo";
            this.lbLogo.Size = new System.Drawing.Size(59, 20);
            this.lbLogo.TabIndex = 0;
            this.lbLogo.Text = "МЕНЮ";
            this.lbLogo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelTitle
            // 
            this.panelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(113)))), ((int)(((byte)(211)))));
            this.panelTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelTitle.Controls.Add(this.lbTitle);
            this.panelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.panelTitle.Location = new System.Drawing.Point(150, 0);
            this.panelTitle.Name = "panelTitle";
            this.panelTitle.Size = new System.Drawing.Size(534, 50);
            this.panelTitle.TabIndex = 1;
            // 
            // lbTitle
            // 
            this.lbTitle.AutoSize = true;
            this.lbTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbTitle.Location = new System.Drawing.Point(27, 9);
            this.lbTitle.Name = "lbTitle";
            this.lbTitle.Size = new System.Drawing.Size(0, 26);
            this.lbTitle.TabIndex = 0;
            this.lbTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelChildFrame
            // 
            this.panelChildFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildFrame.Location = new System.Drawing.Point(150, 50);
            this.panelChildFrame.Name = "panelChildFrame";
            this.panelChildFrame.Size = new System.Drawing.Size(534, 311);
            this.panelChildFrame.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 361);
            this.Controls.Add(this.panelChildFrame);
            this.Controls.Add(this.panelTitle);
            this.Controls.Add(this.panelTreeMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuForm";
            this.panelTreeMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panelTitle.ResumeLayout(false);
            this.panelTitle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTreeMenu;
        private System.Windows.Forms.Panel panelTitle;
        private System.Windows.Forms.Panel panelChildFrame;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label lbLogo;
        private System.Windows.Forms.Button btnGeneralSettings;
        private System.Windows.Forms.Label lbTitle;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.Button btnSendSettings;
        private System.Windows.Forms.Button btnComSettings;
    }
}