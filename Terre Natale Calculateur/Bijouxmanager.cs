using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Calculateur_Backend
{
   public class Bijouxmanager
    {
        private static Bijouxmanager instance;
        List<MatiereBijoux> lmat = new List<MatiereBijoux>();
        private JsonSerializerSettings _serializerSettings;
        public Bijouxmanager()
        {
            
        }
        public void Initialize()
        {
            Load();
        }
        public void baseMat()
        {
            lmat.Add(new MatiereBijoux() { name = "Aigue-Marine", primaire = Aspect.Eau, secondaire = Aspect.Vent, element = "Eau", talent = "Plagia", stat1 = "PE", stat2 = "PC", effetSpecial = "?" });
            lmat.Add(new MatiereBijoux() { name = "Alexandrite", primaire = Aspect.Terre, secondaire = Aspect.Feu, element = "Terre & Feu", talent = "Perception", stat1 = "PC", stat2 = "", effetSpecial = "?" });
            dumpjson();
        }
       public void dumpjson()
        {
            MemoryTraceWriter _traceWriter = new MemoryTraceWriter();
            _serializerSettings = new JsonSerializerSettings()
            {
                Error = (sender, args) => Console.Write(args.ErrorContext.Error),
                Formatting = Formatting.Indented,
                TraceWriter = _traceWriter,
            };
            

            if (lmat == null)
                return;
            String json = JsonConvert.SerializeObject(lmat, _serializerSettings);

            using (var sw = new StreamWriter("MatiereBijoux.json", false))
                sw.Write(json);
        }

       public void Load()
       {
           using (var sr = new StreamReader(String.Format("{0}/MatiereBijoux.json", System.AppDomain.CurrentDomain.BaseDirectory)))
           {
               var mat = JsonConvert.DeserializeObject<List<MatiereBijoux>>(sr.ReadToEnd());
               lmat=(mat);
           }
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
