using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_Presque_24h.metier.carte
{
    public class Carte
    {
        private List<Case> listCase;

        public List<Case> ListCase { get => listCase; set => listCase = value; }

        public Carte(string messageRecu)
        {
            string[] tableauCases = messageRecu.Split('|');
            ListCase = new List<Case>();
            if (tableauCases.Length == 36)
            {
                for (int i = 0; i < tableauCases.Length; i++)
                {
                    Coordonnees coordonnees = new Coordonnees(i % 6, i / 6);
                    string[] tabCase = tableauCases[i].Split(';');
                    TypeCase typeCase = ReturnType(tabCase[3]);
                    Case cases = new Case(coordonnees, typeCase, Convert.ToInt32(tabCase[4]), Convert.ToInt32(tabCase[1]));
                    ListCase.Add(cases);
                }
            }
            else
            {

            }

        }


        public TypeCase ReturnType(string Type)
        {
            TypeCase typeCase = TypeCase.RIEN;

            switch (Type)
            {
                case "FER": typeCase = TypeCase.FER;
                    break;
                case "OR": typeCase = TypeCase.OR;
                    break;
                case "DIAMANT": typeCase = TypeCase.DIAMANT;
                    break;
                case "MITHRIL": typeCase = TypeCase.MITHRIL;
                    break;
            }
            return typeCase;
        }
    }

}