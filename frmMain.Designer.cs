
namespace SerialPortComm
{
    partial class frmMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.PanelMain = new System.Windows.Forms.Panel();
            this.panelChildFill = new System.Windows.Forms.Panel();
            this.panelData = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelLogInfo = new System.Windows.Forms.Panel();
            this.richTextBoxLogInfo = new System.Windows.Forms.RichTextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelChildRight = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBoxSettingCom = new System.Windows.Forms.GroupBox();
            this.Separator = new System.Windows.Forms.Label();
            this.panelGroupBoxTop = new System.Windows.Forms.Panel();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelRigth = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.PanelMain.SuspendLayout();
            this.panelChildFill.SuspendLayout();
            this.panelData.SuspendLayout();
            this.panelLogInfo.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panelChildRight.SuspendLayout();
            this.groupBoxSettingCom.SuspendLayout();
            this.panelGroupBoxTop.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.panelRigth.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelMain
            // 
            this.PanelMain.Controls.Add(this.panelChildFill);
            this.PanelMain.Controls.Add(this.panelChildRight);
            this.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMain.Location = new System.Drawing.Point(0, 0);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.Size = new System.Drawing.Size(944, 461);
            this.PanelMain.TabIndex = 0;
            // 
            // panelChildFill
            // 
            this.panelChildFill.Controls.Add(this.panelData);
            this.panelChildFill.Controls.Add(this.panelLogInfo);
            this.panelChildFill.Controls.Add(this.statusStrip1);
            this.panelChildFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChildFill.Location = new System.Drawing.Point(0, 0);
            this.panelChildFill.Name = "panelChildFill";
            this.panelChildFill.Size = new System.Drawing.Size(744, 461);
            this.panelChildFill.TabIndex = 1;
            // 
            // panelData
            // 
            this.panelData.Controls.Add(this.groupBox1);
            this.panelData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelData.Location = new System.Drawing.Point(0, 0);
            this.panelData.Name = "panelData";
            this.panelData.Padding = new System.Windows.Forms.Padding(10, 5, 10, 33);
            this.panelData.Size = new System.Drawing.Size(744, 289);
            this.panelData.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(10, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(724, 251);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Value";
            // 
            // panelLogInfo
            // 
            this.panelLogInfo.BackColor = System.Drawing.SystemColors.Info;
            this.panelLogInfo.Controls.Add(this.richTextBoxLogInfo);
            this.panelLogInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelLogInfo.Location = new System.Drawing.Point(0, 289);
            this.panelLogInfo.Name = "panelLogInfo";
            this.panelLogInfo.Padding = new System.Windows.Forms.Padding(5);
            this.panelLogInfo.Size = new System.Drawing.Size(744, 150);
            this.panelLogInfo.TabIndex = 1;
            // 
            // richTextBoxLogInfo
            // 
            this.richTextBoxLogInfo.BackColor = System.Drawing.SystemColors.Info;
            this.richTextBoxLogInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBoxLogInfo.Location = new System.Drawing.Point(5, 5);
            this.richTextBoxLogInfo.Name = "richTextBoxLogInfo";
            this.richTextBoxLogInfo.ReadOnly = true;
            this.richTextBoxLogInfo.Size = new System.Drawing.Size(734, 140);
            this.richTextBoxLogInfo.TabIndex = 0;
            this.richTextBoxLogInfo.Text = "";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 439);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(744, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(132, 17);
            this.toolStripStatusLabel1.Text = "Send Message Package:";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(139, 17);
            this.toolStripStatusLabel2.Text = "00 00 00 00 00 00 00 00 00";
            // 
            // panelChildRight
            // 
            this.panelChildRight.Controls.Add(this.button4);
            this.panelChildRight.Controls.Add(this.button3);
            this.panelChildRight.Controls.Add(this.button2);
            this.panelChildRight.Controls.Add(this.button1);
            this.panelChildRight.Controls.Add(this.groupBoxSettingCom);
            this.panelChildRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelChildRight.Location = new System.Drawing.Point(744, 0);
            this.panelChildRight.Name = "panelChildRight";
            this.panelChildRight.Padding = new System.Windows.Forms.Padding(5);
            this.panelChildRight.Size = new System.Drawing.Size(200, 461);
            this.panelChildRight.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Top;
            this.button4.Font = new System.Drawing.Font("ITC Avant Garde Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(5, 255);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(190, 35);
            this.button4.TabIndex = 4;
            this.button4.Text = "Menu";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button3.Font = new System.Drawing.Font("ITC Avant Garde Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(5, 351);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(190, 35);
            this.button3.TabIndex = 3;
            this.button3.Text = "Start Send";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button2.Font = new System.Drawing.Font("ITC Avant Garde Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(5, 386);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(190, 35);
            this.button2.TabIndex = 2;
            this.button2.Text = "Close Port";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Font = new System.Drawing.Font("ITC Avant Garde Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(5, 421);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 35);
            this.button1.TabIndex = 1;
            this.button1.Text = "Open Port";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBoxSettingCom
            // 
            this.groupBoxSettingCom.Controls.Add(this.Separator);
            this.groupBoxSettingCom.Controls.Add(this.panelGroupBoxTop);
            this.groupBoxSettingCom.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxSettingCom.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxSettingCom.Location = new System.Drawing.Point(5, 5);
            this.groupBoxSettingCom.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.groupBoxSettingCom.Name = "groupBoxSettingCom";
            this.groupBoxSettingCom.Size = new System.Drawing.Size(190, 250);
            this.groupBoxSettingCom.TabIndex = 0;
            this.groupBoxSettingCom.TabStop = false;
            this.groupBoxSettingCom.Text = "Setting\'s COM";
            // 
            // Separator
            // 
            this.Separator.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Separator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Separator.Dock = System.Windows.Forms.DockStyle.Top;
            this.Separator.Location = new System.Drawing.Point(3, 175);
            this.Separator.Margin = new System.Windows.Forms.Padding(3, 5, 3, 0);
            this.Separator.Name = "Separator";
            this.Separator.Size = new System.Drawing.Size(184, 3);
            this.Separator.TabIndex = 1;
            // 
            // panelGroupBoxTop
            // 
            this.panelGroupBoxTop.Controls.Add(this.panelLeft);
            this.panelGroupBoxTop.Controls.Add(this.panelRigth);
            this.panelGroupBoxTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelGroupBoxTop.Location = new System.Drawing.Point(3, 15);
            this.panelGroupBoxTop.Name = "panelGroupBoxTop";
            this.panelGroupBoxTop.Size = new System.Drawing.Size(184, 160);
            this.panelGroupBoxTop.TabIndex = 0;
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.label6);
            this.panelLeft.Controls.Add(this.label5);
            this.panelLeft.Controls.Add(this.label4);
            this.panelLeft.Controls.Add(this.label3);
            this.panelLeft.Controls.Add(this.label2);
            this.panelLeft.Controls.Add(this.label1);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Padding = new System.Windows.Forms.Padding(3);
            this.panelLeft.Size = new System.Drawing.Size(90, 160);
            this.panelLeft.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(3, 118);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label6.Size = new System.Drawing.Size(47, 23);
            this.label6.TabIndex = 5;
            this.label6.Text = "Mode:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(3, 95);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label5.Size = new System.Drawing.Size(87, 23);
            this.label5.TabIndex = 4;
            this.label5.Text = "Data Bits:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(3, 72);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label4.Size = new System.Drawing.Size(87, 23);
            this.label4.TabIndex = 3;
            this.label4.Text = "Stop Bits:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(3, 49);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label3.Size = new System.Drawing.Size(63, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Parity:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label2.Size = new System.Drawing.Size(87, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Baud Rate:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 5);
            this.label1.Size = new System.Drawing.Size(47, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Port:";
            // 
            // panelRigth
            // 
            this.panelRigth.Controls.Add(this.label12);
            this.panelRigth.Controls.Add(this.label11);
            this.panelRigth.Controls.Add(this.label10);
            this.panelRigth.Controls.Add(this.label9);
            this.panelRigth.Controls.Add(this.label8);
            this.panelRigth.Controls.Add(this.label7);
            this.panelRigth.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelRigth.Location = new System.Drawing.Point(94, 0);
            this.panelRigth.Name = "panelRigth";
            this.panelRigth.Padding = new System.Windows.Forms.Padding(5);
            this.panelRigth.Size = new System.Drawing.Size(90, 160);
            this.panelRigth.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(5, 120);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.label12.Size = new System.Drawing.Size(20, 23);
            this.label12.TabIndex = 6;
            this.label12.Text = "-";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(5, 97);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.label11.Size = new System.Drawing.Size(20, 23);
            this.label11.TabIndex = 5;
            this.label11.Text = "-";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Top;
            this.label10.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(5, 74);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.label10.Size = new System.Drawing.Size(20, 23);
            this.label10.TabIndex = 4;
            this.label10.Text = "-";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(5, 51);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.label9.Size = new System.Drawing.Size(20, 23);
            this.label9.TabIndex = 3;
            this.label9.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(5, 28);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.label8.Size = new System.Drawing.Size(20, 23);
            this.label8.TabIndex = 2;
            this.label8.Text = "-";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Lucida Console", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(5, 5);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.label7.Size = new System.Drawing.Size(20, 23);
            this.label7.TabIndex = 1;
            this.label7.Text = "-";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 461);
            this.Controls.Add(this.PanelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Serial Port Communication";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.PanelMain.ResumeLayout(false);
            this.panelChildFill.ResumeLayout(false);
            this.panelChildFill.PerformLayout();
            this.panelData.ResumeLayout(false);
            this.panelLogInfo.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelChildRight.ResumeLayout(false);
            this.groupBoxSettingCom.ResumeLayout(false);
            this.panelGroupBoxTop.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.panelRigth.ResumeLayout(false);
            this.panelRigth.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelMain;
        private System.Windows.Forms.Panel panelChildRight;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBoxSettingCom;
        private System.Windows.Forms.Panel panelGroupBoxTop;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelRigth;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label Separator;
        private System.Windows.Forms.Panel panelChildFill;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panelLogInfo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.RichTextBox richTextBoxLogInfo;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}

