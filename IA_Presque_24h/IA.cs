﻿using IAGraphEffect.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAGraphEffect
{
    /// <summary>
    /// Cette classe représente le coeur de l'IA. Elle joue un rôle de "médiateur" entre les différents modules.
    /// </summary>
    public class IA
    {
        /// <summary>Module en charge de la communication avec le serveur</summary>
        private readonly ModuleCommunication moduleCommunication;
        public ModuleCommunication ModuleCommunication => moduleCommunication;

        /// <summary>Module en charge de mémoriser les informations nécessaires au fonctionnement de l'IA</summary>
        private readonly ModuleMemoire moduleMemoire;
        public ModuleMemoire ModuleMemoire => moduleMemoire;

        /// <summary>Module en charge de prendre les décisions</summary>
        private readonly ModulePriseDeDecisions modulePriseDeDecisions;
        public ModulePriseDeDecisions ModulePriseDeDecisions => modulePriseDeDecisions;

        /// <summary>Module en charge de réagir aux réponses du serveur</summary>
        private readonly ModuleReaction moduleReaction;
        public ModuleReaction ModuleReaction => moduleReaction;

        private bool aFiniDeCommuniquer;



        /// <summary>Constructeur par défaut</summary>
        public IA()
        {
            this.moduleCommunication = new ModuleCommunication(this);
            this.moduleMemoire = new ModuleMemoire(this);
            this.modulePriseDeDecisions = new ModulePriseDeDecisions(this);
            this.moduleReaction = new ModuleReaction(this);
            this.aFiniDeCommuniquer = false;
        }

        /// <summary>Démarre l'IA</summary>
        public void Start()
        {
            //Initialisation
            this.aFiniDeCommuniquer = false;
            string messageRecu = "";
            string messageEnvoye = "";


            //Mise en place de la connexion au serveur
            this.ModuleCommunication.EtablirConnexion();

            //Boucle de discussion
            while (!this.aFiniDeCommuniquer)
            {
                //Réception du message du serveur
                messageRecu = this.ModuleCommunication.RecevoirMessage();
                //Réaction au message 
                this.ModuleReaction.ReagirAuMessageRecu(messageEnvoye, messageRecu);
                //Détermination de la prochaine action
                messageEnvoye = this.ModulePriseDeDecisions.DeterminerNouvelleAction(messageRecu);

                if (messageEnvoye.Equals("END"))
                {
                    ArreterLaCommunication();
                }
                //Envoi du message au serveur
                this.moduleCommunication.EnvoyerMessage(messageEnvoye);
            }

            //Réception du dernier message de l'IA avant fermeture de la connexion
            this.moduleCommunication.RecevoirMessage();
            //Fermeture de la connexion
            this.ModuleCommunication.FermerConnexion();
        }

        /// <summary>Méthode appelée quand on souhaite arrêter la communication avec le serveur</summary>
        public void ArreterLaCommunication()
        {
            this.aFiniDeCommuniquer = true;
        }
    }
}