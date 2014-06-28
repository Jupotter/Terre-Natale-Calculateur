using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Terre_Natale_Calculateur
{
    internal class TalentsManager
    {

        private static TalentsManager _instance;

        public static TalentsManager Instance
        {
            get { return _instance ?? (_instance = new TalentsManager()); }
        }

        private IDictionary<int, Talent> _talents;
        private int _nextId = 1;
        private readonly JsonSerializerSettings _serializerSettings;

        private TalentsManager()
        {
            _serializerSettings = new JsonSerializerSettings()
            {
                Error = (sender, args) => Console.Write(args.ErrorContext.Error),
                Formatting = Formatting.Indented,
            };
        }

        public void Initialize()
        {
            var sr = new StreamReader("Talents.json");
            var list = JsonConvert.DeserializeObject<List<Talent>>(sr.ReadToEnd());

            foreach (var talent in list)
            {
                _nextId = Math.Max(_nextId, talent.Id);
            }

            foreach (var talent in list.Where(talent => talent.Id == 0))
            {
                talent.Id = _nextId++;
            }
            _talents = list.ToDictionary(talent => talent.Id);
        }

        public string DumpJSON()
        {
            var ret = new Dictionary<String, Talent>();
            String json = JsonConvert.SerializeObject(ret.Values.Count, _serializerSettings);
            return json;
        }

        public IDictionary<int, Talent> CreateSet()
        {
            IDictionary<int, Talent> ret = new Dictionary<int, Talent>();

            foreach (var talent in _talents.Values)
            {
                ret.Add(talent.Id, (Talent)talent.Clone());
            }
            return ret;
        }
    }
}