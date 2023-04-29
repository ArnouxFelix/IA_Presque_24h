using IA_Presque_24h.metier.carte;
using IA_Presque_24h.metier.nain;
using IA_Presque_24h.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_Presque_24h
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

        private List<Nain> equipe = new List<Nain>();

        private int numeroEquipe = 0;

        /// <summary>Constructeur par défaut</summary>
        public IA()
        {
            this.moduleCommunication = new ModuleCommunication(this);
            this.moduleMemoire = new ModuleMemoire(this);
            this.modulePriseDeDecisions = new ModulePriseDeDecisions(this);
            this.moduleReaction = new ModuleReaction(this);
            this.aFiniDeCommuniquer = false;
            equipe.Add(new Nain());
            
        }

        /// <summary>Démarre l'IA</summary>
        public void Start()
        {
            //Initialisation
            this.aFiniDeCommuniquer = false;
            string messageRecu = "";
            string messageEnvoye = "InsertName";


            //Mise en place de la connexion au serveur
            this.ModuleCommunication.EtablirConnexion();
            //Réception du message du serveur
            messageRecu = this.ModuleCommunication.RecevoirMessage();
            //Envoi du nom de la team
            this.moduleCommunication.EnvoyerMessage(messageEnvoye);



            //Boucle de discussion
            while (!this.aFiniDeCommuniquer)
            {
                //Réception du message du serveur
                messageRecu = this.ModuleCommunication.RecevoirMessage();
                if (messageRecu.Contains("Bonjour"))
                {
                    numeroEquipe = Convert.ToInt32(messageRecu.Split('|')[1]);
                }
                while (messageRecu.StartsWith("DEBUT_TOUR")) ;
                {
                    this.moduleCommunication.EnvoyerMessage("CARTE");
                    Carte map = new Carte(this.ModuleCommunication.RecevoirMessage());
                    if(moduleMemoire.HasCarte())
                    {
                        moduleMemoire.majCarte(map);
                    }
                    else
                    {
                        moduleMemoire.Carte = map;
                    }

                    // envoie et reception du score
                    this.ModuleCommunication.EnvoyerMessage("SCORES");
                    string stringScoreRecu = this.ModuleCommunication.RecevoirMessage();
                    string[] scoreRecu = stringScoreRecu.Split("|");
                    Console.WriteLine("||"+stringScoreRecu+"||");
                    Console.WriteLine("||"+ scoreRecu[1] + "||");
                    //Détermination des deux prochaines actions

                    for (int i = 0; i < 1; i++)
                    {
                        messageEnvoye = this.ModulePriseDeDecisions.DeterminerNouvelleAction(moduleMemoire.Carte,Convert.ToInt32(scoreRecu[1]),equipe);
                        moduleCommunication.EnvoyerMessage(messageEnvoye);
                        messageRecu = moduleCommunication.RecevoirMessage();
                        if (messageEnvoye.StartsWith("SONAR"))
                        {
                            Nain.ChoixNain(equipe).Case.Sonar(messageRecu);
                        }

                    }

                    if (messageEnvoye.Equals("END"))
                    {
                        ArreterLaCommunication();
                    }
                        
                    this.moduleCommunication.EnvoyerMessage("FIN_TOUR");
                    messageRecu = this.ModuleCommunication.RecevoirMessage();
                
                }
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
