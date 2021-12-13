
namespace SerialPortComm.Frames
{
    partial class FormSendSettings
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelSplitCentre = new System.Windows.Forms.Panel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tb_MassFlow = new System.Windows.Forms.TextBox();
            this.lb_MassFlow = new System.Windows.Forms.Label();
            this.tb_VolumeFlow = new System.Windows.Forms.TextBox();
            this.lb_VolumeFlow = new System.Windows.Forms.Label();
            this.tb_DozaNow = new System.Windows.Forms.TextBox();
            this.lb_DozaNow = new System.Windows.Forms.Label();
            this.tb_RoH2O = new System.Windows.Forms.TextBox();
            this.lb_RoH2O = new System.Windows.Forms.Label();
            this.tb_Temperature = new System.Windows.Forms.TextBox();
            this.lb_Temperature = new System.Windows.Forms.Label();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panelButton = new System.Windows.Forms.Panel();
            this.btnResetTextBox = new System.Windows.Forms.Button();
            this.btnSaveTextBox = new System.Windows.Forms.Button();
            this.panelMain.SuspendLayout();
            this.panelSplitCentre.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.panelButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Controls.Add(this.panelSplitCentre);
            this.panelMain.Controls.Add(this.panelInfo);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(534, 261);
            this.panelMain.TabIndex = 2;
            // 
            // panelSplitCentre
            // 
            this.panelSplitCentre.Controls.Add(this.splitContainer);
            this.panelSplitCentre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSplitCentre.Location = new System.Drawing.Point(0, 50);
            this.panelSplitCentre.Name = "panelSplitCentre";
            this.panelSplitCentre.Size = new System.Drawing.Size(534, 211);
            this.panelSplitCentre.TabIndex = 1;
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.tb_MassFlow);
            this.splitContainer.Panel1.Controls.Add(this.lb_MassFlow);
            this.splitContainer.Panel1.Controls.Add(this.tb_VolumeFlow);
            this.splitContainer.Panel1.Controls.Add(this.lb_VolumeFlow);
            this.splitContainer.Panel1.Controls.Add(this.tb_DozaNow);
            this.splitContainer.Panel1.Controls.Add(this.lb_DozaNow);
            this.splitContainer.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tb_RoH2O);
            this.splitContainer.Panel2.Controls.Add(this.lb_RoH2O);
            this.splitContainer.Panel2.Controls.Add(this.tb_Temperature);
            this.splitContainer.Panel2.Controls.Add(this.lb_Temperature);
            this.splitContainer.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainer.Size = new System.Drawing.Size(534, 211);
            this.splitContainer.SplitterDistance = 267;
            this.splitContainer.TabIndex = 0;
            // 
            // tb_MassFlow
            // 
            this.tb_MassFlow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.tb_MassFlow.Dock = System.Windows.Forms.DockStyle.Top;
            this.tb_MassFlow.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_MassFlow.Location = new System.Drawing.Point(5, 140);
            this.tb_MassFlow.Name = "tb_MassFlow";
            this.tb_MassFlow.Size = new System.Drawing.Size(257, 22);
            this.tb_MassFlow.TabIndex = 5;
            this.tb_MassFlow.Text = "AA SS DD FF GG 11 23";
            // 
            // lb_MassFlow
            // 
            this.lb_MassFlow.AutoSize = true;
            this.lb_MassFlow.Dock = System.Windows.Forms.DockStyle.Top;
            this.lb_MassFlow.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_MassFlow.Location = new System.Drawing.Point(5, 108);
            this.lb_MassFlow.Name = "lb_MassFlow";
            this.lb_MassFlow.Padding = new System.Windows.Forms.Padding(0, 10, 5, 5);
            this.lb_MassFlow.Size = new System.Drawing.Size(232, 32);
            this.lb_MassFlow.TabIndex = 4;
            this.lb_MassFlow.Text = "Текущий массовый расход (т/ч):";
            // 
            // tb_VolumeFlow
            // 
            this.tb_VolumeFlow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.tb_VolumeFlow.Dock = System.Windows.Forms.DockStyle.Top;
            this.tb_VolumeFlow.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_VolumeFlow.Location = new System.Drawing.Point(5, 86);
            this.tb_VolumeFlow.Name = "tb_VolumeFlow";
            this.tb_VolumeFlow.Size = new System.Drawing.Size(257, 22);
            this.tb_VolumeFlow.TabIndex = 3;
            this.tb_VolumeFlow.Text = "AA SS DD FF GG 11 23";
            // 
            // lb_VolumeFlow
            // 
            this.lb_VolumeFlow.AutoSize = true;
            this.lb_VolumeFlow.Dock = System.Windows.Forms.DockStyle.Top;
            this.lb_VolumeFlow.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_VolumeFlow.Location = new System.Drawing.Point(5, 54);
            this.lb_VolumeFlow.Name = "lb_VolumeFlow";
            this.lb_VolumeFlow.Padding = new System.Windows.Forms.Padding(0, 10, 5, 5);
            this.lb_VolumeFlow.Size = new System.Drawing.Size(242, 32);
            this.lb_VolumeFlow.TabIndex = 2;
            this.lb_VolumeFlow.Text = "Текущий объёмный расход (м³/ч):";
            // 
            // tb_DozaNow
            // 
            this.tb_DozaNow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.tb_DozaNow.Dock = System.Windows.Forms.DockStyle.Top;
            this.tb_DozaNow.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_DozaNow.Location = new System.Drawing.Point(5, 32);
            this.tb_DozaNow.Margin = new System.Windows.Forms.Padding(5);
            this.tb_DozaNow.Name = "tb_DozaNow";
            this.tb_DozaNow.Size = new System.Drawing.Size(257, 22);
            this.tb_DozaNow.TabIndex = 1;
            this.tb_DozaNow.Text = "AA SS DD FF GG 11 23";
            // 
            // lb_DozaNow
            // 
            this.lb_DozaNow.AutoSize = true;
            this.lb_DozaNow.Dock = System.Windows.Forms.DockStyle.Top;
            this.lb_DozaNow.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_DozaNow.Location = new System.Drawing.Point(5, 5);
            this.lb_DozaNow.Name = "lb_DozaNow";
            this.lb_DozaNow.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.lb_DozaNow.Size = new System.Drawing.Size(209, 27);
            this.lb_DozaNow.TabIndex = 0;
            this.lb_DozaNow.Text = "Текущее значение дозы (м³):";
            // 
            // tb_RoH2O
            // 
            this.tb_RoH2O.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.tb_RoH2O.Dock = System.Windows.Forms.DockStyle.Top;
            this.tb_RoH2O.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_RoH2O.Location = new System.Drawing.Point(5, 86);
            this.tb_RoH2O.Margin = new System.Windows.Forms.Padding(5);
            this.tb_RoH2O.Name = "tb_RoH2O";
            this.tb_RoH2O.Size = new System.Drawing.Size(253, 22);
            this.tb_RoH2O.TabIndex = 5;
            this.tb_RoH2O.Text = "AA SS DD FF GG 11 23";
            // 
            // lb_RoH2O
            // 
            this.lb_RoH2O.AutoSize = true;
            this.lb_RoH2O.Dock = System.Windows.Forms.DockStyle.Top;
            this.lb_RoH2O.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_RoH2O.Location = new System.Drawing.Point(5, 54);
            this.lb_RoH2O.Name = "lb_RoH2O";
            this.lb_RoH2O.Padding = new System.Windows.Forms.Padding(0, 10, 5, 5);
            this.lb_RoH2O.Size = new System.Drawing.Size(188, 32);
            this.lb_RoH2O.TabIndex = 4;
            this.lb_RoH2O.Text = "Текущая плотность (т/м³):";
            // 
            // tb_Temperature
            // 
            this.tb_Temperature.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.tb_Temperature.Dock = System.Windows.Forms.DockStyle.Top;
            this.tb_Temperature.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tb_Temperature.Location = new System.Drawing.Point(5, 32);
            this.tb_Temperature.Margin = new System.Windows.Forms.Padding(5);
            this.tb_Temperature.Name = "tb_Temperature";
            this.tb_Temperature.Size = new System.Drawing.Size(253, 22);
            this.tb_Temperature.TabIndex = 3;
            this.tb_Temperature.Text = "AA SS DD FF GG 11 23";
            // 
            // lb_Temperature
            // 
            this.lb_Temperature.AutoSize = true;
            this.lb_Temperature.Dock = System.Windows.Forms.DockStyle.Top;
            this.lb_Temperature.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lb_Temperature.Location = new System.Drawing.Point(5, 5);
            this.lb_Temperature.Name = "lb_Temperature";
            this.lb_Temperature.Padding = new System.Windows.Forms.Padding(0, 5, 5, 5);
            this.lb_Temperature.Size = new System.Drawing.Size(191, 27);
            this.lb_Temperature.TabIndex = 2;
            this.lb_Temperature.Text = "Текущее температура (℃):";
            // 
            // panelInfo
            // 
            this.panelInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelInfo.Controls.Add(this.label1);
            this.panelInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelInfo.Location = new System.Drawing.Point(0, 0);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(534, 50);
            this.panelInfo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(38, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(448, 34);
            this.label1.TabIndex = 0;
            this.label1.Text = "Введите запросы к счётчику для необходимых параметров, \r\nв формате \"hex\".";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.btnResetTextBox);
            this.panelButton.Controls.Add(this.btnSaveTextBox);
            this.panelButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButton.Location = new System.Drawing.Point(0, 261);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(534, 50);
            this.panelButton.TabIndex = 3;
            // 
            // btnResetTextBox
            // 
            this.btnResetTextBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnResetTextBox.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnResetTextBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnResetTextBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetTextBox.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnResetTextBox.Location = new System.Drawing.Point(0, 0);
            this.btnResetTextBox.Name = "btnResetTextBox";
            this.btnResetTextBox.Size = new System.Drawing.Size(125, 50);
            this.btnResetTextBox.TabIndex = 1;
            this.btnResetTextBox.Text = "Сбросить";
            this.btnResetTextBox.UseVisualStyleBackColor = true;
            this.btnResetTextBox.Click += new System.EventHandler(this.BtnResetTextBox_Click);
            // 
            // btnSaveTextBox
            // 
            this.btnSaveTextBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSaveTextBox.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSaveTextBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSaveTextBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveTextBox.Font = new System.Drawing.Font("Consolas", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSaveTextBox.Location = new System.Drawing.Point(409, 0);
            this.btnSaveTextBox.Name = "btnSaveTextBox";
            this.btnSaveTextBox.Size = new System.Drawing.Size(125, 50);
            this.btnSaveTextBox.TabIndex = 0;
            this.btnSaveTextBox.Text = "Сохранить";
            this.btnSaveTextBox.UseVisualStyleBackColor = true;
            this.btnSaveTextBox.Click += new System.EventHandler(this.BtnSaveTextBox_Click);
            // 
            // FormSendSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(188)))), ((int)(((byte)(206)))), ((int)(((byte)(225)))));
            this.ClientSize = new System.Drawing.Size(534, 311);
            this.Controls.Add(this.panelButton);
            this.Controls.Add(this.panelMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSendSettings";
            this.Text = "FormSendSettings";
            this.Load += new System.EventHandler(this.FormSendSettings_Load);
            this.panelMain.ResumeLayout(false);
            this.panelSplitCentre.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel1.PerformLayout();
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.panelButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMain;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.Button btnSaveTextBox;
        private System.Windows.Forms.Button btnResetTextBox;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelSplitCentre;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TextBox tb_MassFlow;
        private System.Windows.Forms.Label lb_MassFlow;
        private System.Windows.Forms.TextBox tb_VolumeFlow;
        private System.Windows.Forms.Label lb_VolumeFlow;
        private System.Windows.Forms.TextBox tb_DozaNow;
        private System.Windows.Forms.Label lb_DozaNow;
        private System.Windows.Forms.TextBox tb_RoH2O;
        private System.Windows.Forms.Label lb_RoH2O;
        private System.Windows.Forms.TextBox tb_Temperature;
        private System.Windows.Forms.Label lb_Temperature;
    }
}