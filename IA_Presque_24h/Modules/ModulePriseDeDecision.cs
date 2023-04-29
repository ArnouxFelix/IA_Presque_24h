using IA_Presque_24h.metier.carte;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IA_Presque_24h.Modules
{
    /// <summary>Ce module est en charge de prendre les décisions pour l'IA (que doit je faire ?)</summary>
    public class ModulePriseDeDecisions : Module
    {
        /// <summary>Constructeur par défaut</summary>
        /// <param name="ia">Ia dont dépend le module</param>
        public ModulePriseDeDecisions(IA ia) : base(ia) { }

        /// <summary>Méthode déterminant la prochaine action à réaliser</summary>
        /// <param name="messageRecuDuServeur">Le dernier message reçu du serveur</param>
        /// <returns>Le message à envoyer au serveur</returns>
        public string DeterminerNouvelleActionIABourre(string messageRecuDuServeur)
        {
            this.ModuleMemoire.GenererCarte(messageRecuDuServeur);
            Random rand = new Random();
            int ligne = rand.Next(0, 5);
            int colonne = rand.Next(0, 5);
            string message = $"DEPLACER|0|{ligne}|{colonne}";
            if (messageRecuDuServeur.StartsWith("NOK"))
            {
                message = "FIN_TOUR";
            }
            //string message = "";
            //if (this.ModuleMemoire.HasCarte())
            //{
            //    message = "END";
            //}
            //else
            //{
            //    message = "MAP";
            //}
            /*Random rand = new Random();
            string[] tabMouv = new string[6] { "UP", "UPRIGHT", "UPLEFT", "DOWNLEFT", "DOWN", "DOWNRIGHT" };
            int mouvIndex;
            

            if (messageRecuDuServeur.Equals("OK") || messageRecuDuServeur.Equals("Debut de la partie"))
            {
                mouvIndex = rand.Next(tabMouv.Length);
                message = $"MOVE 0 {tabMouv[mouvIndex]}";
            }
            else
            {
                message = "END";
            }*/

            return message;
        }
        public string DeterminerMeilleurDeplacement(Carte carte)
        {
            string decision = "";
            Case caseChoisi = null;
            foreach (Case cases in Carte.Cases)
            {
                if (caseChoisi == null && cases.Disponible)
                {
                    caseChoisi = cases;
                }

                if (cases.Disponible && cases.Valeur > caseChoisi.Valeur)
                {
                    caseChoisi = cases;
                }
            }
            if (caseChoisi.type == type.Rien)
            {
                foreach (Case cases in Carte.Cases)
                {
                    if (cases.Disponible && cases.Profondeur > caseChoisi.Profondeur)
                    {
                        caseChoisi = cases;
                    }
                }
            }

            decision = String.Format("DEPLACER|{0}|{1}|{2}", 0, caseChoisi.Coordonnees.ligne, caseChoisi.Coordonnees.colonne);

            return decision;
        }
    }
}
