namespace version1
{
    partial class FormInvitacion
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
            this.label1 = new System.Windows.Forms.Label();
            this.siButton = new System.Windows.Forms.Button();
            this.noButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 0;
            // 
            // siButton
            // 
            this.siButton.Location = new System.Drawing.Point(12, 91);
            this.siButton.Name = "siButton";
            this.siButton.Size = new System.Drawing.Size(75, 23);
            this.siButton.TabIndex = 1;
            this.siButton.Text = "SI";
            this.siButton.UseVisualStyleBackColor = true;
            this.siButton.Click += new System.EventHandler(this.siButton_Click);
            // 
            // noButton
            // 
            this.noButton.Location = new System.Drawing.Point(234, 91);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(75, 23);
            this.noButton.TabIndex = 2;
            this.noButton.Text = "NO";
            this.noButton.UseVisualStyleBackColor = true;
            this.noButton.Click += new System.EventHandler(this.noButton_Click);
            // 
            // FormInvitacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Turquoise;
            this.ClientSize = new System.Drawing.Size(321, 148);
            this.Controls.Add(this.noButton);
            this.Controls.Add(this.siButton);
            this.Controls.Add(this.label1);
            this.Name = "FormInvitacion";
            this.Text = "FormInvitacion";
            this.Load += new System.EventHandler(this.FormInvitacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button siButton;
        private System.Windows.Forms.Button noButton;
    }
}