using System;
using System.Linq;
using System.Text;
using Terre_Natale_Calculateur;

namespace Calculateur_wpf
{
    class TextExporter
    {
        public static void ExportCharacter(string file, Character character)
        {
            var fiche = new StringBuilder();
            fiche.AppendFormat("Nom: {0}", character.Name);
            fiche.AppendLine();
            fiche.AppendFormat("Race: {0}", character.Race.Name);
            fiche.AppendLine();
            fiche.AppendFormat("Classe: {0}", character.getClasse());
            fiche.AppendLine();
            fiche.AppendFormat("Niveau: {0}", character.GetLevel());
            fiche.AppendLine();
            fiche.AppendLine("-----------------------------------------");
            foreach (Aspect item in Enum.GetValues(typeof(Aspect)).Cast<Aspect>().Where(item => Aspect.None != item))
            {
                fiche.AppendFormat("{0} : {1}{2}", item, character.GetAspectValue(item), Environment.NewLine);
            }
            fiche.AppendLine("-----------------------------------------");
        }
    }
}
