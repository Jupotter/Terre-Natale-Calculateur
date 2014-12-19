using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Terre_Natale_Calculateur;

namespace Calculateur_wpf.ViewModel
{
    class NewCharacter : BindableBase
    {
        private int selectedRaceId = 0;
        private int selectedTalent1 = -1;
        private int selectedTalent2 = -1;
        private string name;

        public Action CloseWindow { get; set; }

        public string Name
        {
            get { return name; }
            set
            {
                SetProperty(ref name, value);
                OnPropertyChanged(() => CharacterFinishCommand);
            }
        }

        public static IEnumerable<Race> Races
        {
            get { return RacesManager.Instance.CreateSet().Values; }
        }

        public int SelectedRaceId
        {
            get { return selectedRaceId - 1; }
            set
            {
                SetProperty(ref selectedRaceId, value + 1);
                OnPropertyChanged(() => SelectedRace);
                OnPropertyChanged(() => TalentBonus);
                OnPropertyChanged(() => SelectedRaceBonus);
                OnPropertyChanged(() => SelectedRaceBonusAspects);
                OnPropertyChanged(() => CharacterFinishCommand);
            }
        }

        private Race SelectedRace
        {
            get { return selectedRaceId == 0 ? null : RacesManager.Instance.GetRace(selectedRaceId); }
        }

        public string SelectedRaceBonus
        {
            get { return SelectedRace != null ? SelectedRace.bonusRaciaux.Replace("#", "").Replace(',', '\n') : ""; }
        }

        public List<Talent> TalentBonus
        {
            get
            {
                if (SelectedRace == null)
                    return null;
                return SelectedRace.Talents.Select(talent => TalentsManager.Instance.GetTalent(talent)).ToList();
            }
        }

        public IEnumerable<string> SelectedRaceBonusAspects
        {
            get
            {
                if (SelectedRace == null)
                    return null;
                return SelectedRace.AspectBonus.Where(keyValuePair => keyValuePair.Value != 0).Select((key, index) => String.Format("{0}: {1}", key.Key, key.Value));
            }
        }

        public int SelectedTalent1
        {
            get { return selectedTalent1; }
            set
            {
                SetProperty(ref selectedTalent1, value);
                OnPropertyChanged(() => CharacterFinishCommand);
            }
        }

        public int SelectedTalent2
        {
            get { return selectedTalent2; }
            set
            {
                SetProperty(ref selectedTalent2, value);
                OnPropertyChanged(() => CharacterFinishCommand);
            }
        }

        public DelegateCommand CharacterFinishCommand
        {
            get { return new DelegateCommand(CharacterFinish, CanCharacterFinish);}
        }

        private bool CanCharacterFinish()
        {
            return SelectedRaceId != -1 && SelectedTalent1 != -1 && SelectedTalent2 != -1 && Name != "";
        }

        private void CharacterFinish()
        {
            Character character = CharacterManager.Instance.Create(Name);
            character.SetBonus(
                SelectedRace.AspectBonus,
                new[]{ TalentBonus[SelectedTalent1], TalentBonus[SelectedTalent2] },
                SelectedRace
                );
            CloseWindow();
        }
    }
}
