using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
namespace Calculateur.Backend
{
   public class spellcomposantManager
    {
        public List<SpellComposant> _spellCompo = new List<SpellComposant>();
        private static spellcomposantManager _instance;
        public static spellcomposantManager Instance
        {
            get { return _instance ?? (_instance = new spellcomposantManager()); }
        }

        public void Initialize()
        {
            if (File.Exists(String.Format("{0}/Composant.json", Application.StartupPath)))
            {
                using (var sr = new StreamReader(String.Format("{0}/Composant.json", Application.StartupPath)))
                {
                    var list = JsonConvert.DeserializeObject<List<SpellComposant>>(sr.ReadToEnd());



                    _spellCompo = list;
                }
            }
            else
            {
                _spellCompo = new List<SpellComposant>();
            }
            if(_spellCompo.Count==0)
            {
                _spellCompo.Add(new SpellComposant(typeComposant.Effet,
                    "Dégat de feu %ip%, dégat de base : %ip2% + Cataliseur",
                    130,
                    30,
                    Ecole.Destruction,
                    new Element[] { Element.Feu }.ToList(),
                    0,
                    TypeIp.Getter,
                    0,
                    1,
                    4,
                    1));
                DumpJSON();
            }
        }
        public void DumpJSON()
        {
            MemoryTraceWriter _traceWriter = new MemoryTraceWriter();
            JsonSerializerSettings _serializerSettings = new JsonSerializerSettings()
            {
                Error = (sender, args) => Console.Write(args.ErrorContext.Error),
                Formatting = Formatting.Indented,
                TraceWriter = _traceWriter
            };
            if (_spellCompo == null)
                return;
            String json = JsonConvert.SerializeObject(_spellCompo, _serializerSettings);

            using (var sw = new StreamWriter("CompoDump.json", false))
            {
                sw.Write(json);
                sw.Close();
            }
            
        }
    }
}
