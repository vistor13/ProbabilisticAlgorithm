
namespace Coursova.RunApplication
{
    public static class Cheking
    {
        public static int ChekingValue(string value)
        {
            int type;
            while (!Int32.TryParse(value, out type))
            {
                Console.Write("\tВведенно не коректно, ведіть ще раз : ");
                value = Console.ReadLine();
            }
            return type;
        }
        
    }
}
