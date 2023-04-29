using IA_Presque_24h.metier.carte;
using System;

namespace IA_Preque_24h.metier.objets
{
    public abstract class Objet
    {
        private Case position;

        
        public Objet(Case position)
        {
            this.position = position;
        }

        public Case Position
        {
            get => position ; 
        }

        public abstract TypeObjet Type
        {
            get;
        }
    }
}