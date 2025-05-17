namespace version1
{
    partial class FormPartidas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPartidas));
            this.tableroPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.tableroPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tableroPictureBox
            // 
            this.tableroPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("tableroPictureBox.Image")));
            this.tableroPictureBox.Location = new System.Drawing.Point(100, 46);
            this.tableroPictureBox.Name = "tableroPictureBox";
            this.tableroPictureBox.Size = new System.Drawing.Size(600, 359);
            this.tableroPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.tableroPictureBox.TabIndex = 21;
            this.tableroPictureBox.TabStop = false;
            this.tableroPictureBox.Visible = false;
            // 
            // FormPartidas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.tableroPictureBox);
            this.Name = "FormPartidas";
            this.Text = "Partidas";
            ((System.ComponentModel.ISupportInitialize)(this.tableroPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox tableroPictureBox;
    }
}