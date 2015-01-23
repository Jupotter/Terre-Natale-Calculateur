using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using Calculateur_Backend;

namespace Calculateur.ViewModel
{
    class TalentsPanel : BindableBase
    {
        private Character character;

        public IEnumerable<TalentGroupBox> TalentsGeneraux
        {
            get
            {
                if (character == null) return null;

                var ret = new List<TalentGroupBox>();
                foreach (var aspect in new[] { Aspect.Eau, Aspect.Feu, Aspect.Terre, Aspect.Vent, Aspect.Acier, Aspect.Arcane })
                {
                    var box = new TalentGroupBox(character);
                    var local = aspect;
                    box.SetTalentsOption(talent => talent.PrimaryAspect == local && talent.SecondaryAspect == Aspect.None && !talent.Savoir);
                    box.Name = String.Format("Talents de {0}", aspect);
                    ret.Add(box);
                }
                var classBox = new TalentGroupBox(character);
                classBox.SetTalentsOption(talent => talent.PrimaryAspect == Aspect.Equilibre 
                    || talent.PrimaryAspect == Aspect.None && !talent.Savoir);
                classBox.Name = "Talents de classe";
                ret.Add(classBox);
                return ret;
            }
        }

        public IEnumerable<TalentGroupBox> TalentsAptitude
        {
            get
            {
                if (character == null)
                    return null;

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

        public IEnumerable<TalentGroupBox> TalentsMartial
        {
            get
            {
                if (character == null)
                    return null;

                var ret = new List<TalentGroupBox>();
                foreach (var aspect in new[] { Aspect.Acier, Aspect.Arcane })
                {
                    var box = new TalentGroupBox(character);
                    var local = aspect;
                    box.SetTalentsOption(talent => talent.PrimaryAspect == local && talent.Type == TalentType.Martial && !talent.Savoir);
                    box.Name = String.Format("Talent de {0}", aspect);
                    ret.Add(box);
                }
                return ret;
            }
        }

        public IEnumerable<TalentGroupBox> TalentsProuesse
        {
            get
            {
                if (character == null)
                    return null;

                var ret = new List<TalentGroupBox>();
                foreach (var aspect in new[] { Aspect.Eau, Aspect.Feu, Aspect.Terre, Aspect.Vent, Aspect.Acier, Aspect.Arcane })
                {
                    var box = new TalentGroupBox(character);
                    var local = aspect;
                    box.SetTalentsOption(talent => talent.PrimaryAspect == local && talent.Type == TalentType.Prouesse && !talent.Savoir);
                    box.Name = String.Format("Prouesse de {0}", aspect);
                    ret.Add(box);
                }
                return ret;
            }
        }

        public IEnumerable<TalentGroupBox> TalentsMultiple
        {
            get
            {
                if (character == null)
                    return null;

                var ret = new List<TalentGroupBox>();
                foreach (var aspect in new[] { Aspect.Arcane })
                {
                    var box = new TalentGroupBox(character);
                    var local = aspect;
                    box.SetTalentsOption(talent => talent.PrimaryAspect == local && talent.Savoir);
                    box.Name = String.Format("Prouesse de {0}", aspect);
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
