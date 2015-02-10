namespace Calculateur.Backend
{
    public interface IClassManager
    {
        void Initialize();
        void DumpJSON();
        void createbase();
        Classe getFormName(string search);
    }
}