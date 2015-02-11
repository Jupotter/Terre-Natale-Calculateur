using Calculateur.Backend;
using Microsoft.Practices.Prism.Mvvm;
using System.Collections.Generic;

namespace Calculateur.ViewModel
{
    class Bijoux : BindableBase
    {
        private Inventory inventory = new Inventory();

        #region Gestion

        public int Qtea1
        {
           get
            {
                return inventory.Ring1.Quality;
            }
            set
            {
                inventory.Ring1.Quality = value;
                OnPropertyChanged(() => BonusAnneau1);
            }
        }
       public int Qtea2
        {
            get
            {
                return inventory.Ring2.Quality;
            }
            set
            {
                inventory.Ring1.Quality = value;
                OnPropertyChanged(() => BonusAnneau2);
            }
        }
       public int Qteam
        {
            get
            {
                return inventory.Pendant.Quality;
            }
            set
            {
                inventory.Pendant.Quality = value;
                OnPropertyChanged(() => BonusAmulette);
            }
        }


        public MatiereBijoux ActualA1
        {
            get { return inventory.Ring1.Material; }
            set
            {
                inventory.Ring1.Material = value;
                OnPropertyChanged(() => BonusAnneau1);
            }
        }

        public MatiereBijoux ActualA2
        {
            get { return inventory.Ring2.Material; }
            set
            {
                inventory.Ring2.Material = value;
                OnPropertyChanged(() => BonusAnneau2);
            }
        }

        public MatiereBijoux ActualAm
        {
            get
            {
                return inventory.Pendant.Material;
               
            }
            set
            {
                inventory.Pendant.Material = value;
                OnPropertyChanged(() => BonusAmulette);
            }
        }
        #endregion

        public IEnumerable<MatiereBijoux> Materials
        {
            get
            {
                List<MatiereBijoux>lm= Bijouxmanager.Instance.getMat();
                return lm;
                
            }
        }

        public List<string> BonusAnneau1
        {
            get
            {
                var result = new List<string>();
                MatiereBijoux actu = inventory.Ring1.Material;

                if (actu == null) return result;
                switch (inventory.Ring1.Quality)
                {

                    case 1: result.Add("+1" + actu.Primaire.ToString() + " si < 4");
                        result.Add("+2 resistance " + actu.element);
                        break;
                    case 2: result.Add("+1" + actu.Primaire.ToString() + " si < 6");
                        result.Add("+1" + actu.secondaire.ToString() + " si < 2");
                        result.Add("+4 resistance " + actu.element);
                        break;
                    case 3: result.Add("+1" + actu.Primaire.ToString() );
                        result.Add("+1" + actu.secondaire.ToString() + " si < 4");
                        result.Add("+6 resistance " + actu.element);
                        break;
                    case 4: result.Add("+1" + actu.Primaire.ToString());
                        result.Add("+1" + actu.secondaire.ToString() + " si < 6");
                        result.Add("+8 resistance " + actu.element);
                        break;
                    case 5: result.Add("+1" + actu.Primaire.ToString());
                        result.Add("+1" + actu.secondaire.ToString() );
                        result.Add("+10 resistance " + actu.element); ;
                        break;

                    default: 
                        break;
                }
                

                return result;
            }
        }
        public List<string> BonusAnneau2
        {
            get
            {
                List<string> result = new List<string>();
                MatiereBijoux actu = inventory.Ring2.Material;

                if (actu == null) return result;
                switch (inventory.Ring2.Quality)
                {

                    case 1: result.Add("+1" + actu.Primaire.ToString() + " si < 4");
                        result.Add("+2 resistance " + actu.element);
                        break;
                    case 2: result.Add("+1" + actu.Primaire.ToString() + " si < 6");
                        result.Add("+1" + actu.secondaire.ToString() + " si < 2");
                        result.Add("+4 resistance " + actu.element);
                        break;
                    case 3: result.Add("+1" + actu.Primaire.ToString());
                        result.Add("+1" + actu.secondaire.ToString() + " si < 4");
                        result.Add("+6 resistance " + actu.element);
                        break;
                    case 4: result.Add("+1" + actu.Primaire.ToString());
                        result.Add("+1" + actu.secondaire.ToString() + " si < 6");
                        result.Add("+8 resistance " + actu.element);
                        break;
                    case 5: result.Add("+1" + actu.Primaire.ToString());
                        result.Add("+1" + actu.secondaire.ToString());
                        result.Add("+10 resistance " + actu.element); ;
                        break;

                    default:
                        break;
                }


                return result;
            }
        }
        public Bijoux()
        {
            CharacterManager.CharacterChanged += OnCharacterChanged;
        }

        private void OnCharacterChanged(Character caller)
        {
            inventory = caller.Inventory;
            inventory.TrinketChanged += () => OnPropertyChanged(null);
            OnPropertyChanged(null);
        }
        
        public List<string>BonusAmulette
        {
            get
            {
                MatiereBijoux actu = inventory.Pendant.Material;
                List<string> result = new List<string>();
                int qteam = inventory.Pendant.Quality;
                if (qteam == 0)
                    return null;

                if (actu == null) return result;
                if ((actu.stat1 == "PE" || actu.stat1 == "PM") && string.IsNullOrEmpty(actu.stat2))
                {
                    result.Add(string.Format("{0} : {1}", actu.stat1, qteam*3));
                }
                else if (string.IsNullOrEmpty(actu.stat2))
                {
                    result.Add(string.Format("{0} : {1}", actu.stat1, (int) (qteam*1.5)));
                }
                else if ((actu.stat1 == "PE" || actu.stat1 == "PM"))
                {
                    result.Add(string.Format("{0} : {1}", actu.stat1, qteam*2));
                }
                else
                {
                    result.Add(string.Format("{0} : {1}", actu.stat1, qteam));
                }


                if ((actu.stat2 == "PE" || actu.stat2 == "PM"))
                {
                    result.Add(string.Format("{0} : {1}", actu.stat2, qteam*2));
                }
                else
                {
                    result.Add(string.Format("{0} : {1}", actu.stat2, qteam));
                }


                return result;
            }
        }  
    }

 
   
}
