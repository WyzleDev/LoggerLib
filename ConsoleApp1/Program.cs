using System;
using LoggerLib;

class Program
{
    private static void Main()
    {
        //Типо тесты
        logger.Debug("Debug Message");
        logger.Warn("Warn message");
        logger.Info("Info message");
        logger.Error("Error message");

        //ТИПО функция для тестов
        int calcs()
        {
            int a = 10;
            int b = 20;
            logger.Info("выполняю сложение");
            return a * b;
            
        }
        logger.Info($"{calcs()}");

        
        
    }
}