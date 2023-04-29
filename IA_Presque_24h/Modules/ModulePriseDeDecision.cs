using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAGraphEffect.Modules
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
        public string DeterminerNouvelleAction(string messageRecuDuServeur)
        {
            string message = "";
            if (this.ModuleMemoire.HasCarte())
            {
                message = "END";
            }
            else
            {
                message = "MAP";
            }
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
    }
}
