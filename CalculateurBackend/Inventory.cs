

using System;

namespace Calculateur.Backend
{
    public class Inventory
    {
        public ArmorSet Armor = new ArmorSet();

        public readonly Trinket Ring1 = new Trinket();
        public readonly Trinket Ring2 = new Trinket();
        public readonly Trinket Pendant = new Trinket();

        public event Action TrinketChanged;

        protected virtual void OnTrinketChanged()
        {
            Action handler = TrinketChanged;
            if (handler != null) handler();
        }

        public Inventory()
        {
            Ring1.MaterialChanged += OnTrinketChanged;
            Ring1.QualityChanged += OnTrinketChanged;
            Ring2.MaterialChanged += OnTrinketChanged;
            Ring2.QualityChanged += OnTrinketChanged;
            Pendant.MaterialChanged += OnTrinketChanged;
            Pendant.QualityChanged += OnTrinketChanged;
        }
    }
}
