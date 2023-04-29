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
            string returning;
            if ((scoreJoureur >= 200) && ameliorationPioche == 1)
            {
                returning = "AMELIORER|0";
                ameliorationPioche = 2;
            }
            else if ((scoreJoureur >= 400) && ameliorationPioche == 2)
            {
                returning = "AMELIORER|0";
                ameliorationPioche = 3;
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
    }
}
