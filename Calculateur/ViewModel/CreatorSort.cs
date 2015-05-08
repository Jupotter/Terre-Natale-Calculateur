using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System.Threading.Tasks;
using Calculateur.Backend;
namespace Calculateur.ViewModel
{
    class CreatorSort: BindableBase
    {
        Dictionary<Ecole, int> NivEcole = new Dictionary<Ecole, int>();
        Dictionary<Element, int> NivElement = new Dictionary<Element, int>();
        List<SpellComposant> access = new List<SpellComposant>();
        List<SpellComposant> used = new List<SpellComposant>();
        string descriptionValue = "Selectionner un effet pour en avoir"+Environment.NewLine+ "une description détaillée.";
        Character chara;
        int placeBonus=0;
        int placebase=0;
        int placeConso = 0;
        int currentSelect=-1;
        public List<string> ListNom
        {
            get
            {
                return getList();
            }
        }

        Element elemactu = Element.Tous;

        public List<string> GetListEffet
        {
            get
            {
                List<string> result = new List<string>();
                foreach (SpellComposant item in used)
                {
                    result.Add(item.Nom
                        + " : ("
                        + item.PmMin
                        + "/" + item.PmMax
                        + ")"
                        + item.inc + " :"
                        + item.descritption.Replace(
                            "%ip%",access[currentSelect].ratioIp.ToString() + "%"
                            ).Replace(
                            "%ip2%", access[currentSelect].ratioIp2.ToString() + "%")
                        );
                }
                return result;
            }
        }

        public int Places
        {
            get
            {
               
                return placeBonus+placebase-placeConso;
            }

        }

        #region switchBool
        public DelegateCommand SwitchFire
        {
            get { return new DelegateCommand(switchFeu, () => true); }
        }
       public DelegateCommand SwitchEau
       {
           get { return new DelegateCommand(switchEau, () => true); }
       }
       public DelegateCommand SwitchArcane
       {
           get { return new DelegateCommand(switchArcane, () => true); }
       }
       public DelegateCommand SwitchLoi
       {
           get { return new DelegateCommand(switchLoi, () => true); }
       }
       public DelegateCommand SwitchChaos
       {
           get { return new DelegateCommand(switchChaos, () => true); }
       }
       public DelegateCommand SwitchTerre
       {
           get { return new DelegateCommand(switchTerre, () => true); }
       }
       public DelegateCommand SwitchVent
       {
           get { return new DelegateCommand(switchVent, () => true); }
       }


       
       public void switchLoi()
       {
           elemactu = Element.Loi;
           actuPlace();
       }
       public void switchArcane()
       {
           //arcaneA = !arcaneA;
          // if (arcaneA) eauA = terreA = chaosA = loiA = ventA = feuA = false;
           elemactu = Element.Arcane;
        actuPlace();
       }
       public void switchChaos()
       {

         //  chaosA = !chaosA;
         //  if (chaosA) eauA = terreA = arcaneA = loiA = ventA = feuA = false;
           elemactu = Element.Chaos;
        actuPlace();
       }
       public void switchFeu()
       {

         //  feuA = !feuA;
          // if (feuA) eauA = terreA = arcaneA = loiA = ventA = chaosA = false;
           elemactu = Element.Feu;

        actuPlace();
       }
       public void switchTerre()
       {
           elemactu = Element.Terre;
        actuPlace();
       }
       public void switchEau()
       {

         
           elemactu = Element.Eau;
        actuPlace();
       }
       public void switchVent()
       {

        
           elemactu = Element.Vent;
        actuPlace();
       }
       #endregion
      
        public string DescriptionEffet
       {
            get
           {
               return descriptionValue;
           }
       }
      
        public int BoxValue
       {
           get {
               return currentSelect;
           }
           set
           {
               SetProperty(ref currentSelect, value);
               changeDescription();
           }
       }
  
        public void actuPlace()
        {
         

            if(elemactu!=Element.Tous)
            {
               
                placebase = chara.GetTalent(elemactu.ToString()).Level;
              
            }
            else { placebase = 0; }
            OnPropertyChanged(null);
           
          
        }

        public CreatorSort()
        {
            if (NivEcole.Count == 0)
            {
                 chara = CharacterManager.Current;
                foreach (Ecole item in Enum.GetValues(typeof(Ecole)))
                {
                    NivEcole.Add(item, chara.GetTalent(item.ToString()).Level);
                }
                foreach (Element item in Enum.GetValues(typeof(Element)))
                {
                    if(item!=Element.Tous) NivElement.Add(item, chara.GetTalent(item.ToString()).Level);
                }
                foreach (SpellComposant compo in spellcomposantManager.Instance._spellCompo)
                {
                    if (NivEcole[compo.ecole] >= 1 && NivElement[compo.elem.First()] >= 1)
                    {
                        access.Add(compo);
                    }
                }
            }
            
        }

        public DelegateCommand AddEffectCommand
        {
            get { return new DelegateCommand(AddEffect); }
        }
        public DelegateCommand RepIpCall
        {
            get { return new DelegateCommand(LauchIprep); }
        }

        private void LauchIprep()
        {
            View.RepartirIP rip = new View.RepartirIP();
            rip.DataContext = new RepartirIP(used);
             rip.ShowDialog();
        }

        public void AddEffect()
        {
            used.Add(access[currentSelect]);
            actuall();
        }

        public void actuall()
        {
            placeConso = 0;
            foreach (SpellComposant item in used)
            {
                placeConso += item.Place;
            }




            OnPropertyChanged(null);
        }

        private void changeDescription()
        {
            if (currentSelect > -1)
            {
                descriptionValue = access[currentSelect].descritption.Replace("%ip%", access[currentSelect].ratioIp.ToString() + "%").Replace("%ip2%", access[currentSelect].ratioIp2.ToString() + "%");
                OnPropertyChanged(() => DescriptionEffet);
            }
        }

        public List<string> getList()
        {
            List<string> vals = new List<string>();

            foreach (SpellComposant item in access)
            {
                vals.Add(item.Nom);
            }
            
            return vals;
        }

        
    }
}
