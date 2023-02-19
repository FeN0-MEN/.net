using System;
using System.IO;
using System.Configuration;
using System.Collections.Specialized;

namespace Zoo
{
    public class LoggerMethods
    {
        public static void LogInFile(string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(Config.LOG_PATH, true))
                {
                    writer.WriteLine(message);
                    writer.Close();
                }
            }
            catch
            {
                throw new FileNotFoundException();
            }
        }
        
        public static void LogInConsole(string message)
        {
            Console.WriteLine(message);
        }
    }
}
