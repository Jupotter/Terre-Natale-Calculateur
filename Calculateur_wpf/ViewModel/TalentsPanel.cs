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

        public IEnumerable<KeyValuePair<Aspect, List<Talent>>> Talents
        {
            get
            {
                if (character == null) return null;
                var talents = character.Talents;

                var ret = new Dictionary<Aspect, List<Talent>>();
                foreach (var aspect in from aspect in ((Aspect[]) Enum.GetValues(typeof (Aspect)))
                    where aspect != Aspect.None && aspect != Aspect.Equilibre
                    select aspect)
                {
                    ret[aspect] = new List<Talent>();
                    foreach (var talent in talents)
                    {
                        if (talent.PrimaryAspect == aspect && talent.SecondaryAspect == Aspect.None)
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
