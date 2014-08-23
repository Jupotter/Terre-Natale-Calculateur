using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.IO;

namespace Terre_Natale_Calculateur
{
    internal class ClassManager
    {
        private readonly JsonSerializerSettings _serializerSettings;
        public Dictionary<int, Classe> _Classes = new Dictionary<int, Classe>();
        private static ClassManager _instance;
        private readonly ITraceWriter _traceWriter;
        int _nextId;
        private ClassManager()
        {

            _traceWriter = new MemoryTraceWriter();
            _serializerSettings = new JsonSerializerSettings()
            {
                Error = (sender, args) => Console.Write(args.ErrorContext.Error),
                Formatting = Formatting.Indented,
                TraceWriter = _traceWriter
            };
        }
        public void Initialize()
        {


            var sr = new StreamReader("Classes.json");
            var list = JsonConvert.DeserializeObject<List<Classe>>(sr.ReadToEnd());

            foreach (var classe in list)
            {
                _nextId = Math.Max(_nextId, classe.Id);
            }

            foreach (var classe in list.Where(Classe => Classe.Id == 0))
            {
                classe.Id = _nextId++;
            }
            _Classes = list.ToDictionary(Classe => Classe.Id);
            sr.Close();

            //createbase();
        }

        public void DumpJSON()
        {
            if (_Classes == null)
                return;
            String json = JsonConvert.SerializeObject(_Classes.Values, _serializerSettings);
            var sw = new StreamWriter("ClassesDump.json", false);
            sw.Write(json);
            sw.Close();
        }

        public static ClassManager Instance
        {
            get { return _instance ?? (_instance = new ClassManager()); }
        }


        public void createbase()
        {
            _Classes.Add(0,new Classe("Guerrier",0,2,2,0,0,"N","H","N","N",Aspect.Acier,Aspect.None,"Technique de predilection","Aucun","Ambidextrie (dégats), Arme (de Prédilection), Discipline (contre attaques), Défense (parades)"));

            DumpJSON();
        }
        public Classe getFormName(string search)
        {
            for (int i = 1; i < _Classes.Count; i++)
            {
                if (_Classes.ElementAt(i).Value.Nom == search) return _Classes.ElementAt(i).Value;
            }
            return _Classes[1];
        }
    }
}
