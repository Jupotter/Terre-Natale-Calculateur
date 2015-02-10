using System;
using System.IO;

namespace Calculateur.Backend
{
    public class LogToFile
    {
        private readonly FileStream _logFileStream;

        public LogToFile()
        {
            _logFileStream = new FileStream("calculateur.log", FileMode.OpenOrCreate);
            var sw = new StreamWriter(_logFileStream);
            sw.WriteLine("====== Starting log: {0} ======", DateTime.Now);
            sw.Flush();
        }

        public void Write(String s)
        {
            var sw = new StreamWriter(_logFileStream);
            sw.WriteLine("[{0}] {1}", DateTime.Now, s);
            sw.Flush();
        }

        public void WriteException(Exception e)
        {
            var sw = new StreamWriter(_logFileStream);
            sw.Write("[{0}] {1}", DateTime.Now, e.Message);
            sw.Write(e.StackTrace);
            sw.Flush();
        }

        ~LogToFile()
        {
            _logFileStream.Close();
        }
    }
}
