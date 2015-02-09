using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terre_Natale_Calculateur;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Calculateur_Backend
{
   public class Bijouxmanager
    {
        private static Bijouxmanager instance;
        List<MatiereBijoux> lmat = new List<MatiereBijoux>();

        public Bijouxmanager()
        {
            baseMat();
        }
        public void Initialize()
        {
            //if(!File.Exists(String.Format("{0}/Bijoux.json", System.AppDomain.CurrentDomain.BaseDirectory))
            using (var sr = new StreamReader(String.Format("{0}/Bijoux.json", System.AppDomain.CurrentDomain.BaseDirectory)))
            {
                var list = JsonConvert.DeserializeObject<List<MatiereBijoux>>(sr.ReadToEnd());

                lmat = list;
            }
        }
        public void baseMat()
        {
            lmat.Add(new MatiereBijoux() { name = "Aigue-Marine", primaire = Aspect.Eau, secondaire = Aspect.Vent, element = "Eau", talent = "Plagia", stat1 = "PE", stat2 = "PC", effetSpecial = "?" });
            lmat.Add(new MatiereBijoux() { name = "Alexandrite", primaire = Aspect.Terre, secondaire = Aspect.Feu, element = "Terre & Feu", talent = "Perception", stat1 = "PC", stat2 = "", effetSpecial = "?" });
      
        }
        public static Bijouxmanager Instance
        {
            get { return instance ?? (instance = new Bijouxmanager()); }
        }
       public List<MatiereBijoux> getMat()
        {
            return lmat;
        }
       public MatiereBijoux getFromName(String name)
       {
           foreach (MatiereBijoux item in lmat)
           {
               if (item.name == name) return item;
           }
           return null;
       }
    }
}
