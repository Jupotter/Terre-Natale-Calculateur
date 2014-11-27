using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json.Serialization;
using System.Data;
namespace Terre_Natale_Calculateur
{
    internal class TalentsManager : ITalentsManager
    {

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
            var sr = new StreamReader("Talents.json");
            var list = JsonConvert.DeserializeObject<List<Talent>>(sr.ReadToEnd());
            if ( _talents != null && _talents.Count > 0) _talents.Clear();
            foreach (var talent in list)
            {
                _nextId = Math.Max(_nextId, talent.Id);
            }

            foreach (var talent in list.Where(talent => talent.Id == 0))
            {
                talent.Id = _nextId++;
            }
            _talents = list.ToDictionary(talent => talent.Id);
            for (int i = 1; i < _talents.Count; i++)
            {
                _talents[i].reset();
            } 
            sr.Close();
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
            var sw = new StreamWriter("TalentsDump.json", false);
            sw.Write(json);
            sw.Close();
        }

        public void ExitJSON()
        {
            if (_talents == null)
                return;
            String json = JsonConvert.SerializeObject(_talents.Values, _serializerSettings);
            var sw = new StreamWriter("NewTalents.json", false);
            sw.Write(json);
            sw.Close();
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
        public List<Talent> GetAllSavoir()
        {
            List<Talent> result = new List<Talent>();
            foreach (var item in _talents)
            {
                if (item.Value.Savoir == true)
                {
                    result.Add(item.Value);
                }
                
            }
            return result;
        }
        public void AddTalent(Talent newone)
        {
            _nextId++;
            newone.Id = _nextId;
            _talents.Add(_nextId, newone);
            ActualizeJson();
            
        }
        public void ActualizeJson()
        {
            ExitJSON();
            if (File.Exists("save Talents" + DateTime.Now.Day + "_" + DateTime.Now.Month + ".json")) File.Delete("save Talents" + DateTime.Now.Day + "_" + DateTime.Now.Month + ".json");
            File.Move("Talents.json", "save Talents" + DateTime.Now.Day + "_" + DateTime.Now.Month + ".json");
            if (File.Exists("Talents.json")) File.Delete("Talents.json");
            File.Move("NewTalents.json", "Talents.json");
        }
    }
}