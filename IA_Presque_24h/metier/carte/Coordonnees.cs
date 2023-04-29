using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_Presque_24h.metier.carte
{
    public class Coordonnees
    {
        private int x;
        private int y;

        

        public Coordonnees(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
    }
}
