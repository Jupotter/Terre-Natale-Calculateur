using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Terre_Natale_Calculateur
{
    internal class Character
    {
        private readonly IDictionary<String, Talent> _talents;
        private readonly IDictionary<Aspect, int> _aspectPoint;

        public event EventHandler PAchanged;

        public Character(string name, TalentsFactory talentsFactory)
        {
            Name = name;
            _talents = talentsFactory.CreateSet();
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

        public string Name { get; set; }

        public IEnumerable<Talent> Talents
        {
            get { return _talents.Values; }
        }

        public Talent GetTalent(String name)
        {
            return _talents[name];
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
                n += i*10;
                if (_aspectPoint[aspect] < n)
                    return i;
            }
            return 10;
        }

        private void RecomputePA()
        {
            foreach (var pair in _aspectPoint)
            {
                _aspectPoint[pair.Key] = 30;
            }

            foreach (var talent in _talents.Select(talentPair => talentPair.Value))
            {
                if (Aspect.None == talent.SecondaryAspect)
                {
                    _aspectPoint[talent.PrimaryAspect] += talent.XPCost;
                }
                else
                {
                    _aspectPoint[talent.PrimaryAspect] += talent.XPCost/2;
                    _aspectPoint[talent.SecondaryAspect] += talent.XPCost/2;
                }
            }

            PAchanged.Invoke(this, null);
        }
    }
}