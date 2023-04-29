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

        private int butin;

        public Case(Coordonnees coordonnees, TypeCase typeCase, int aJoueur, int profondeur, int butin)
        {
            this.TypeCase = typeCase;
            this.Coordonnees = coordonnees;
            this.Profondeur = profondeur;
            this.butin = butin;

            if(aJoueur < 0)
            {
                this.Joueur = false;
            }
            else
            {
                this.Joueur = true;
            }
        }

        public int Profondeur { get => profondeur; set => profondeur = value; }
        public bool Joueur { get => joueur; set => joueur = value; }
        public TypeCase TypeCase { get => typeCase; set => typeCase = value; }
        public Coordonnees Coordonnees { get => coordonnees; set => coordonnees = value; }
    }
}
