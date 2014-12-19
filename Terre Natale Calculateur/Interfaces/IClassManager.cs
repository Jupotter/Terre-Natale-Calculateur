namespace Terre_Natale_Calculateur
{
    public interface IClassManager
    {
        void Initialize();
        void DumpJSON();
        void createbase();
        Classe getFormName(string search);
    }
}