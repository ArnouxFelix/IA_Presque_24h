using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAGraphEffect.Modules
{
    /// <summary>
    /// Classe abstraite de module. Un module est une partie de l'IA.
    /// </summary>
    public abstract class Module
    {

        /// <summary>L'IA dont ce module dépend</summary>
        private IA ia;

        /// <summary>Module en charge de la communication avec le serveur</summary>
        public ModuleCommunication ModuleCommunication => this.ia.ModuleCommunication;
        
        /// <summary>Module en charge de mémoriser les informations nécessaires au fonctionnement de l'IA</summary>
        public ModuleMemoire ModuleMemoire => this.ia.ModuleMemoire;
        
        /// <summary>Module en charge de prendre les décisions</summary>
        public ModulePriseDeDecisions ModulePriseDeDecisions => this.ia.ModulePriseDeDecisions;
        
        /// <summary>Module en charge de réagir aux réponses du serveur</summary>
        public ModuleReaction ModuleReaction => this.ia.ModuleReaction;

        /// <summary>Méthode appelée quand on souhaite arrêter la communication avec le serveur</summary>
        protected void ArreterLaCommunication()
        {
            this.ia.ArreterLaCommunication();
        }

        /// <summary>Constructeur par défaut</summary>
        /// <param name="ia">L'ia dont dépend le module</param>
        public Module(IA ia)
        {
            this.ia = ia;
        }
    }
}
