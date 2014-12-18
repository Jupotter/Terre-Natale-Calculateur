using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using Terre_Natale_Calculateur;

namespace Calculateur_wpf.ViewModel
{
    class TalentsPanel : BindableBase
    {
        private Character character;

        public IEnumerable<TalentGroupBox> TalentsGeneraux
        {
            get
            {
                if (character == null) return null;
                var talents = character.Talents;

                var ret = new List<TalentGroupBox>();
                foreach (var aspect in new[] { Aspect.Eau, Aspect.Feu, Aspect.Terre, Aspect.Vent, Aspect.Acier, Aspect.Arcane })
                {
                    var box = new TalentGroupBox(character);
                    var local = aspect;
                    box.SetTalentsOption(talent => talent.PrimaryAspect == local && talent.SecondaryAspect == Aspect.None && !talent.Savoir);
                    box.Name = String.Format("Talents de {0}", aspect);
                    ret.Add(box);
                }
                return ret;
            }
        }

        public IEnumerable<TalentGroupBox> TalentsAptitude
        {
            get
            {
                if (character == null)
                    return null;
                var talents = character.Talents;

                var ret = new List<TalentGroupBox>();
                foreach (var aspect in new[]{Aspect.Acier,Aspect.Arcane})
                {
                    var box = new TalentGroupBox(character);
                    var local = aspect;
                    box.SetTalentsOption(talent => talent.PrimaryAspect == local && talent.Type == TalentType.Aptitude && !talent.Savoir);
                    box.Name = String.Format("Aptitude de {0}", aspect);
                    ret.Add(box);
                }
                return ret;
            }
        }

        public TalentsPanel()
        {
            CharacterManager.CharacterChanged += CharacterManager_OnCharacterChanged;
        }

        private void CharacterManager_OnCharacterChanged(Character caller)
        {
            character = caller;
            OnPropertyChanged(null);
        }
    }
}
