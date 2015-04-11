using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculateur.Backend;
namespace Calculateur.ViewModel
{
    class ListeDeSort
    {
        public List<Sort> Sorts
        {
            get
            {
                return CharacterManager.Current.Grimoire().grimo;
            }
        }

    }
}
