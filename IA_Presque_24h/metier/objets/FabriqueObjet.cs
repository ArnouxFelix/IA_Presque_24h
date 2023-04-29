using IA_Presque_24h.metier.carte;
using System;


namespace IA_Preque_24h.metier.objets 
{
    public class FabriqueObjet
    {
        /// <summary>Gere la creation d'objet où un objet est defini sur la carte du jeu</summary>
        /// <param name="caractere">Caractere renvoye par le serveur</param>
        /// <param name="position">Position du caractere</param>
        
        public static Objet Creer(string caractere, Case position)
        {
            Objet objet = null;

            switch (caractere)
            {
                case ("RIEN"):
                    objet = null;
                    break;
                case ("FER"):
                    objet = new ObjetFer(position);
                    break;
                case ("DIAMANT"):
                    objet = new ObjetDiamant(position);
                    break;
                case ("MITHRIL"):
                    objet = new ObjetMithril(position);
                    break;
                default:
                    objet = null;
                    break;
            }

            return objet;
        }
    }
}
