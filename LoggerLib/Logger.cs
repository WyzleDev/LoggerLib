using System;
using System.Text;

namespace LoggerLib
{
    public class logger
    {
        //Переменные для расположения файла логов
        //Создает файл в рабочей дериктории
        protected static string fileName = "logs.log";
        protected static string pathString = Directory.GetCurrentDirectory();
        //Если нужно поменят директорию логов, то в logger.pathTologs можно поменять путь на свой
        public static string pathToLogs = Path.Combine(pathString, fileName);



        //Функции логгирования 
        //При необходимости добавьте свою
        public static void Debug(string data)
        {
            string logLevel = "DEBUG";
            writeData(createOutputString(data, logLevel));
            Console.WriteLine(pathToLogs);
        }
        public static void Info(string data)
        {
            string logLevel = "INFO";
            writeData(createOutputString(data, logLevel));
        }
        public static void Warn(string data)
        {
            string logLevel = "WARN";
            writeData(createOutputString(data, logLevel));
        }
        public static void Error(string data)
        {
            string logLevel = "ERROR";
            
            writeData(createOutputString(data, logLevel));
        }

        //функция записывает логи в файл
        //Если файла нет, то создает его
        static void writeData(string Data)
        {
            //Если файла не существует, то создаем его
            if (!File.Exists(pathToLogs))
            {
                // и записываем в него логи
                using (FileStream fs = File.Create(pathToLogs))
                {
                    byte[] info = new UTF8Encoding(true).GetBytes(Data);
                    fs.Write(info, 0, info.Length);
                }
            }
            //Если файл уже есть, то просто записываем логи
            else
            {
                File.AppendAllText(pathToLogs, Data);
            }
            
        }

        //функция, которая создает отформатированую строку для записи в файл
        protected static string createOutputString(string data, string logLevel)
        {
            string output = $"[{logLevel}] {data} [{DateTime.Now}]\n";
            return output;
        }
        

    }
}