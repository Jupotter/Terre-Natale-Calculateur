using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculateur.Backend
{
    public enum typeComposant { Effet, Bonus, Condition, Base }
    public enum TypeIp { Giver, Getter }
    public enum Ecole { Creation, Guérison, Convocation, Illusion, Enchantement, Abjuration, Destruction}
    public enum Element { Arcane, Eau, Feu, Terre, Vent, Loi, Chaos, Tous }
    public class SpellComposant
    {
        public int ID;
        public string Nom;
        public typeComposant typeCompo;
        public string descritption;
        public int ratioIp;
        public int ratioIp2;
        public Ecole ecole;
        public List<Element> elem;
        public int ipBonus;
        public TypeIp typeIp;
        public int PmMin;
        public int PmMax;
        public int inc;
        public int Place;

        public string GetName
        {
            get
            {
                return Nom;
            }
        }
        public TypeIp GetType
        {
            get
            {
                return typeIp;
            }
        }
        
        public SpellComposant(int IDCcomp,string nom,typeComposant typeC,string desc,int ratioip,int ratioip2,Ecole school, List<Element> elems, int ipbn,TypeIp tip,int PmMini,int PmMaxi,int Incantation,int plRequ)
        : this()
        {
            ID = IDCcomp;
            Nom = nom;
             typeCompo=typeC;
             descritption=desc;
             ratioIp=ratioip;
             ratioIp2 = ratioip2;
             ecole=school;
             elem=elems;
             ipBonus=ipbn;
             typeIp=tip;
             PmMin=PmMini;
             PmMax = PmMaxi;
             inc=Incantation;
             Place=plRequ;
        }
        public SpellComposant()
        {

        }
    }
}
