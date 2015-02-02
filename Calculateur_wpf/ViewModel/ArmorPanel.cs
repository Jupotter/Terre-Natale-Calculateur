using Microsoft.Practices.Prism.Mvvm;
using System.Collections.Generic;

namespace Calculateur_wpf.ViewModel
{
    class ArmorPanel : BindableBase
    {
        public enum ArmorType
        {
            Tissus,
            Cuir,
            Maille,
            Plaque
        }

        public static IEnumerable<ArmorType> ArmorTypes
        {
            get { return new[] {ArmorType.Tissus, ArmorType.Cuir, ArmorType.Maille, ArmorType.Plaque}; }
        }
    }
}
