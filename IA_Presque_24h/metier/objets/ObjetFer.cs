using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_Preque_24h.metier.objets
{
    public class ObjetFer : Objet
    {
        private Case position;

        public ObjetFer(Case position) : base(position)
        {
            this.position = position;
        }

        public override TypeObjet Type => TypeObjet.FER;
    }
}
