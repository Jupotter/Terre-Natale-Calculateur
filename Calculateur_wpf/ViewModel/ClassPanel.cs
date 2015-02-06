using Calculateur_Backend;
using Microsoft.Practices.Prism.Mvvm;
using System.Collections.Generic;
using System.Text;

namespace Calculateur.ViewModel
{
    internal class ClassPanel : BindableBase
    {
        private Character character;

        public bool CanChangeClass
        {
            get { return CharacterManager.Current != null; }
        }

        public Classe SelectedClasse
        {
            get { return character == null ? null : character.getClasse(); }
            set
            {
                character.SetClasse(value);
                OnPropertyChanged(null);
            }
        }

        public IEnumerable<Classe> classes
        {
            get { return ClassManager.Instance._Classes.Values; }
        }

        public string Recuperations
        {
            get
            {
                if (SelectedClasse == null)
                    return "";
                Classe classe = SelectedClasse;
                var stringBuilder = new StringBuilder();
                if (classe.RPE != 0)
                {
                    stringBuilder.AppendFormat("PE +{0}", classe.RPE);
                }
                if (classe.RPC != 0)
                {
                    if (stringBuilder.Length != 0)
                        stringBuilder.Append(", ");
                    stringBuilder.AppendFormat("PC +{0}", classe.RPC);
                }
                if (classe.RPF != 0)
                {
                    if (stringBuilder.Length != 0)
                        stringBuilder.Append(", ");
                    stringBuilder.AppendFormat("PF +{0}", classe.RPF);
                }
                if (classe.RPM != 0)
                {
                    if (stringBuilder.Length != 0)
                        stringBuilder.Append(", ");
                    stringBuilder.AppendFormat("PM +{0}", classe.RPM);
                }
                return stringBuilder.ToString();
            }
        }

        public string Ressources
        {
            get
            {
                if (SelectedClasse == null)
                    return "";

                var stringBuilder = new StringBuilder();
                Classe classe = SelectedClasse;

                stringBuilder.Append(string.Join(", ", classe.StatBonus));
                switch (classe.StatBonus.Count)
                {
                    case 1:
                        stringBuilder.Append(" (Solo)");
                        break;
                    case 2:
                        stringBuilder.Append(" (Duo)");
                        break;
                    case 3:
                        stringBuilder.Append(" (Trio)");
                        break;
                    case 4:
                        stringBuilder.Append(" (Quatuor)");
                        break;
                }
                return stringBuilder.ToString();
            }
        }

        public string Sauvegardes
        {
            get
            {
                if (SelectedClasse == null)
                    return "";

                Classe classe = SelectedClasse;

                return string.Join(" / ", classe.SauvBonus);
            }
        }

        public string MaitriseBase
        {
            get
            {
                if (SelectedClasse == null)
                    return "";

                Classe classe = SelectedClasse;

                return classe.Maitrise_de_base;
            }
        }

        public string MaitriseSpeciale
        {
            get
            {
                if (SelectedClasse == null)
                    return "";

                Classe classe = SelectedClasse;

                return classe.MaitriseSpecial;
            }
        }

        public int Competences
        {
            get
            {
                if (character == null)
                    return 0;
                return character.GetTalent("Apprentissage").Level
                    + character.GetTalent("Maitrise").Level
                    + character.GetLevel()/2;
            }
        }

        public ClassPanel()
        {
            CharacterManager.CharacterChanged += CharacterManager_OnCharacterChanged;
        }

        private void CharacterManager_OnCharacterChanged(Character caller)
        {
            character = caller;
            SelectedClasse = character.getClasse();
            OnPropertyChanged(null);
        }
    }
}
