namespace Calculateur.Backend
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
