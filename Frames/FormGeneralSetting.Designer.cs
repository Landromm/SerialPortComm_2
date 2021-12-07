﻿
namespace SerialPortComm.Frames
{
    partial class FormGeneralSetting
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
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnResetCheckBox = new System.Windows.Forms.Button();
            this.btnSaveCheckBox = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLtPanelSelectView = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_DozaNow = new System.Windows.Forms.Panel();
            this.chb_DozaNow = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel_Temperature = new System.Windows.Forms.Panel();
            this.chb_Temperature = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel_VolumeFlow = new System.Windows.Forms.Panel();
            this.chb_VolumeFlow = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel_RoH2O = new System.Windows.Forms.Panel();
            this.chb_RoH2O = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel_MassFlow = new System.Windows.Forms.Panel();
            this.chb_MassFlow = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panelInfoView = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLtPanelSelectView.SuspendLayout();
            this.panel_DozaNow.SuspendLayout();
            this.panel_Temperature.SuspendLayout();
            this.panel_VolumeFlow.SuspendLayout();
            this.panel_RoH2O.SuspendLayout();
            this.panel_MassFlow.SuspendLayout();
            this.panelInfoView.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel8);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(534, 311);
            this.panel1.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.btnResetCheckBox);
            this.panel8.Controls.Add(this.btnSaveCheckBox);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(0, 261);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(534, 50);
            this.panel8.TabIndex = 1;
            // 
            // btnResetCheckBox
            // 
            this.btnResetCheckBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnResetCheckBox.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnResetCheckBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnResetCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetCheckBox.Location = new System.Drawing.Point(0, 0);
            this.btnResetCheckBox.Name = "btnResetCheckBox";
            this.btnResetCheckBox.Size = new System.Drawing.Size(100, 50);
            this.btnResetCheckBox.TabIndex = 1;
            this.btnResetCheckBox.Text = "Сбросить";
            this.btnResetCheckBox.UseVisualStyleBackColor = true;
            this.btnResetCheckBox.Click += new System.EventHandler(this.BtnResetCheckBox_Click);
            // 
            // btnSaveCheckBox
            // 
            this.btnSaveCheckBox.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnSaveCheckBox.FlatAppearance.BorderColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.btnSaveCheckBox.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnSaveCheckBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveCheckBox.Location = new System.Drawing.Point(434, 0);
            this.btnSaveCheckBox.Name = "btnSaveCheckBox";
            this.btnSaveCheckBox.Size = new System.Drawing.Size(100, 50);
            this.btnSaveCheckBox.TabIndex = 0;
            this.btnSaveCheckBox.Text = "Сохранить";
            this.btnSaveCheckBox.UseVisualStyleBackColor = true;
            this.btnSaveCheckBox.Click += new System.EventHandler(this.BtnSaveCheckBox_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLtPanelSelectView);
            this.groupBox1.Controls.Add(this.panelInfoView);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 172);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Просмотр";
            // 
            // flowLtPanelSelectView
            // 
            this.flowLtPanelSelectView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.flowLtPanelSelectView.Controls.Add(this.panel_DozaNow);
            this.flowLtPanelSelectView.Controls.Add(this.panel_Temperature);
            this.flowLtPanelSelectView.Controls.Add(this.panel_VolumeFlow);
            this.flowLtPanelSelectView.Controls.Add(this.panel_RoH2O);
            this.flowLtPanelSelectView.Controls.Add(this.panel_MassFlow);
            this.flowLtPanelSelectView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLtPanelSelectView.Location = new System.Drawing.Point(163, 16);
            this.flowLtPanelSelectView.Name = "flowLtPanelSelectView";
            this.flowLtPanelSelectView.Size = new System.Drawing.Size(368, 153);
            this.flowLtPanelSelectView.TabIndex = 1;
            // 
            // panel_DozaNow
            // 
            this.panel_DozaNow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_DozaNow.Controls.Add(this.chb_DozaNow);
            this.panel_DozaNow.Controls.Add(this.label1);
            this.panel_DozaNow.Location = new System.Drawing.Point(3, 3);
            this.panel_DozaNow.Name = "panel_DozaNow";
            this.panel_DozaNow.Size = new System.Drawing.Size(187, 43);
            this.panel_DozaNow.TabIndex = 0;
            // 
            // chb_DozaNow
            // 
            this.chb_DozaNow.AutoSize = true;
            this.chb_DozaNow.Dock = System.Windows.Forms.DockStyle.Top;
            this.chb_DozaNow.Location = new System.Drawing.Point(0, 19);
            this.chb_DozaNow.Name = "chb_DozaNow";
            this.chb_DozaNow.Padding = new System.Windows.Forms.Padding(7, 3, 0, 0);
            this.chb_DozaNow.Size = new System.Drawing.Size(185, 20);
            this.chb_DozaNow.TabIndex = 2;
            this.chb_DozaNow.Text = "Включить";
            this.chb_DozaNow.UseVisualStyleBackColor = true;
            this.chb_DozaNow.CheckedChanged += new System.EventHandler(this.Chb_DozaNow_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3);
            this.label1.Size = new System.Drawing.Size(160, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "Текущее значение дозы (м³):";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel_Temperature
            // 
            this.panel_Temperature.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_Temperature.Controls.Add(this.chb_Temperature);
            this.panel_Temperature.Controls.Add(this.label3);
            this.panel_Temperature.Location = new System.Drawing.Point(196, 3);
            this.panel_Temperature.Name = "panel_Temperature";
            this.panel_Temperature.Size = new System.Drawing.Size(164, 43);
            this.panel_Temperature.TabIndex = 1;
            // 
            // chb_Temperature
            // 
            this.chb_Temperature.AutoSize = true;
            this.chb_Temperature.Dock = System.Windows.Forms.DockStyle.Top;
            this.chb_Temperature.Location = new System.Drawing.Point(0, 19);
            this.chb_Temperature.Name = "chb_Temperature";
            this.chb_Temperature.Padding = new System.Windows.Forms.Padding(7, 3, 0, 0);
            this.chb_Temperature.Size = new System.Drawing.Size(162, 20);
            this.chb_Temperature.TabIndex = 2;
            this.chb_Temperature.Text = "Включить";
            this.chb_Temperature.UseVisualStyleBackColor = true;
            this.chb_Temperature.CheckedChanged += new System.EventHandler(this.Chb_Temperature_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(3);
            this.label3.Size = new System.Drawing.Size(149, 19);
            this.label3.TabIndex = 1;
            this.label3.Text = "Текущее температура (℃):";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel_VolumeFlow
            // 
            this.panel_VolumeFlow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_VolumeFlow.Controls.Add(this.chb_VolumeFlow);
            this.panel_VolumeFlow.Controls.Add(this.label4);
            this.panel_VolumeFlow.Location = new System.Drawing.Point(3, 52);
            this.panel_VolumeFlow.Name = "panel_VolumeFlow";
            this.panel_VolumeFlow.Size = new System.Drawing.Size(186, 43);
            this.panel_VolumeFlow.TabIndex = 2;
            // 
            // chb_VolumeFlow
            // 
            this.chb_VolumeFlow.AutoSize = true;
            this.chb_VolumeFlow.Dock = System.Windows.Forms.DockStyle.Top;
            this.chb_VolumeFlow.Location = new System.Drawing.Point(0, 19);
            this.chb_VolumeFlow.Name = "chb_VolumeFlow";
            this.chb_VolumeFlow.Padding = new System.Windows.Forms.Padding(7, 3, 0, 0);
            this.chb_VolumeFlow.Size = new System.Drawing.Size(184, 20);
            this.chb_VolumeFlow.TabIndex = 2;
            this.chb_VolumeFlow.Text = "Включить";
            this.chb_VolumeFlow.UseVisualStyleBackColor = true;
            this.chb_VolumeFlow.CheckedChanged += new System.EventHandler(this.Chb_VolumeFlow_CheckedChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(3);
            this.label4.Size = new System.Drawing.Size(185, 19);
            this.label4.TabIndex = 1;
            this.label4.Text = "Текущий объёмный расход (м³/ч):";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel_RoH2O
            // 
            this.panel_RoH2O.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_RoH2O.Controls.Add(this.chb_RoH2O);
            this.panel_RoH2O.Controls.Add(this.label6);
            this.panel_RoH2O.Location = new System.Drawing.Point(195, 52);
            this.panel_RoH2O.Name = "panel_RoH2O";
            this.panel_RoH2O.Size = new System.Drawing.Size(164, 43);
            this.panel_RoH2O.TabIndex = 4;
            // 
            // chb_RoH2O
            // 
            this.chb_RoH2O.AutoSize = true;
            this.chb_RoH2O.Dock = System.Windows.Forms.DockStyle.Top;
            this.chb_RoH2O.Location = new System.Drawing.Point(0, 19);
            this.chb_RoH2O.Name = "chb_RoH2O";
            this.chb_RoH2O.Padding = new System.Windows.Forms.Padding(7, 3, 0, 0);
            this.chb_RoH2O.Size = new System.Drawing.Size(162, 20);
            this.chb_RoH2O.TabIndex = 2;
            this.chb_RoH2O.Text = "Включить";
            this.chb_RoH2O.UseVisualStyleBackColor = true;
            this.chb_RoH2O.CheckedChanged += new System.EventHandler(this.Chb_RoH2O_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(3);
            this.label6.Size = new System.Drawing.Size(146, 19);
            this.label6.TabIndex = 1;
            this.label6.Text = "Текущая плотность (т/м³):";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel_MassFlow
            // 
            this.panel_MassFlow.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_MassFlow.Controls.Add(this.chb_MassFlow);
            this.panel_MassFlow.Controls.Add(this.label5);
            this.panel_MassFlow.Location = new System.Drawing.Point(3, 101);
            this.panel_MassFlow.Name = "panel_MassFlow";
            this.panel_MassFlow.Size = new System.Drawing.Size(186, 43);
            this.panel_MassFlow.TabIndex = 3;
            // 
            // chb_MassFlow
            // 
            this.chb_MassFlow.AutoSize = true;
            this.chb_MassFlow.Dock = System.Windows.Forms.DockStyle.Top;
            this.chb_MassFlow.Location = new System.Drawing.Point(0, 19);
            this.chb_MassFlow.Name = "chb_MassFlow";
            this.chb_MassFlow.Padding = new System.Windows.Forms.Padding(7, 3, 0, 0);
            this.chb_MassFlow.Size = new System.Drawing.Size(184, 20);
            this.chb_MassFlow.TabIndex = 2;
            this.chb_MassFlow.Text = "Включить";
            this.chb_MassFlow.UseVisualStyleBackColor = true;
            this.chb_MassFlow.CheckedChanged += new System.EventHandler(this.Chb_MassFlow_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(3);
            this.label5.Size = new System.Drawing.Size(178, 19);
            this.label5.TabIndex = 1;
            this.label5.Text = "Текущий массовый расход (т/ч):";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panelInfoView
            // 
            this.panelInfoView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelInfoView.Controls.Add(this.richTextBox1);
            this.panelInfoView.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelInfoView.Location = new System.Drawing.Point(3, 16);
            this.panelInfoView.Name = "panelInfoView";
            this.panelInfoView.Padding = new System.Windows.Forms.Padding(5);
            this.panelInfoView.Size = new System.Drawing.Size(160, 153);
            this.panelInfoView.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBox1.Location = new System.Drawing.Point(9, 9);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(139, 109);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "Выберите данные, которые будут отображаться на главном экране и записываться в фа" +
    "йл.";
            // 
            // FormGeneralSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(534, 311);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormGeneralSetting";
            this.Text = "FormGeneralSetting";
            this.Load += new System.EventHandler(this.FormGeneralSetting_Load);
            this.panel1.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.flowLtPanelSelectView.ResumeLayout(false);
            this.panel_DozaNow.ResumeLayout(false);
            this.panel_DozaNow.PerformLayout();
            this.panel_Temperature.ResumeLayout(false);
            this.panel_Temperature.PerformLayout();
            this.panel_VolumeFlow.ResumeLayout(false);
            this.panel_VolumeFlow.PerformLayout();
            this.panel_RoH2O.ResumeLayout(false);
            this.panel_RoH2O.PerformLayout();
            this.panel_MassFlow.ResumeLayout(false);
            this.panel_MassFlow.PerformLayout();
            this.panelInfoView.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chb_DozaNow;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelInfoView;
        private System.Windows.Forms.FlowLayoutPanel flowLtPanelSelectView;
        private System.Windows.Forms.Panel panel_DozaNow;
        private System.Windows.Forms.Panel panel_Temperature;
        private System.Windows.Forms.CheckBox chb_Temperature;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel_VolumeFlow;
        private System.Windows.Forms.CheckBox chb_VolumeFlow;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel_RoH2O;
        private System.Windows.Forms.CheckBox chb_RoH2O;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel_MassFlow;
        private System.Windows.Forms.CheckBox chb_MassFlow;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btnResetCheckBox;
        private System.Windows.Forms.Button btnSaveCheckBox;
    }
}