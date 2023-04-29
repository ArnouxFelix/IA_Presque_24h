using IA_Presque_24h;
using IA_Presque_24h.metier.carte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_Presque_24h.metier.nain
{
    public class Nain
    {
        private Case _case;
        private int nvPioche;

        public Case Case { get => _case; set => _case = value; }
        public int NvPioche { get => nvPioche; set => nvPioche = value; }
        public Nain ChoixNain(List<Nain> nain)
        {
            Nain nainADeplacer = nain[0];
            for (int i = 0; i < nain.Count; i++)
            {
                if (nainADeplacer.Case.ValeurTotale > nain[i].Case.ValeurTotale)
                {
                    nainADeplacer = nain[i];
                }
            }
            return nainADeplacer;
        }
    }
}
