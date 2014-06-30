using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
namespace Terre_Natale_Calculateur
{
    class Race
    {
        public int Id = 0;
        public string name;
        public List<int> talents = new List<int>();
        public Dictionary<Aspect, int> aspectBonus= new Dictionary<Aspect, int>();

        public Race()
        {
           
          

            
        }


    }

    
}
