using Calculateur.Backend;
using Microsoft.Practices.Prism.Mvvm;
using System.Collections.Generic;
using ArmorType = Calculateur.Backend.ArmorPiece.ArmorType;

namespace Calculateur.ViewModel
{
    class ArmorPanel : BindableBase
    {
        public static IEnumerable<ArmorType> ArmorTypes
        {
            get
            {
                return new[]
                {
                    ArmorType.Aucune,
                    ArmorType.Leger,
                    ArmorType.Intermediaire,
                    ArmorType.Lourde
                };
            }
        }

        public static IEnumerable<int> Qualities
        {
            get { return new[] {0, 1, 2, 3, 4, 5}; }
        }

        private ArmorSet armorSet = new ArmorSet();

        public double ChestArmorTotal
        {
            get { return (ChestArmorQuality + (int)ChestArmorType) * 0.5; }
        }

        public ArmorType ChestArmorType
        {
            get { return armorSet.Chest.Type; }
            set
            {
                armorSet.Chest.Type = value;
                OnPropertyChanged(() => ChestArmorTotal);
            }
        }

        public int ChestArmorQuality
        {
            get { return armorSet.Chest.Quality; }
            set
            {
                armorSet.Chest.Quality = value;
                OnPropertyChanged(() => ChestArmorTotal);
            }
        }

        public double ArmsArmorTotal
        {
            get { return (ArmsArmorQuality + (int)ArmsArmorType) * 0.25; }
        }

        public ArmorType ArmsArmorType
        {
            get { return armorSet.Arms.Type; }
            set
            {
                armorSet.Arms.Type = value;
                OnPropertyChanged(() => ArmsArmorTotal);
            }
        }

        public int ArmsArmorQuality
        {
            get { return armorSet.Arms.Quality; }
            set
            {
                armorSet.Arms.Quality = value;
                OnPropertyChanged(() => ArmsArmorTotal);
            }
        }

        public double LegsArmorTotal
        {
            get { return (LegsArmorQuality + (int)LegsArmorType) * 0.25; }
        }

        public ArmorType LegsArmorType
        {
            get { return armorSet.Legs.Type; }
            set
            {
                armorSet.Legs.Type = value;
                OnPropertyChanged(() => LegsArmorTotal);
            }
        }

        public int LegsArmorQuality
        {
            get { return armorSet.Legs.Quality; }
            set
            {
                armorSet.Legs.Quality = value;
                OnPropertyChanged(() => LegsArmorTotal);
            }
        }

        public double HeadArmorTotal
        {
            get { return (HeadArmorQuality + (int)HeadArmorType)*0.25; }
        }

        public ArmorType HeadArmorType
        {
            get { return armorSet.Head.Type; }
            set
            {
                armorSet.Head.Type = value;
                OnPropertyChanged(() => HeadArmorTotal);
            }
        }

        public int HeadArmorQuality
        {
            get { return armorSet.Head.Quality; }
            set
            {
                armorSet.Head.Quality = value; 
                OnPropertyChanged(() => HeadArmorTotal);
            }
        }
    }
}
