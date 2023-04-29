using IA_Presque_24h.metier.carte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_Presque_24h.Modules
{
    /// <summary>Module en charge de mémoriser les informations dont l'IA a besoin pour fonctionner</summary>
    public class ModuleMemoire : Module
    {
        private Carte carte;

        /// <summary>Constructeur par défaut</summary>
        /// <param name="ia">L'IA dont dépend le module</param>
        public ModuleMemoire(IA ia) : base(ia) 
        {
            this.Carte = null;
        }

        public Carte Carte { get => carte; set => carte = value; }

        public void GenererCarte(string messageRecu)
        {
            this.Carte = new Carte(messageRecu);
        }

        public bool HasCarte()
        {
           return this.Carte != null;
        }

        public void majCarte(Carte nouvelleCarte)
        {
            for(int i = 0; i < this.Carte.ListCase.Count; i++)
            {
                if(this.Carte.ListCase[i].ValeurCase != this.Carte.ListCase[i].ValeurTotale)
                {
                    if (this.Carte.ListCase[i].Profondeur != nouvelleCarte.ListCase[i].Profondeur)
                    {
                        nouvelleCarte.ListCase[i].ValeurTotale -= this.Carte.ListCase[i].ValeurCase;
                    }
                }
                
            }
            this.Carte = nouvelleCarte;
        }
    }
}
