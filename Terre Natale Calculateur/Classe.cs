using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terre_Natale_Calculateur
{
    class Classe
    {

        String _nom;
        int _Id;
        int _RPE;
        int _RPF;
        int _RPC;
        int _RPM;
        List<string> statbonus;
        List<string> sauvBonus;
        String _Maitrise_de_base;
        String _TalentBonus;
        String _MaitriseSpecial;


        public Classe(string name, int id, int RPE, int RPF, int RPC, int RPM,List<string>statb,List<string>sauvb, String Maitrisedebase,
        String TalentBonus, String MaitriseSpecial)
        {
             _nom = name;
             _Id = id;
             _RPE=RPE;
             _RPF = RPF;
             _RPC=RPC;
             _RPM=RPM;
             statbonus = statb;
             sauvBonus = sauvb;
             _Maitrise_de_base = Maitrisedebase;
             _TalentBonus=TalentBonus;
             _MaitriseSpecial=MaitriseSpecial;
        }
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }


        public String Nom
        {
            get { return _nom; }
            set { _nom = value; }
        }

        #region get set
        public int RPE
        {
            get { return _RPE; }
            set { _RPE = value; }
        }
        public int RPF
        {
            get { return _RPF; }
            set { _RPF = value; }
        }
        public int RPC
        {
            get { return _RPC; }
            set { _RPC = value; }
        }
        public int RPM
        {
            get { return _RPM; }
            set { _RPM = value; }
        }

        public List<string> StatBonus
        {
            get { return statbonus; }
            set { statbonus = value; }
        }
        public List<string> SauvBonus
        {
            get { return sauvBonus; }
            set { sauvBonus = value; }

        }

#endregion

        public String Maitrise_de_base
        {
            get { return _Maitrise_de_base; }
            set { _Maitrise_de_base = value; }
        }
        public String TalentBonus
        {
            get { return _TalentBonus; }
            set { _TalentBonus = value; }
        }
        public String MaitriseSpecial
        {
            get { return _MaitriseSpecial; }
            set { _MaitriseSpecial = value; }
        }

       
    }
}
