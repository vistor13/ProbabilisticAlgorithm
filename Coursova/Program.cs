

using Coursova.Algorithm;
using Coursova.RunApplication;
using System.Security.Cryptography;
using System.Text;
using Task = Coursova.Algorithm.Task;

namespace Coursova
{
    class Program
    {
        static void Main(string[] args)
        {

            Runner rn = new Runner(new CommandInvoker(new DataOutPut()));
            rn.Run();
        }
      
       
    }
}