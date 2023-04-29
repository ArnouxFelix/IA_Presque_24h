using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_Presque_24h.Modules
{
    /// <summary>Module en charge de gérer les réactions de l'IA à une réponse du serveur</summary>
    public class ModuleReaction : Module
    {
        /// <summary>Constructeur par défaut</summary>
        /// <param name="ia">L'IA dont dépend le module</param>
        public ModuleReaction(IA ia) : base(ia) { }

        /// <summary>Méthode réagissant à la réponse du serveur</summary>
        /// <param name="messageEnvoye">Dernier message envoyé au serveur par l'IA</param>
        /// <param name="messageRecu">Réponse du serveur à ce message</param>
        public void ReagirAuMessageRecu(string messageEnvoye, string messageRecu)
        {
            switch (messageEnvoye)
            {
                case "MAP": ReactionCarte(messageRecu); break;
            }
        }

        private void ReactionCarte(string messageRecu)
        {
            this.ModuleMemoire.GenererCarte(messageRecu);
            
        }
    }
}
