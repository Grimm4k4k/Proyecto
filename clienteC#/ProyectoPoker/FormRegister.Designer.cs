namespace version1
{
    partial class FormRegister
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
            this.label2 = new System.Windows.Forms.Label();
            this.nombreBox = new System.Windows.Forms.TextBox();
            this.contraBox = new System.Windows.Forms.TextBox();
            this.edadBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dniBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.idBox = new System.Windows.Forms.TextBox();
            this.BAceptar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 193);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Contraseña:";
            // 
            // nombreBox
            // 
            this.nombreBox.Location = new System.Drawing.Point(131, 54);
            this.nombreBox.Name = "nombreBox";
            this.nombreBox.Size = new System.Drawing.Size(105, 20);
            this.nombreBox.TabIndex = 2;
            // 
            // contraBox
            // 
            this.contraBox.Location = new System.Drawing.Point(148, 186);
            this.contraBox.Name = "contraBox";
            this.contraBox.Size = new System.Drawing.Size(116, 20);
            this.contraBox.TabIndex = 3;
            // 
            // edadBox
            // 
            this.edadBox.Location = new System.Drawing.Point(131, 117);
            this.edadBox.Name = "edadBox";
            this.edadBox.Size = new System.Drawing.Size(43, 20);
            this.edadBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(78, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Edad:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(206, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "INTRODUCE LOS SIGUIENTES DATOS:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(78, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "DNI:";
            // 
            // dniBox
            // 
            this.dniBox.Location = new System.Drawing.Point(131, 85);
            this.dniBox.Name = "dniBox";
            this.dniBox.Size = new System.Drawing.Size(105, 20);
            this.dniBox.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(78, 159);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "ID:";
            // 
            // idBox
            // 
            this.idBox.Location = new System.Drawing.Point(131, 156);
            this.idBox.Name = "idBox";
            this.idBox.Size = new System.Drawing.Size(105, 20);
            this.idBox.TabIndex = 10;
            // 
            // BAceptar
            // 
            this.BAceptar.Location = new System.Drawing.Point(359, 271);
            this.BAceptar.Name = "BAceptar";
            this.BAceptar.Size = new System.Drawing.Size(107, 28);
            this.BAceptar.TabIndex = 11;
            this.BAceptar.Text = "aceptar";
            this.BAceptar.UseVisualStyleBackColor = true;
            this.BAceptar.Click += new System.EventHandler(this.BAceptar_Click);
            // 
            // FormRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BAceptar);
            this.Controls.Add(this.idBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dniBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.edadBox);
            this.Controls.Add(this.contraBox);
            this.Controls.Add(this.nombreBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FormRegister";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nombreBox;
        private System.Windows.Forms.TextBox contraBox;
        private System.Windows.Forms.TextBox edadBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox dniBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox idBox;
        private System.Windows.Forms.Button BAceptar;
    }
}