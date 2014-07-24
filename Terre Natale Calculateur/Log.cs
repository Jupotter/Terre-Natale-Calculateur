namespace Terre_Natale_Calculateur
{
    static class Log
    {
        static Log()
        {
            Logger = new LogToFile();
        }

        public static LogToFile Logger { get; private set; }
    }
}
