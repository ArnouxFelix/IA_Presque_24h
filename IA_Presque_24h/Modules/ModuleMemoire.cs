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
        //private Carte carte;

        /// <summary>Constructeur par défaut</summary>
        /// <param name="ia">L'IA dont dépend le module</param>
        public ModuleMemoire(IA ia) : base(ia) 
        {
            //this.carte = null;
        }

        //public void GenererCarte(string messageRecu)
        //{
        //    this.carte = new Carte(messageRecu);
        //}

        //public bool HasCarte()
        //{
        //   return this.carte != null;
        //}
    }
}
