
using System;

namespace Calculateur_Backend
{
    public class ArmorPiece
    {
        public enum ArmorType { Aucune, Leger, Intermediaire, Lourde };

        ArmorType type = ArmorType.Aucune;
        private int quality = 0;

        public ArmorType Type {
            get { return type; }
            set { type = value; }
        }

        public int Quality
        {
            get { return quality; }
            set
            {
                value = Math.Max(0, value);
                value = Math.Min(5, value);
                quality = value;
            }
        }}
}
