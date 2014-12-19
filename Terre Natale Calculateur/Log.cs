namespace Terre_Natale_Calculateur
{
    public static class Log
    {
        static Log()
        {
            Logger = new LogToFile();
        }

        public static LogToFile Logger { get; private set; }
    }
}
