using Calculateur_Backend;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Calculateur
{
    static class TextExporter
    {
        public static string ExportCharacter(Character character)
        {
            const string separator = "-------------------------------------------";
            var fiche = new List<String>
            {
                String.Format("Nom: {0}", character.Name),
                String.Format("Race: {0}", character.Race.Name),
                String.Format("Classe: {0}", character.getClasse()),
                String.Format("Niveau: {0}", character.GetLevel())
            };
            fiche.Add(separator);
            fiche.AddRange(
                new[] {Aspect.Eau, Aspect.Feu, Aspect.Terre, Aspect.Vent, Aspect.Acier, Aspect.Arcane, Aspect.Equilibre}
                    .Select(item => String.Format("{0} : {1}", item, character.GetAspectValue(item)))
                    );

            fiche.Add(separator);
            fiche.Add(String.Format("PS: {0}", character.Ps));
            fiche.Add(String.Format("PE Indemne: {0}", character.Endurance + 5 * character.GetTalent("Endurance").Level));
            fiche.Add(String.Format("PE: {0}", character.Endurance));
            fiche.Add(String.Format("PE Agonisant: {0}", character.Endurance + 7 * character.GetTalent("Volonté").Level));
            fiche.Add(String.Format("PF: {0}", character.Fatigue));
            fiche.Add(String.Format("PC: {0}", character.Chi));
            fiche.Add(String.Format("PM: {0}", character.Mana));
            fiche.Add(String.Format("PK: {0}", character.Karma()));

            fiche.Add(separator);

            fiche.AddRange(from talent in character.Talents 
                           where talent.Level > 0 
                           select String.Format("{0}: {1}", talent.Name, talent.Level)
                           );

            fiche.Add(separator);
            Classe classe = character.getClasse();
            fiche.Add("Récupération:");
            fiche.Add(String.Format("PE: {0}", classe.RPE));
            fiche.Add(String.Format("PF: {0}", classe.RPF));
            fiche.Add(String.Format("PC: {0}", classe.RPC));
            fiche.Add(String.Format("PM: {0}", classe.RPM));

            fiche.Add(separator);

            fiche.Add("Sauvegardes:");
            fiche.Add(String.Format("Reflexe: {0}", character.Reflex));
            fiche.Add(String.Format("Robustesse: {0}", character.Robustesse));
            fiche.Add(String.Format("Volonté: {0}", character.Willpower));

            fiche.Add(separator);

            fiche.Add("Stats secondaires:");
            fiche.Add(String.Format("Pénalité de poids: {0}", character.penPoid));
            fiche.Add(String.Format("Déplacement: {0}", 3 + character.GetAspectValue(Aspect.Vent)/3 - character.penPoid));
            fiche.Add(String.Format("Initiative: {0}", character.GetAspectValue(Aspect.Vent) - character.penPoid));
            fiche.Add(String.Format("Réunion de Mana: {0}", 6 - character.penPoid));
            fiche.Add(String.Format("Impulsion de Mana: {0}", 5 + character.GetAspectValue(Aspect.Vent)));

            return string.Join(Environment.NewLine, fiche);
        }
    }
}
