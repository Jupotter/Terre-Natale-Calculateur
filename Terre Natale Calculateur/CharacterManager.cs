using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Terre_Natale_Calculateur
{
    class CharacterManager
    {
        private static CharacterManager _instance;

        private readonly TalentsFactory _talents;

        private CharacterManager()
        {
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
            String json = JsonConvert.SerializeObject(character);
            sw.Write(json);
            sw.Close();
        }
    }
}
