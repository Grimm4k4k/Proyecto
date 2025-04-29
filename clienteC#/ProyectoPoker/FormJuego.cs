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
    public partial class FormJuego : Form
    {
        public FormJuego()
        {
            InitializeComponent();
        }
        string idPartida;
        string idJugador;
        string jugadores;
        public void setIdPartida(string idPartida)
        {
            this.idPartida = idPartida;

        }
        public void setId(string idJugador)
        {
            this.idJugador = idJugador;

        }
        public void setJugadores(string jugadores)
        {
            this.jugadores = jugadores;

        }

    }
}
