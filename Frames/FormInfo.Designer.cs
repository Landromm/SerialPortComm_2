
namespace SerialPortComm.Frames
{
    partial class FormInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInfo));
            this.rchbMain = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rchbMain
            // 
            this.rchbMain.AcceptsTab = true;
            this.rchbMain.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.rchbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rchbMain.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rchbMain.Location = new System.Drawing.Point(0, 0);
            this.rchbMain.Name = "rchbMain";
            this.rchbMain.ReadOnly = true;
            this.rchbMain.Size = new System.Drawing.Size(530, 450);
            this.rchbMain.TabIndex = 0;
            this.rchbMain.Text = resources.GetString("rchbMain.Text");
            // 
            // FormInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(219)))), ((int)(((byte)(233)))));
            this.ClientSize = new System.Drawing.Size(530, 450);
            this.Controls.Add(this.rchbMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormInfo";
            this.Text = "FormInfo";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rchbMain;
    }
}