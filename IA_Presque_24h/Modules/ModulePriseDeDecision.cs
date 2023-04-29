using IA_Presque_24h.metier.carte;
using IA_Presque_24h.metier.nain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
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

        Random rand = new Random();
        public static int nbActionRestant = 2;
        public static int ameliorationPioche = 1;

        /// <summary>Méthode déterminant la prochaine action à réaliser</summary>
        /// <param name="messageRecuDuServeur">Le dernier message reçu du serveur</param>
        /// <returns>Le message à envoyer au serveur</returns>
        public string DeterminerNouvelleAction(string messageRecuDuServeur, int scoreJoureur)
        {
            string returning;
            if (scoreJoureur >= 200 && ameliorationPioche == 1)
            {
                returning = "AMELIORER|0";
                ameliorationPioche = 2;
                nbActionRestant--;
            }
            else if (scoreJoureur >= 250)
            {
                returning = "EMBAUCHER";
                nbActionRestant--;
            }
            else if (scoreJoureur >= 400 && ameliorationPioche == 2)
            {
                returning = "AMELIORER|0";
                ameliorationPioche = 3;
                nbActionRestant--;
            }
            else if (nbActionRestant > 0)
            {

                returning = $"DEPLACER|0|{rand.NextInt64(0, 6)}|{rand.NextInt64(0, 6)}";
                nbActionRestant--;
            }
            else
            {
                returning = "FIN_TOUR";
                nbActionRestant = 2;
            }
            return returning;
        }

        public Case DeterminerMeilleurDeplacement(Carte carte, Nain nain)
        {
            string decision = "";
            Case caseChoisi = null;
            for (int i = 0; i<carte.ListCase.Count; i++)
            {
                if(nain.Case.Coordonnees.Ligne == carte.ListCase[i].Coordonnees.Ligne &&
                    nain.Case.Coordonnees.Colonne == carte.ListCase[i].Coordonnees.Colonne)
                {
                    carte.ListCase[i].Joueur = false;
                    caseChoisi = nain.Case;
                }
            }
            
            foreach (Case cases in carte.ListCase)
            {
                if (caseChoisi == null && !cases.Joueur)
                {
                    caseChoisi = cases;
                }

                if (!cases.Joueur && cases.ValeurTotale > (caseChoisi?.ValeurTotale ?? 0))
                {
                    caseChoisi = cases;
                }
            }
            if (caseChoisi.Type == TypeCase.RIEN)
            {
                Random random = new Random();
                caseChoisi = carte.ListCase[random.Next(carte.ListCase.Count)];


            }

            return caseChoisi;

            //decision = String.Format("DEPLACER|{0}|{1}|{2}", 0, caseChoisi.Coordonnees.Colonne, caseChoisi.Coordonnees.Ligne);

            
        }
    }
}
