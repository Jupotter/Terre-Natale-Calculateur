using Calculateur.Backend;
using Microsoft.Practices.Prism.Mvvm;
using System.Collections.Generic;

namespace Calculateur.ViewModel
{
    class Bijoux : BindableBase
    {


        int qtea1;
        int qtea2;
        int qteam;
        string actualA1;
        string actualA2;
        string actualAm;


        #region Gestion

        public int Qtea1
        {
           get
            {
                return qtea1;
            }
            set
            {
                qtea1=value;
                OnPropertyChanged(() => BonusAnneau1);
                bijUpdated();
            }
        }
       public int Qtea2
        {
            get
            {
                return qtea2;
            }
            set
            {
                qtea2 = value;
                OnPropertyChanged(() => BonusAnneau2);
                bijUpdated();
            }
        }
       public int Qteam
        {
            get
            {
                return qteam;
            }
            set
            {
                qteam=value;
                OnPropertyChanged(() => BonusAmulette);
                bijUpdated();
            }
        }


        public string ActualA1
       {
           get
           {
               return actualA1;
           }
           set
           {
               actualA1 = value;
               OnPropertyChanged(() => BonusAnneau1);
               bijUpdated();
           }
       }

        public string ActualA2
        {
            get
            {
                return actualA2;
            }
            set
            {
                actualA2 = value;
                OnPropertyChanged(() => BonusAnneau2);
                bijUpdated();
            }
        }

        public string ActualAm
        {
            get
            {
                return actualAm;
               
            }
            set
            {
                actualAm = value;
                OnPropertyChanged(() => BonusAmulette);
                bijUpdated();
            }
        }
        #endregion

       public List<string> materials
        {
            get
            {
                List<string> result = new List<string>();
                List<MatiereBijoux>lm= Bijouxmanager.Instance.getMat();
                foreach (MatiereBijoux item in lm)
                {
                    result.Add(item.name);
                }
                return result;
                
            }
        }

        public List<string> BonusAnneau1
        {
            get
            {
                List<string> result = new List<string>();
                MatiereBijoux actu = Bijouxmanager.Instance.getFromName(actualA1);

                if (actu == null) return result;
                switch (qtea1)
                {

                    case 1: result.Add("+1" + actu.primaire.ToString() + " si < 4");
                        result.Add("+2 resistance " + actu.element);
                        break;
                    case 2: result.Add("+1" + actu.primaire.ToString() + " si < 6");
                        result.Add("+1" + actu.secondaire.ToString() + " si < 2");
                        result.Add("+4 resistance " + actu.element);
                        break;
                    case 3: result.Add("+1" + actu.primaire.ToString() );
                        result.Add("+1" + actu.secondaire.ToString() + " si < 4");
                        result.Add("+6 resistance " + actu.element);
                        break;
                    case 4: result.Add("+1" + actu.primaire.ToString());
                        result.Add("+1" + actu.secondaire.ToString() + " si < 6");
                        result.Add("+8 resistance " + actu.element);
                        break;
                    case 5: result.Add("+1" + actu.primaire.ToString());
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
                MatiereBijoux actu = Bijouxmanager.Instance.getFromName(actualA2);

                if (actu == null) return result;
                switch (qtea2)
                {

                    case 1: result.Add("+1" + actu.primaire.ToString() + " si < 4");
                        result.Add("+2 resistance " + actu.element);
                        break;
                    case 2: result.Add("+1" + actu.primaire.ToString() + " si < 6");
                        result.Add("+1" + actu.secondaire.ToString() + " si < 2");
                        result.Add("+4 resistance " + actu.element);
                        break;
                    case 3: result.Add("+1" + actu.primaire.ToString());
                        result.Add("+1" + actu.secondaire.ToString() + " si < 4");
                        result.Add("+6 resistance " + actu.element);
                        break;
                    case 4: result.Add("+1" + actu.primaire.ToString());
                        result.Add("+1" + actu.secondaire.ToString() + " si < 6");
                        result.Add("+8 resistance " + actu.element);
                        break;
                    case 5: result.Add("+1" + actu.primaire.ToString());
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
            OnPropertyChanged(null);
        }
        
        public List<string>BonusAmulette
        {
            get
            {
                MatiereBijoux actu = Bijouxmanager.Instance.getFromName(actualAm);
                List<string> result = new List<string>();
                if (actu == null) return result;
                if ((actu.stat1 == "PE" || actu.stat1 == "PM") && (actu.stat2 == "" || actu.stat2 == null))
                {
                    result.Add(actu.stat1 + " : " + qteam * 3);
                }
                else if (actu.stat2 == "" || actu.stat2 == null)
                {
                    result.Add(actu.stat1 + " : " + (int)(qteam * 1.5));
                }
                else if ((actu.stat1 == "PE" || actu.stat1 == "PM"))
                {
                    result.Add(actu.stat1 + " : " + qteam * 2);
                }
                else
                {
                    result.Add(actu.stat1 + " : " + qteam);
                }


                if ((actu.stat2 == "PE" || actu.stat2 == "PM"))
                {
                    result.Add(actu.stat2 + " : " + qteam * 2);
                }
                else
                {
                    result.Add(actu.stat2 + " : " + qteam);
                }
                    

                return result;
            }
        }
        public void bijUpdated()
        {
            Bijouxmanager bm = Bijouxmanager.Instance;
            CharacterManager.Current.jewelchange(bm.getFromName(actualA1), qtea1, bm.getFromName(actualA2), qtea2, bm.getFromName(actualAm), qteam);
        }        
    }

 
   
}
