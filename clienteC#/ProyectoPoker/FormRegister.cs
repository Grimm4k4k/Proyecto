using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace version1
{
    public partial class FormRegister : Form
    {
        public FormRegister()
        {
            InitializeComponent();
        }

        public string getNombre()
        {
            return nombreBox.Text;
        }

        public string getDni()
        {
            return dniBox.Text;
        }

        public int getEdad()
        {
            return Convert.ToInt32(edadBox.Text);
        }

        public string getId()
        {
            return idBox.Text;
        }

        public string getContra()
        {
            return contraBox.Text;
        }

        private void BAceptar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
