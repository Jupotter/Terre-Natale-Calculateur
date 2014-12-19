using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Terre_Natale_Calculateur
{
    public class ClassManager : IClassManager
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
            using (var sr = new StreamReader(String.Format("{0}/Classes.json", Application.StartupPath)))
            {
                var list = JsonConvert.DeserializeObject<List<Classe>>(sr.ReadToEnd());


                foreach (var classe in list)
                {
                    _nextId = Math.Max(_nextId, classe.Id);
                }

                foreach (var classe in list.Where(classe => classe.Id == 0))
                {
                    classe.Id = _nextId++;
                }
                _Classes = list.ToDictionary(classe => classe.Id);
            }
        }

        public void DumpJSON()
        {
            if (_Classes == null)
                return;
            String json = JsonConvert.SerializeObject(_Classes.Values, _serializerSettings);

            using (var sw = new StreamWriter("ClassesDump.json", false))
                sw.Write(json);
        }

        public static ClassManager Instance
        {
            get { return _instance ?? (_instance = new ClassManager()); }
        }


        public void createbase()
        {
          //  _Classes.Add(0,new Classe("Guerrier",0,2,2,0,0,"N","H","N","N",Aspect.Acier,Aspect.None,"Technique de predilection","Aucun","Ambidextrie (dégats), Arme (de Prédilection), Discipline (contre attaques), Défense (parades)"));

            //DumpJSON();
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
