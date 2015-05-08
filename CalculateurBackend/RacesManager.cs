using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace Calculateur.Backend
{

    public class RacesManager : IRacesManager
    {


        private static RacesManager _instance;

        public static RacesManager Instance
        {
            get { return _instance ?? (_instance = new RacesManager()); }
        }

        private IDictionary<int, Race> _races;
        private int _nextId = 1;
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly ITraceWriter _traceWriter;



        private RacesManager()
        {
            _traceWriter = new MemoryTraceWriter();
            _serializerSettings = new JsonSerializerSettings()
            {
                Error = (sender, args) => Log.Logger.Write(args.ErrorContext.Error.Message),
                Formatting = Formatting.Indented,
                TraceWriter = _traceWriter,
                MissingMemberHandling = MissingMemberHandling.Error,
            };
        }

        public void Initialize()
        {
            using (var sr = new StreamReader(String.Format("{0}/Races.json", AppDomain.CurrentDomain.BaseDirectory)))
            {
                var list = JsonConvert.DeserializeObject<List<Race>>(sr.ReadToEnd(), _serializerSettings);

                foreach (var talent in list)
                {
                    _nextId = Math.Max(_nextId, talent.Id);
                }

                foreach (var talent in list.Where(talent => talent.Id == 0))
                {
                    talent.Id = _nextId++;
                }
                _races = list.ToDictionary(talent => talent.Id);
            }
        }

        public void DumpJSON()
        {
            if (_races == null)
                return;
            String json = JsonConvert.SerializeObject(_races.Values, _serializerSettings);
            using (var sw = new StreamWriter("RaceDump.json", false))
            {
                sw.Write(json);
            }
        }

        public Race GetRace(int Id)
        {
            if (Id < 1 || Id >_races.Count)
                return null;
            try
            {
                if (_races != null)
                    return _races[Id];
            }
            catch (KeyNotFoundException e)
            {
                Log.Logger.WriteException(e);
            }
            return null;
        }

        public IDictionary<int, Race> CreateSet()
        {
           // IDictionary<int, Talent> ret = new Dictionary<int, Talent>();

           
            return _races;
        }
        public DataTable GetTalents()
        {
            DataTable data = new DataTable();
            DataColumn newone = new DataColumn("Id", typeof(Int32));
            data.Columns.Add(newone);
            newone = new DataColumn("Nom", typeof(string));
            data.Columns.Add(newone);
            foreach (var item in _races.Values)
            {
                DataRow row = data.NewRow();
             //   row["Id"] = item.Id;
             //   row["Nom"] = item.Name;
                data.Rows.Add(row);
            }
            return data;

        }
    }
}