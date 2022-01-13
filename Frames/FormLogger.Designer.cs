
namespace SerialPortComm.Frames
{
    partial class FormLogger
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel_LogWriteReadHex = new System.Windows.Forms.Panel();
            this.chb_LogWriteReadHex = new System.Windows.Forms.CheckBox();
            this.lb_LogWriteReadHex = new System.Windows.Forms.Label();
            this.panel_LogInfo = new System.Windows.Forms.Panel();
            this.chb_LogInfo = new System.Windows.Forms.CheckBox();
            this.lb_LogInfo = new System.Windows.Forms.Label();
            this.panel_LogData = new System.Windows.Forms.Panel();
            this.chb_LogData = new System.Windows.Forms.CheckBox();
            this.lb_LogData = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel_LogWriteReadHex.SuspendLayout();
            this.panel_LogInfo.SuspendLayout();
            this.panel_LogData.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 261);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(534, 50);
            this.panel1.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSave.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSave.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSave.Location = new System.Drawing.Point(409, 0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 50);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel_LogWriteReadHex);
            this.panel2.Controls.Add(this.panel_LogInfo);
            this.panel2.Controls.Add(this.panel_LogData);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(534, 261);
            this.panel2.TabIndex = 1;
            // 
            // panel_LogWriteReadHex
            // 
            this.panel_LogWriteReadHex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_LogWriteReadHex.Controls.Add(this.chb_LogWriteReadHex);
            this.panel_LogWriteReadHex.Controls.Add(this.lb_LogWriteReadHex);
            this.panel_LogWriteReadHex.Location = new System.Drawing.Point(12, 110);
            this.panel_LogWriteReadHex.Name = "panel_LogWriteReadHex";
            this.panel_LogWriteReadHex.Size = new System.Drawing.Size(225, 43);
            this.panel_LogWriteReadHex.TabIndex = 4;
            // 
            // chb_LogWriteReadHex
            // 
            this.chb_LogWriteReadHex.AutoSize = true;
            this.chb_LogWriteReadHex.Dock = System.Windows.Forms.DockStyle.Top;
            this.chb_LogWriteReadHex.Location = new System.Drawing.Point(0, 19);
            this.chb_LogWriteReadHex.Name = "chb_LogWriteReadHex";
            this.chb_LogWriteReadHex.Padding = new System.Windows.Forms.Padding(7, 3, 0, 0);
            this.chb_LogWriteReadHex.Size = new System.Drawing.Size(223, 20);
            this.chb_LogWriteReadHex.TabIndex = 2;
            this.chb_LogWriteReadHex.Text = "Включить";
            this.chb_LogWriteReadHex.UseVisualStyleBackColor = true;
            this.chb_LogWriteReadHex.CheckedChanged += new System.EventHandler(this.chb_LogWriteReadHex_CheckedChanged);
            // 
            // lb_LogWriteReadHex
            // 
            this.lb_LogWriteReadHex.AutoSize = true;
            this.lb_LogWriteReadHex.Dock = System.Windows.Forms.DockStyle.Top;
            this.lb_LogWriteReadHex.Location = new System.Drawing.Point(0, 0);
            this.lb_LogWriteReadHex.Name = "lb_LogWriteReadHex";
            this.lb_LogWriteReadHex.Padding = new System.Windows.Forms.Padding(3);
            this.lb_LogWriteReadHex.Size = new System.Drawing.Size(184, 19);
            this.lb_LogWriteReadHex.TabIndex = 1;
            this.lb_LogWriteReadHex.Text = "Логирование hex (Запрос/Ответ):";
            this.lb_LogWriteReadHex.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel_LogInfo
            // 
            this.panel_LogInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_LogInfo.Controls.Add(this.chb_LogInfo);
            this.panel_LogInfo.Controls.Add(this.lb_LogInfo);
            this.panel_LogInfo.Location = new System.Drawing.Point(12, 61);
            this.panel_LogInfo.Name = "panel_LogInfo";
            this.panel_LogInfo.Size = new System.Drawing.Size(225, 43);
            this.panel_LogInfo.TabIndex = 3;
            // 
            // chb_LogInfo
            // 
            this.chb_LogInfo.AutoSize = true;
            this.chb_LogInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.chb_LogInfo.Location = new System.Drawing.Point(0, 19);
            this.chb_LogInfo.Name = "chb_LogInfo";
            this.chb_LogInfo.Padding = new System.Windows.Forms.Padding(7, 3, 0, 0);
            this.chb_LogInfo.Size = new System.Drawing.Size(223, 20);
            this.chb_LogInfo.TabIndex = 2;
            this.chb_LogInfo.Text = "Включить";
            this.chb_LogInfo.UseVisualStyleBackColor = true;
            this.chb_LogInfo.CheckedChanged += new System.EventHandler(this.chb_LogInfo_CheckedChanged);
            // 
            // lb_LogInfo
            // 
            this.lb_LogInfo.AutoSize = true;
            this.lb_LogInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.lb_LogInfo.Location = new System.Drawing.Point(0, 0);
            this.lb_LogInfo.Name = "lb_LogInfo";
            this.lb_LogInfo.Padding = new System.Windows.Forms.Padding(3);
            this.lb_LogInfo.Size = new System.Drawing.Size(200, 19);
            this.lb_LogInfo.TabIndex = 1;
            this.lb_LogInfo.Text = "Логирование информации и ошибок:";
            this.lb_LogInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel_LogData
            // 
            this.panel_LogData.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_LogData.Controls.Add(this.chb_LogData);
            this.panel_LogData.Controls.Add(this.lb_LogData);
            this.panel_LogData.Location = new System.Drawing.Point(12, 12);
            this.panel_LogData.Name = "panel_LogData";
            this.panel_LogData.Size = new System.Drawing.Size(225, 43);
            this.panel_LogData.TabIndex = 1;
            // 
            // chb_LogData
            // 
            this.chb_LogData.AutoSize = true;
            this.chb_LogData.Dock = System.Windows.Forms.DockStyle.Top;
            this.chb_LogData.Location = new System.Drawing.Point(0, 19);
            this.chb_LogData.Name = "chb_LogData";
            this.chb_LogData.Padding = new System.Windows.Forms.Padding(7, 3, 0, 0);
            this.chb_LogData.Size = new System.Drawing.Size(223, 20);
            this.chb_LogData.TabIndex = 2;
            this.chb_LogData.Text = "Включить";
            this.chb_LogData.UseVisualStyleBackColor = true;
            this.chb_LogData.CheckedChanged += new System.EventHandler(this.chb_LogData_CheckedChanged);
            // 
            // lb_LogData
            // 
            this.lb_LogData.AutoSize = true;
            this.lb_LogData.Dock = System.Windows.Forms.DockStyle.Top;
            this.lb_LogData.Location = new System.Drawing.Point(0, 0);
            this.lb_LogData.Name = "lb_LogData";
            this.lb_LogData.Padding = new System.Windows.Forms.Padding(3);
            this.lb_LogData.Size = new System.Drawing.Size(123, 19);
            this.lb_LogData.TabIndex = 1;
            this.lb_LogData.Text = "Логирование данных:";
            this.lb_LogData.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FormLogger
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(206)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(534, 311);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLogger";
            this.Text = "FormLogger";
            this.Load += new System.EventHandler(this.FormLogger_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel_LogWriteReadHex.ResumeLayout(false);
            this.panel_LogWriteReadHex.PerformLayout();
            this.panel_LogInfo.ResumeLayout(false);
            this.panel_LogInfo.PerformLayout();
            this.panel_LogData.ResumeLayout(false);
            this.panel_LogData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel_LogInfo;
        private System.Windows.Forms.CheckBox chb_LogInfo;
        private System.Windows.Forms.Label lb_LogInfo;
        private System.Windows.Forms.Panel panel_LogData;
        private System.Windows.Forms.CheckBox chb_LogData;
        private System.Windows.Forms.Label lb_LogData;
        private System.Windows.Forms.Panel panel_LogWriteReadHex;
        private System.Windows.Forms.CheckBox chb_LogWriteReadHex;
        private System.Windows.Forms.Label lb_LogWriteReadHex;
    }
}