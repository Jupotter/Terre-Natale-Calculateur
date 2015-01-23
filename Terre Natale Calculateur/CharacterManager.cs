using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.IO;

namespace Calculateur_Backend
{
    public class CharacterManager
    {
        private static Character _current;

        public static event Character.CharacterEventHandler CharacterChanged;

        private static void OnCharacterChanged(Character caller)
        {
            Character.CharacterEventHandler handler = CharacterChanged;
            if (handler != null) handler(caller);
        }

        private static CharacterManager _instance;

        private readonly JsonSerializerSettings _serializerSettings;
        private readonly TalentsManager _talents;
        private readonly ITraceWriter _traceWriter;
        private readonly ClassManager _classes;

        private CharacterManager()
        {
            _traceWriter = new MemoryTraceWriter();
            _serializerSettings = new JsonSerializerSettings()
            {
                Error = (sender, args) => Console.Write(args.ErrorContext.Error),
                Formatting = Formatting.Indented,
                TraceWriter = _traceWriter,
            };
            _talents = TalentsManager.Instance;
            _talents.Initialize();
            _classes = ClassManager.Instance;
            _classes.Initialize();
            
        }

        public static CharacterManager Instance
        {
            get { return _instance ?? (_instance = new CharacterManager()); }
        }

        public static Character Current
        {
            get { return _current; }
            set
            {
                _current = value;
                OnCharacterChanged(_current);
            }
        }


        public Character Create(String name)
        {
            var character = new Character(name, _talents);
            Current = character;
            return character;
        }

        public Character Load(String filename)
        {
            using (var sr = new StreamReader(filename))
            {
                SerializableCharacter character;
                character = JsonConvert.DeserializeObject<SerializableCharacter>(sr.ReadToEnd(),
                    _serializerSettings);

                Current = new Character(character);
                return Current; 
            }
        }

        public void Save(Character character, String filename)
        {
            using (var sw = new StreamWriter(filename, false))
            {
                String json = JsonConvert.SerializeObject(character.GetSerializableCharacter(), _serializerSettings);
                sw.Write(json); 
            }
        }
    }
}