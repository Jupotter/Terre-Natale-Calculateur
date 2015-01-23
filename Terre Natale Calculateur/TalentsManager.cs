using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace Terre_Natale_Calculateur
{
    internal class TalentsManager : ITalentsManager
    {
        public static event Action TalentsLoaded;

        private static void OnTalentsLoaded()
        {
            Action handler = TalentsLoaded;
            if (handler != null) handler();
        }

        private static TalentsManager _instance;

        public static TalentsManager Instance
        {
            get { return _instance ?? (_instance = new TalentsManager()); }
        }

        private IDictionary<int, Talent> _talents;
        private int _nextId = 1;
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly ITraceWriter _traceWriter;

        private TalentsManager()
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
            using (var sr = new StreamReader(String.Format("{0}/Talents.json", Application.StartupPath)))
            {
                var list = JsonConvert.DeserializeObject<List<Talent>>(sr.ReadToEnd());
                if (_talents != null && _talents.Count > 0) _talents.Clear();
                foreach (var talent in list)
                {
                    _nextId = Math.Max(_nextId, talent.Id);
                }

                foreach (var talent in list.Where(talent => talent.Id == 0))
                {
                    talent.Id = _nextId++;
                }
                _talents = list.ToDictionary(talent => talent.Id);
                foreach (var talent in _talents)
                {
                    talent.Value.reset();
                }
            }
            OnTalentsLoaded();
        }

        public IEnumerable<Talent> GetTalents()
        {
            if (_talents != null)
                return _talents.Values;
            return null;
        }

        public DataTable GetTalentsDataTable()
        {
            DataTable data = new DataTable();
            DataColumn newone = new DataColumn("Id", typeof(Int32));
            data.Columns.Add(newone);
            newone = new DataColumn("Nom", typeof(string));
            data.Columns.Add(newone);
            foreach (var item in _talents.Values)
            {
                DataRow row = data.NewRow();
                row["Id"] = item.Id;
                row["Nom"] = item.Name;
                data.Rows.Add(row);
            }
            return data;

        }
        public void DumpJSON()
        {
            if (_talents == null)
                return;
            String json = JsonConvert.SerializeObject(_talents.Values, _serializerSettings);
            using (var sw = new StreamWriter("TalentsDump.json", false))
            {
                sw.Write(json);
            }
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
       
        public Talent GetTalent(int id)
        {
            return _talents[id];
        }

        public IEnumerable<Talent> GetAllSavoir()
        {
            return (from item in _talents where item.Value.Savoir select item.Value).ToList();
        }

        public void AddTalent(Talent newone)
        {
            _nextId++;
            newone.Id = _nextId;
            _talents.Add(_nextId, newone);
            ActualizeJson();
            
        }

        private void ActualizeJson()
        {
            DumpJSON();
            if (File.Exists(string.Format("save Talents{0}_{1}.json", DateTime.Now.Day, DateTime.Now.Month)))
                File.Delete(string.Format("save Talents{0}_{1}.json", DateTime.Now.Day, DateTime.Now.Month));
            File.Move("Talents.json", string.Format("save Talents{0}_{1}.json", DateTime.Now.Day, DateTime.Now.Month));
            if (File.Exists("Talents.json"))
                File.Delete("Talents.json");
            File.Move("TalentsDump.json", "Talents.json");
        }
    }
}