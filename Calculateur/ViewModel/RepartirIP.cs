using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculateur.Backend;
using Microsoft.Practices.Prism.Mvvm;

namespace Calculateur.ViewModel
{
    class RepartirIP:BindableBase
    {
        List<SpellComposant> used;
        public List<SpellComposant> Used
        {
            get
            {
                return used;
            }
        }
        
        public RepartirIP()
        {

        }
        public RepartirIP(List<SpellComposant> compos)
        {
            used = compos;
      
        }
    }
}
