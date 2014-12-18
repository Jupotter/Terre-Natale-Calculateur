using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Prism.Mvvm;
using Terre_Natale_Calculateur;

namespace Calculateur_wpf.ViewModel
{
    class NewCharacter : BindableBase
    {
        public string Name { get; set; }

        public IEnumerable<Race> Races
        {
            get { return RacesManager.Instance.CreateSet().Values; }
        }
    }
}
