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
            this.iNVITARToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.idPbox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.labeltiempo = new System.Windows.Forms.Label();
            this.labelCon = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.TBox = new System.Windows.Forms.TextBox();
            this.buscartiempo = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.invitadoBox = new System.Windows.Forms.TextBox();
            this.invitarButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.enviarBtn = new System.Windows.Forms.Button();
            this.chatBox = new System.Windows.Forms.RichTextBox();
            this.enviarBox = new System.Windows.Forms.TextBox();
            this.chatLabel = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mENUDECONSULTASToolStripMenuItem,
            this.iNVITARToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1904, 24);
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
            this.cuantasPartidasSeHanJugadoEnXTiempoToolStripMenuItem.Click += new System.EventHandler(this.cuantasPartidasSeHanJugadoEnXTiempoToolStripMenuItem_Click);
            // 
            // iNVITARToolStripMenuItem
            // 
            this.iNVITARToolStripMenuItem.Name = "iNVITARToolStripMenuItem";
            this.iNVITARToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.iNVITARToolStripMenuItem.Text = "INVITAR";
            this.iNVITARToolStripMenuItem.Click += new System.EventHandler(this.iNVITARToolStripMenuItem_Click);
            // 
            // loginLabel
            // 
            this.loginLabel.AutoSize = true;
            this.loginLabel.Location = new System.Drawing.Point(1745, 41);
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
            // labeltiempo
            // 
            this.labeltiempo.AutoSize = true;
            this.labeltiempo.Location = new System.Drawing.Point(52, 91);
            this.labeltiempo.Name = "labeltiempo";
            this.labeltiempo.Size = new System.Drawing.Size(104, 13);
            this.labeltiempo.TabIndex = 5;
            this.labeltiempo.Text = "Introduce un tiempo:";
            this.labeltiempo.Visible = false;
            // 
            // labelCon
            // 
            this.labelCon.AutoSize = true;
            this.labelCon.Location = new System.Drawing.Point(1788, 65);
            this.labelCon.Name = "labelCon";
            this.labelCon.Size = new System.Drawing.Size(0, 13);
            this.labelCon.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1778, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Lista conectados:";
            // 
            // TBox
            // 
            this.TBox.Location = new System.Drawing.Point(196, 86);
            this.TBox.Name = "TBox";
            this.TBox.Size = new System.Drawing.Size(158, 20);
            this.TBox.TabIndex = 8;
            this.TBox.Visible = false;
            // 
            // buscartiempo
            // 
            this.buscartiempo.Location = new System.Drawing.Point(388, 84);
            this.buscartiempo.Name = "buscartiempo";
            this.buscartiempo.Size = new System.Drawing.Size(76, 23);
            this.buscartiempo.TabIndex = 9;
            this.buscartiempo.Text = "buscar";
            this.buscartiempo.UseVisualStyleBackColor = true;
            this.buscartiempo.Visible = false;
            this.buscartiempo.Click += new System.EventHandler(this.buscartiempo_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "A quien quieres invitar?";
            this.label2.Visible = false;
            // 
            // invitadoBox
            // 
            this.invitadoBox.Location = new System.Drawing.Point(196, 126);
            this.invitadoBox.Name = "invitadoBox";
            this.invitadoBox.Size = new System.Drawing.Size(100, 20);
            this.invitadoBox.TabIndex = 11;
            this.invitadoBox.Visible = false;
            // 
            // invitarButton
            // 
            this.invitarButton.Location = new System.Drawing.Point(317, 126);
            this.invitarButton.Name = "invitarButton";
            this.invitarButton.Size = new System.Drawing.Size(75, 23);
            this.invitarButton.TabIndex = 12;
            this.invitarButton.Text = "invitar";
            this.invitarButton.UseVisualStyleBackColor = true;
            this.invitarButton.Visible = false;
            this.invitarButton.Click += new System.EventHandler(this.invitarButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(89, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(274, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "IMPORTANTE: Seguir el formato: invitado1/invitado2/...";
            this.label4.Visible = false;
            // 
            // enviarBtn
            // 
            this.enviarBtn.AutoSize = true;
            this.enviarBtn.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.enviarBtn.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enviarBtn.Location = new System.Drawing.Point(1787, 898);
            this.enviarBtn.Name = "enviarBtn";
            this.enviarBtn.Size = new System.Drawing.Size(75, 26);
            this.enviarBtn.TabIndex = 17;
            this.enviarBtn.Text = "Enviar";
            this.enviarBtn.UseVisualStyleBackColor = true;
            this.enviarBtn.Visible = false;
            this.enviarBtn.Click += new System.EventHandler(this.enviarBtn_Click);
            // 
            // chatBox
            // 
            this.chatBox.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatBox.Location = new System.Drawing.Point(1620, 717);
            this.chatBox.Name = "chatBox";
            this.chatBox.ReadOnly = true;
            this.chatBox.Size = new System.Drawing.Size(249, 172);
            this.chatBox.TabIndex = 16;
            this.chatBox.Text = "";
            this.chatBox.Visible = false;
            // 
            // enviarBox
            // 
            this.enviarBox.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enviarBox.Location = new System.Drawing.Point(1620, 901);
            this.enviarBox.Name = "enviarBox";
            this.enviarBox.Size = new System.Drawing.Size(161, 20);
            this.enviarBox.TabIndex = 15;
            this.enviarBox.Visible = false;
            // 
            // chatLabel
            // 
            this.chatLabel.AutoSize = true;
            this.chatLabel.Font = new System.Drawing.Font("Javanese Text", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chatLabel.Location = new System.Drawing.Point(1715, 671);
            this.chatLabel.Name = "chatLabel";
            this.chatLabel.Size = new System.Drawing.Size(76, 43);
            this.chatLabel.TabIndex = 14;
            this.chatLabel.Text = "CHAT";
            this.chatLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.chatLabel.Visible = false;
            // 
            // MAIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 961);
            this.Controls.Add(this.enviarBtn);
            this.Controls.Add(this.chatBox);
            this.Controls.Add(this.enviarBox);
            this.Controls.Add(this.chatLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.invitarButton);
            this.Controls.Add(this.invitadoBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buscartiempo);
            this.Controls.Add(this.TBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelCon);
            this.Controls.Add(this.labeltiempo);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.idPbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loginLabel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MAIN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Consulta";
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
        private System.Windows.Forms.Label labeltiempo;
        private System.Windows.Forms.Label labelCon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TBox;
        private System.Windows.Forms.Button buscartiempo;
        private System.Windows.Forms.ToolStripMenuItem iNVITARToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox invitadoBox;
        private System.Windows.Forms.Button invitarButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button enviarBtn;
        private System.Windows.Forms.RichTextBox chatBox;
        private System.Windows.Forms.TextBox enviarBox;
        private System.Windows.Forms.Label chatLabel;
    }
}