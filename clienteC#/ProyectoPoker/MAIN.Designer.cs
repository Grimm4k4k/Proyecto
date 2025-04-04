namespace version1
{
    partial class MAIN
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mENUDECONSULTASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.conQuePersonasHeJugadoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuantasPartidasSeHanJugadoEnXTiempoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.idPbox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelCon = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mENUDECONSULTASToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mENUDECONSULTASToolStripMenuItem
            // 
            this.mENUDECONSULTASToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.conQuePersonasHeJugadoToolStripMenuItem,
            this.cuantasPartidasSeHanJugadoEnXTiempoToolStripMenuItem});
            this.mENUDECONSULTASToolStripMenuItem.Name = "mENUDECONSULTASToolStripMenuItem";
            this.mENUDECONSULTASToolStripMenuItem.Size = new System.Drawing.Size(138, 20);
            this.mENUDECONSULTASToolStripMenuItem.Text = "MENU DE CONSULTAS";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(321, 22);
            this.toolStripMenuItem2.Text = "1.Quien ha jugado en la partida con id x?";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // conQuePersonasHeJugadoToolStripMenuItem
            // 
            this.conQuePersonasHeJugadoToolStripMenuItem.Name = "conQuePersonasHeJugadoToolStripMenuItem";
            this.conQuePersonasHeJugadoToolStripMenuItem.Size = new System.Drawing.Size(321, 22);
            this.conQuePersonasHeJugadoToolStripMenuItem.Text = "2.Con que personas he jugado?";
            this.conQuePersonasHeJugadoToolStripMenuItem.Click += new System.EventHandler(this.conQuePersonasHeJugadoToolStripMenuItem_Click);
            // 
            // cuantasPartidasSeHanJugadoEnXTiempoToolStripMenuItem
            // 
            this.cuantasPartidasSeHanJugadoEnXTiempoToolStripMenuItem.Name = "cuantasPartidasSeHanJugadoEnXTiempoToolStripMenuItem";
            this.cuantasPartidasSeHanJugadoEnXTiempoToolStripMenuItem.Size = new System.Drawing.Size(321, 22);
            this.cuantasPartidasSeHanJugadoEnXTiempoToolStripMenuItem.Text = "3. Cuantas partidas se han jugado en x tiempo?";
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Location = new System.Drawing.Point(655, 34);
            this.loginLabel.Name = "loginLabel";
            this.loginLabel.Size = new System.Drawing.Size(0, 13);
            this.loginLabel.TabIndex = 1;
            this.loginLabel.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(138, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Introduce el id de la partida:";
            this.label1.Visible = false;
            // 
            // idPbox
            // 
            this.idPbox.Location = new System.Drawing.Point(196, 53);
            this.idPbox.Name = "idPbox";
            this.idPbox.Size = new System.Drawing.Size(158, 20);
            this.idPbox.TabIndex = 3;
            this.idPbox.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(388, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Introduce un tiempo:";
            this.label2.Visible = false;
            // 
            // labelCon
            // 
            this.labelCon.AutoSize = true;
            this.labelCon.Location = new System.Drawing.Point(698, 58);
            this.labelCon.Name = "labelCon";
            this.labelCon.Size = new System.Drawing.Size(0, 13);
            this.labelCon.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(688, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Lista conectados:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // MAIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelCon);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.idPbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MAIN";
            this.Text = "Consulta";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MAIN_FormClosed);
            this.Load += new System.EventHandler(this.Consulta_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mENUDECONSULTASToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem conQuePersonasHeJugadoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cuantasPartidasSeHanJugadoEnXTiempoToolStripMenuItem;
        private System.Windows.Forms.Label loginLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox idPbox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelCon;
        private System.Windows.Forms.Label label3;
    }
}