using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_Preque_24h.metier.objets
{
    public class ObjetMithril : Objet
    {
        private Case position;

        public ObjetMithril(Case position) : base(position)
        {
            this.position = position;
        }

        public override TypeObjet Type => TypeObjet.MITHRIL;
    }
}
