using Calculateur.Backend;
using Microsoft.Practices.Prism.Mvvm;

namespace Calculateur.ViewModel
{
    class MainStatsAspects : BindableBase
    {
        private readonly Character character;

        public MainStatsAspects(Character character)
        {
            this.character = character;
            character.PAChanged += caller => OnPropertyChanged(null);
        }

        public int Arcane
        {
            get { return character == null ? 0 : character.GetAspectValue(Aspect.Arcane); }
        }

        public int Acier
        {
            get { return character == null ? 0 : character.GetAspectValue(Aspect.Acier); }
        }

        public int Eau
        {
            get { return character == null ? 0 : character.GetAspectValue(Aspect.Eau); }
        }

        public int Feu
        {
            get { return character == null ? 0 : character.GetAspectValue(Aspect.Feu); }
        }

        public int Vent
        {
            get { return character == null ? 0 : character.GetAspectValue(Aspect.Vent); }
        }

        public int Terre
        {
            get { return character == null ? 0 : character.GetAspectValue(Aspect.Terre); }
        }

        public int Equilibre
        {
            get { return character == null ? 0 : character.GetAspectValue(Aspect.Equilibre); }
        }
    }
}