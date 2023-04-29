using IA_Presque_24h.metier.carte;
using IA_Presque_24h.metier.nain;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
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
        public string DeterminerNouvelleAction(Carte carte, int scoreJoureur, List<Nain> listNain)
        {
            string returning = "";
            Nain piocheLaPlusBasse = listNain[0];
            for (int i = 0; i < listNain.Count(); i++)
            {
                if (piocheLaPlusBasse.NvPioche > listNain[i].NvPioche)
                {
                    piocheLaPlusBasse = listNain[i];
                }
            }

            if (scoreJoureur >=250 && listNain.Count() == 1)
            {
                returning = "EMBAUCHER";
            }
            else if(scoreJoureur >= 200)
            {
                switch (piocheLaPlusBasse.NvPioche)
                {
                    case 0:
                        returning = $"AMELIORER|{listNain.IndexOf(piocheLaPlusBasse)}";                   
                        break;
                    case 1:
                        if (scoreJoureur >= 400)
                        {
                            returning = $"AMELIORER|{listNain.IndexOf(piocheLaPlusBasse)}";
                      
                        }
                        break;
                }
            }
            else if(scoreJoureur >= 250 && listNain.Count() == 2)
            {
                returning = "EMBAUCHER";
            }
            else
            {
                returning = $"SONAR|{Nain.ChoixNain(listNain).Case.Coordonnees.Ligne}|{Nain.ChoixNain(listNain).Case.Coordonnees.Colonne}";
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
            if (caseChoisi.ValeurTotale <= 0)
            {               
                Random random = new Random();
                caseChoisi = carte.ListCase[random.Next(carte.ListCase.Count)];
                while (caseChoisi.Joueur)
                {
                    caseChoisi = carte.ListCase[random.Next(carte.ListCase.Count)];
                }
            }

            return caseChoisi;

            //decision = String.Format("DEPLACER|{0}|{1}|{2}", 0, caseChoisi.Coordonnees.Colonne, caseChoisi.Coordonnees.Ligne);

            
        }


        
        
    }
}
