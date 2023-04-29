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

        private TypeCase type;

        private Coordonnees coordonnees;

        private int butin;

        private int valeurTotale;

        public int ValeurCase
        {
            get
            {
                int valeur = 0;
                switch (type)
                {
                    case TypeCase.RIEN:
                        valeur = 0;
                        break;
                    case TypeCase.FER:
                        valeur = butin * 10;
                        break;
                    case TypeCase.OR:
                        valeur = butin * 20;
                        break;
                    case TypeCase.DIAMANT:
                        valeur = butin * 40;
                        break;
                    case TypeCase.MITHRIL:
                        valeur = butin * 80;
                        break;
                }
                return valeur;
            }
        }


        public Case(Coordonnees coordonnees, TypeCase typeCase, int aJoueur, int profondeur, int butin)
        {
            this.Type = typeCase;
            this.Coordonnees = coordonnees;
            this.Profondeur = profondeur;
            this.butin = butin;

            if (aJoueur < 0)
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
        public TypeCase Type { get => type; set => type = value; }
        public Coordonnees Coordonnees { get => coordonnees; set => coordonnees = value; }
        public int ValeurTotale
        {
            get
            {
                if (valeurTotale == 0)
                    valeurTotale = ValeurCase;
                return valeurTotale;
            }
            set => valeurTotale = value;
        }
    
    

        public void Sonar(string messageRecu)
        {
            valeurTotale = 0;
            string[] sonar = messageRecu.Split('|');
            foreach (string sonarStr in sonar)
            {
                if (Convert.ToInt32(sonarStr) >= 0)
                {
                    valeurTotale += Convert.ToInt32(sonarStr);
                }
                else
                {
                    valeurTotale += -1000;
                }
            }
        }
    }


}


    

