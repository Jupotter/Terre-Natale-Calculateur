﻿using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
namespace Terre_Natale_Calculateur
{

    class RacesManager
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
                Error = (sender, args) => Console.Write(args.ErrorContext.Error),
                Formatting = Formatting.Indented,
                TraceWriter = _traceWriter
            };
        }

        public void Initialize()
        {
            var sr = new StreamReader("Races.json");
            var list = JsonConvert.DeserializeObject<List<Race>>(sr.ReadToEnd());

            foreach (var talent in list)
            {
                _nextId = Math.Max(_nextId, talent.Id);
            }

            foreach (var talent in list.Where(talent => talent.Id == 0))
            {
                talent.Id = _nextId++;
            }
            _races = list.ToDictionary(talent => talent.Id);
            sr.Close();
        }

        public void DumpJSON()
        {
            if (_races == null)
                return;
            String json = JsonConvert.SerializeObject(_races.Values, _serializerSettings);
            var sw = new StreamWriter("TalentsDump.json", false);
            sw.Write(json);
            sw.Close();
        }

        public Race GetRace(int Id)
        {
            if (_races != null)
                return _races[Id];
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