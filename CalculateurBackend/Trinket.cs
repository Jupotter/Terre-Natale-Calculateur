using System;

namespace Calculateur.Backend
{
    public class Trinket
    {
        private MatiereBijoux material = new MatiereBijoux();
        private int quality = 0;

        public int Quality
        {
            get { return quality; }
            set
            {
                quality = Math.Max(0,
                          Math.Min(5, value));
                OnQualityChanged();
            }
        }

        public MatiereBijoux Material
        {
            get { return material; }
            set
            {
                material = value; 
                OnMaterialChanged();
            }
        }

        public event Action MaterialChanged;

        protected virtual void OnMaterialChanged()
        {
            Action handler = MaterialChanged;
            if (handler != null) handler();
        }

        public event Action QualityChanged;

        protected virtual void OnQualityChanged()
        {
            Action handler = QualityChanged;
            if (handler != null) handler();
        }
    }
}
