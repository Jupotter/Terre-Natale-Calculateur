using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculateur_Backend;
namespace Calculateur_Backend
{
    public class MatiereBijoux
    {
       public string name;
       public Aspect primaire;
       public Aspect secondaire;
       public String element;
       public String talent;
       public String stat1;
       public String stat2;
       public String effetSpecial;

       public List<bonusAspect> getBonusAspect(int quality)
       {
           List<bonusAspect> result = new List<bonusAspect>();
           
           Bijouxmanager bm = Bijouxmanager.Instance;
           Character c = CharacterManager.Current;

           switch (quality)
           {
               case 1:
                   if (c.GetAspectValue(primaire,true) < 4) result.Add(new bonusAspect() { nom = primaire, value = 1 });
                   break;
               case 2:
                   if (c.GetAspectValue(primaire, true) < 6) result.Add(new bonusAspect() { nom = primaire, value = 1 });
                   if (c.GetAspectValue(secondaire, true) < 2) result.Add(new bonusAspect() { nom = secondaire, value = 1 });
                   break;
               case 3:
                   result.Add(new bonusAspect() { nom = primaire, value = 1 });
                   if (c.GetAspectValue(secondaire, true) < 4) result.Add(new bonusAspect() { nom = secondaire, value = 1 });
                   break;
               case 4:
                   result.Add(new bonusAspect() { nom = primaire, value = 1 });
                   if (c.GetAspectValue(secondaire, true) < 6) result.Add(new bonusAspect() { nom = secondaire, value = 1 });
                   break;
               case 5:
                   result.Add(new bonusAspect() { nom = primaire, value = 1 });
                   result.Add(new bonusAspect() { nom = secondaire, value = 1 });
                   break;
               default:
                   break;

           }
           return result;
       }
        public bool HaveBonusOn (Aspect aspect , int quality)
       {
           List<bonusAspect> bon = getBonusAspect(quality);
           foreach (bonusAspect item in bon)
           {
               if (item.nom == aspect) return true;
           }
           return false;
       }
    }
    public struct bonusAspect
    {
        public Aspect nom;
        public int value;
    }
}
