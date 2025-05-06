using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static version1.carta;

namespace version1
{
    public class Baraja
    {
        private List<Carta> cartas;
        private static readonly string[] Palos = { "Corazones", "Diamantes", "Tréboles", "Picas" };
        private static readonly string[] Valores = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };

        public Baraja()
        {
            cartas = new List<Carta>();
            foreach (var palo in Palos)
            {
                foreach (var valor in Valores)
                {
                    cartas.Add(new Carta(palo, valor));
                }
            }
        }
    }
}
