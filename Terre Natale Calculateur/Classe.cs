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
        string _MPE;
        string _MPF;
        string _MPC;
        string _MPM;
        Aspect _Primaire;
        Aspect _Secondaire;
        String _Maitrise_de_base;
        String _TalentBonus;
        String _MaitriseSpecial;


        public Classe(string name, int id, int RPE, int RPF, int RPC, int RPM, string MPE, string MPF,
        string MPC, string MPM, Aspect Primaire, Aspect Secondaire, String Maitrisedebase,
        String TalentBonus, String MaitriseSpecial)
        {
             _nom = name;
             _Id = id;
             _RPE=RPE;
             _RPF = RPF;
             _RPC=RPC;
             _RPM=RPM;
             _MPE=MPE;
             _MPF=MPF;
             _MPC=MPC;
             _MPM=MPM;
             _Primaire=Primaire;
             _Secondaire=Secondaire;
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
        public string MPE
        {
            get { return _MPE; }
            set { _MPE = value; }
        }
        public string MPF
        {
            get { return _MPF; }
            set { _MPF = value; }
        }
        public string MPC
        {
            get { return _MPC; }
            set { _MPC = value; }
        }
        public string MPM
        {
            get { return _MPM; }
            set { _MPM = value; }
        }
        public Aspect Primaire
        {
            get { return _Primaire; }
            set { _Primaire = value; }
        }
        public Aspect Secondaire
        {
            get { return _Secondaire; }
            set { _Secondaire = value; }
        }
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
