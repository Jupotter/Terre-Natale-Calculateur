using Microsoft.Practices.Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calculateur_Backend;
using Terre_Natale_Calculateur;

namespace Calculateur_wpf.ViewModel
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
         
    }
}
