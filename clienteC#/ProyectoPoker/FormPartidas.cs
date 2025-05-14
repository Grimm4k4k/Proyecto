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
    public partial class FormPartidas: Form
    {
        ListaJugadores listaJugadores = new ListaJugadores();
        int fichas;
        int IdP;
        Queue<string> chat;
        public FormPartidas()
        {
            InitializeComponent();
            chat = new Queue<string>();
        }


        public void setlistaJugadores(ListaJugadores listaJugadores)
        {
            this.listaJugadores = listaJugadores;
        }
        
        public void setFichas(int fichas)
        {
            this.fichas = fichas;
        }

        public void setIdP(int IdP)
        {
            this.IdP = IdP;
        }
    }
}
