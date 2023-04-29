using System;


namespace IA_Preque_24h.metier.objets
{
    public class ObjetRien : Objet
    {
        private Case position;

        /// <summary>Methode en charge d'enregistrer la position de l'objet diamant</summary>
        public ObjetRien(Case position) : base(position)
        {
            this.position = position;
        }

        public override TypeObjet Type => TypeObjet.RIEN;
    }
}
