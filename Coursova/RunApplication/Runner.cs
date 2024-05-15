

namespace Coursova.RunApplication
{
    public class Runner 
    { 
        private CommandInvoker _commandInvoker;
        public Runner(CommandInvoker commandInvoker)
        {
            _commandInvoker = commandInvoker;
        }
        public void Run()
        {
            while (true)
            {
               
                Console.WriteLine("\tВведіть значення в межаж 1-6");
                Console.WriteLine("\tВихід - 0.");
                Console.WriteLine("\tЗгенерувати дані випадковим чином -1 ");
                Console.WriteLine("\tВвести дані задачі вручну - 2 ");
                Console.WriteLine("\tЗчитати з файлу -3");
                Console.WriteLine("\tЕксперемент відносно кількості підгруп - 4  ");
                Console.WriteLine("\tЕксперимент з визначення часової складності алгоритмів - 5  ");
                Console.Write("\tЕксперимент з порівняння алгоритмів за точністю - 6  : ");

                if (Enum.TryParse(Console.ReadLine(), out Command command) && _commandInvoker.RunCommand().ContainsKey(command))
                {
                    _commandInvoker.RunCommand()[command]();
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("НЕ вірно ведене число , введіть число від 1-3");
                }
            }

        }

    }
    
}
