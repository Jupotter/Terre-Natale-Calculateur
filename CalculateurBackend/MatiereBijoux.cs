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

       public List<bonusRessource> getRessourceBonus(int quality)
       {
           List<bonusRessource> result = new List<bonusRessource>();

           if (stat2 == null || stat2 == "")
           {
               if (stat1 == "PE" || stat1 == "PM")
               {
                   result.Add(new bonusRessource() { nom = stat1, value = quality * 3 });
               }
               else
               {
                   result.Add(new bonusRessource() { nom = stat1, value = (int)Math.Floor(quality*1.5) });
               }
           }
           else
           {
               if (stat1 == "PE" || stat1 == "PM")
               {
                   result.Add(new bonusRessource() { nom = stat1, value = quality * 2 }); 
               }
               else { 
                   result.Add(new bonusRessource() { nom = stat1, value = quality }); 
               }
               if (stat2 == "PE" || stat2 == "PM")
               { 
                   result.Add(new bonusRessource() { nom = stat1, value = quality * 2 });
               }
               else
               { 
                   result.Add(new bonusRessource() { nom = stat1, value = quality }); 
               }
           }
           return result;
       }
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
        public int havebonusOnRessource(string ressource,int quality)
        {
            int r = 0;
            List<bonusRessource> br = getRessourceBonus(quality);

            if (stat1 == ressource) r = br[0].value;
            if (stat2 == ressource) r = br[1].value;

            return r;
        }
    }
    public struct bonusAspect
    {
        public Aspect nom;
        public int value;
    }
    public struct bonusRessource
    {
        public string nom;
        public int value;
    }
}
