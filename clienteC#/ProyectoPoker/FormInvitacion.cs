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
    public partial class FormInvitacion: Form
    {
        string host;
        string respuesta;

        public FormInvitacion()
        {
            InitializeComponent();
        }

        public void setHost(string host)
        {
            this.host = host;
        }

        public string getRespuesta()
        {
            return respuesta;
        }

        private void FormInvitacion_Load(object sender, EventArgs e)
        {
            label1.Text = " Te quieres unir a la partida de" + host + "?";
        }

        private void siButton_Click(object sender, EventArgs e)
        {
            this.respuesta = "si";
            this.Close();
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            this.respuesta = "no";
            this.Close();
        }
    }
}
