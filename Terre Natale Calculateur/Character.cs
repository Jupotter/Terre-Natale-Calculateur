using System;
using System.Collections.Generic;
using System.Linq;

namespace Terre_Natale_Calculateur
{
    internal class Character
    {
        private IDictionary<Aspect, int> _aspectPoint;
        private IDictionary<String, Talent> _talents;
        public Character(string name, TalentsFactory talentsFactory)
        {
            Name = name;
            _talents = talentsFactory.CreateSet();
            foreach (var talent in _talents.Values)
            {
                talent.LevelChanged += (sender, args) => RecomputePA();
            }
            _aspectPoint = new Dictionary<Aspect, int>()
            {
                {Aspect.Acier, 30},
                {Aspect.Arcane, 30},
                {Aspect.Eau, 30},
                {Aspect.Feu, 30},
                {Aspect.Terre, 30},
                {Aspect.Vent, 30},
            };
        }

        public event EventHandler PAChanged;

        protected virtual void OnPAchanged()
        {
            EventHandler handler = PAChanged;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        public string Name { get; set; }

        public IEnumerable<Talent> Talents
        {
            get { return _talents.Values; }
        }

        public int GetAspectPoint(Aspect aspect)
        {
            return _aspectPoint[aspect];
        }

        public int GetAspectValue(Aspect aspect)
        {
            int n = 0;
            for (int i = 1; i <= 10; i++)
            {
                n += i * 10;
                if (_aspectPoint[aspect] < n)
                    return i;
            }
            return 10;
        }

        public Talent GetTalent(String name)
        {
            return _talents[name];
        }
        private void RecomputePA()
        {
            _aspectPoint = new Dictionary<Aspect, int>(6)
            {
                {Aspect.Acier, 30},
                {Aspect.Arcane, 30},
                {Aspect.Eau, 30},
                {Aspect.Feu, 30},
                {Aspect.Terre, 30},
                {Aspect.Vent, 30},
            };

            foreach (var talent in _talents.Select(talentPair => talentPair.Value))
            {
                if (Aspect.None == talent.SecondaryAspect)
                {
                    _aspectPoint[talent.PrimaryAspect] += talent.XPCost;
                }
                else
                {
                    _aspectPoint[talent.PrimaryAspect] += talent.XPCost / 2;
                    _aspectPoint[talent.SecondaryAspect] += talent.XPCost / 2;
                }
            }

            OnPAchanged();
        }
    }
}