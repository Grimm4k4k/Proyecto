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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
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
