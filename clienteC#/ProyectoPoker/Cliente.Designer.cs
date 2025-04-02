namespace version1
{
    partial class Cliente
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
            this.BLogin = new System.Windows.Forms.Button();
            this.BRegister = new System.Windows.Forms.Button();
            this.Bcon = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BLogin
            // 
            this.BLogin.Location = new System.Drawing.Point(285, 73);
            this.BLogin.Name = "BLogin";
            this.BLogin.Size = new System.Drawing.Size(105, 25);
            this.BLogin.TabIndex = 0;
            this.BLogin.Text = "log in";
            this.BLogin.UseVisualStyleBackColor = true;
            this.BLogin.Click += new System.EventHandler(this.BLogin_Click);
            // 
            // BRegister
            // 
            this.BRegister.Location = new System.Drawing.Point(285, 131);
            this.BRegister.Name = "BRegister";
            this.BRegister.Size = new System.Drawing.Size(104, 27);
            this.BRegister.TabIndex = 1;
            this.BRegister.Text = "register";
            this.BRegister.UseVisualStyleBackColor = true;
            this.BRegister.Click += new System.EventHandler(this.BRegister_Click);
            // 
            // Bcon
            // 
            this.Bcon.Location = new System.Drawing.Point(81, 58);
            this.Bcon.Name = "Bcon";
            this.Bcon.Size = new System.Drawing.Size(114, 30);
            this.Bcon.TabIndex = 2;
            this.Bcon.Text = "conectar";
            this.Bcon.UseVisualStyleBackColor = true;
            this.Bcon.Click += new System.EventHandler(this.Bcon_Click);
            // 
            // Cliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Bcon);
            this.Controls.Add(this.BRegister);
            this.Controls.Add(this.BLogin);
            this.Name = "Cliente";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BLogin;
        private System.Windows.Forms.Button BRegister;
        private System.Windows.Forms.Button Bcon;
    }
}

