using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Terre_Natale_Calculateur;

namespace Calculateur_wpf.ViewModel
{
    class TalentGroupBox : BindableBase
    {
        public delegate bool TalentTest(Talent t);

        private Character character;
        private TalentTest talentTest;

        private TalentGroupBox()
        {
            CharacterManager.CharacterChanged += CharacterManager_OnCharacterChanged;
        }

        public TalentGroupBox(Character character)
            : this()
        {
            this.character = character;
        }

        public IEnumerable<TalentBox> Talents
        {
            get
            {
                if (character == null)
                    return null;
                var ret = (from talent in character.Talents where talentTest(talent) select new TalentBox(talent, character)).ToList();
                return ret.Count == 0 ? null : ret;
            }
        }

        public String Name { get; set; }

        public void SetTalentsOption(TalentTest test)
        {
            talentTest = test;
        }

        private void CharacterManager_OnCharacterChanged(Character caller)
        {
            character = caller;
            OnPropertyChanged(null);
        }
    }
}