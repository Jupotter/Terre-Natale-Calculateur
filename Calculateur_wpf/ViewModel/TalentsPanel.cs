using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
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
                foreach (var aspect in from aspect in ((Aspect[]) Enum.GetValues(typeof (Aspect)))
                    where aspect != Aspect.None && aspect != Aspect.Equilibre
                    select aspect)
                {
                    var box = new TalentGroupBox(character);
                    var local = aspect;
                    box.SetTalentsOption(talent => talent.PrimaryAspect == local && talent.SecondaryAspect == Aspect.None);
                    box.Name = String.Format("Talents de {0}", aspect);
                    ret.Add(box);
                }
                return ret;
            }
        }

        public IEnumerable<KeyValuePair<Aspect, List<Talent>>> TalentsAptitude
        {
            get
            {
                if (character == null)
                    return null;
                var talents = character.Talents;

                var ret = new Dictionary<Aspect, List<Talent>>();
                foreach (var aspect in from aspect in ((Aspect[])Enum.GetValues(typeof(Aspect)))
                                       where aspect != Aspect.None && aspect != Aspect.Equilibre
                                       select aspect)
                {
                    ret[aspect] = new List<Talent>();
                    foreach (var talent in talents)
                    {
                        if (talent.PrimaryAspect == aspect && talent.Type == TalentType.Aptitude)
                            ret[aspect].Add(talent);
                    }
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
