namespace Terre_Natale_Calculateur
{
    internal interface IClassManager
    {
        void Initialize();
        void DumpJSON();
        void createbase();
        Classe getFormName(string search);
    }
}