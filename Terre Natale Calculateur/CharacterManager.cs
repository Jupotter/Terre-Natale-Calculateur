using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ErrorEventArgs = Newtonsoft.Json.Serialization.ErrorEventArgs;

namespace Terre_Natale_Calculateur
{
    class CharacterManager
    {
        private static CharacterManager _instance;

        private readonly TalentsFactory _talents;
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly ITraceWriter _traceWriter;

        private CharacterManager()
        {
            _traceWriter = new MemoryTraceWriter();
            _serializerSettings = new JsonSerializerSettings()
            {
                Error = (sender, args) => Console.Write(args.ErrorContext.Error),
                Formatting = Formatting.Indented,
                TraceWriter = _traceWriter,
            };
            _talents = new TalentsFactory();
        }

        public static CharacterManager Instance
        {
            get { return _instance ?? (_instance = new CharacterManager()); }
        }

        public Character Create(String name)
        {
            var character = new Character(name, _talents);
            return character;
        }

        public void Save(Character character, String filename)
        {
            var sw = new StreamWriter(filename, false);
            String json = JsonConvert.SerializeObject(character.GetSerializableCharacter(), _serializerSettings);
            sw.Write(json);
            sw.Close();
        }

        public Character Load(String filename)
        {
            var sr = new StreamReader(filename);
            var character = JsonConvert.DeserializeObject<SerializableCharacter>(sr.ReadToEnd(), 
                _serializerSettings);
            Console.WriteLine(_traceWriter);
            return new Character(character);
        }
    }
}
