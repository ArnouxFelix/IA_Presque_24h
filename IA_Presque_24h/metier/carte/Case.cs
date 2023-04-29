using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_Presque_24h.metier.carte
{
    public class Case
    {
        private int profondeur;

        private bool joueur;

        private TypeCase typeCase;

        private Coordonnees coordonnees;

        public Case(Coordonnees coordonnees, TypeCase typeCase, int aJoueur, int profondeur)
        {
            this.typeCase = typeCase;
            this.coordonnees = coordonnees;
            this.profondeur = profondeur;

            if(aJoueur < 0)
            {
                this.joueur = false;
            }
            else
            {
                this.joueur = true;
            }
        }
    }
}
