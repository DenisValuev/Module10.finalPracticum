using Module10.Models;
using System.Data;

namespace Module10
{
    internal class Program
    {
        static ILogger Logger { get; set; }
        static void Main(string[] args)
        {
            while (true) 
            {
                try
                {
                    Logger = new Logger();
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Введите выражение : ");
                    string str = Console.ReadLine();
                    if (str.All(Char.IsLetter) || str.Contains('='))
                    {
                        throw new MyException("Неверный формат выражения");
                    }

                    Calc calc = new Calc(Logger);
                    double result = ((ICalculate)calc).Calculate(str);
                    Console.WriteLine($"{str} = {result}");
                }
                catch (MyException e)
                {
                    Logger.Error(e.Message);
                }
                catch (Exception e)
                {
                    Logger.Error(e.Message);
                }
            }
        }
    }
   
}
