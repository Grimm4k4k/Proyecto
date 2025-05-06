using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace version1
{
    internal class carta
    {
        public class Carta
        {
            public string Palo { get; set; }      // Corazones, Diamantes, Tréboles, Picas
            public string Valor { get; set; }     // 2-10, J, Q, K, A

            public Carta(string palo, string valor)
            {
                Palo = palo;
                Valor = valor;
            }
        }
    }
}
