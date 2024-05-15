
using Coursova.Algorithm;
using System.Diagnostics;
using Task = Coursova.Algorithm.Task;
namespace Coursova.RunApplication
{
    public class DataOutPut : IDataOutPut
    {
        public void GenerataValueRandom()
        {
            string fileName = "resultProbabilisticAlgorithm.txt";
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                Console.Write("\tВведіть кількість робіт : ");
                var valueTask = Console.ReadLine();
                var n = Cheking.ChekingValue(valueTask);

                Console.Write("\tВведіть мінімальне значення тривалості : ");
                var valueDurMin = Console.ReadLine();
                var tMin = Cheking.ChekingValue(valueDurMin);

                Console.Write("\tВведіть максимальне значення тривалості : ");
                var valueDurMax = Console.ReadLine();
                var tMax = Cheking.ChekingValue(valueDurMax);

                Console.Write("\tВведіть мінімальне значення ваги : ");
                var valueUMin = Console.ReadLine();
                var uMin = Cheking.ChekingValue(valueUMin);

                Console.Write("\tВведіть максимальне значення ваги : ");
                var valueUMax = Console.ReadLine();
                var uMax = Cheking.ChekingValue(valueUMax);
                Console.WriteLine();

                var tasks = TaskGenerator.GenerateRandom(n, tMin, tMax, uMin, uMax);

                foreach (var task in tasks)
                {
                    writer.Write($"(t:{task.Duration}, u:{task.Weight})");
                    Console.Write($"(t:{task.Duration}, u:{task.Weight}); ");
                }
                var res = ProbabilisticAlgorithm.FindBestSchedule(tasks, 1000000);

                ShowSchedule(res, writer);

                Console.WriteLine($"Цільова функція: {ProbabilisticAlgorithm.TargetFunction(res)}");
                writer.WriteLine($"Цільова функція: {ProbabilisticAlgorithm.TargetFunction(res)}");
            }

        }

        public void GenerataValueManually()
        {
            string fileName = "resultProbabilisticAlgorithm.txt";
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                Console.Write("\tВведіть кількість робіт : ");
                var valueTask = Console.ReadLine();
                var n = Cheking.ChekingValue(valueTask);

                var durationVector = new int[n];
                var weightVector = new int[n];

                for (int i = 0; i < n; i++)
                {
                    Console.Write($"\tВведіть тривалість {i + 1}-ої роботи: ");
                    durationVector[i] = Cheking.ChekingValue(Console.ReadLine());

                    Console.Write($"\tВведіть вагу {i + 1}-ої роботи: ");
                    weightVector[i] = Cheking.ChekingValue(Console.ReadLine());
                }

                var tasks = TaskGenerator.GeneratDataManually(durationVector, weightVector);
                foreach (var task in tasks)
                {
                    writer.Write($"(t:{task.Duration}, u:{task.Weight})");
                    Console.Write($"(t:{task.Duration}, u:{task.Weight}); ");
                }
                var res = ProbabilisticAlgorithm.FindBestSchedule(tasks, 100000);
                ShowSchedule(res, writer);
                Console.WriteLine($"Цільова функція: {ProbabilisticAlgorithm.TargetFunction(res)}");
                writer.WriteLine($"Цільова функція: {ProbabilisticAlgorithm.TargetFunction(res)}");
            }

        }
        public void GenerateFromFile()
        {
            string fileOutName = "resultProbabilisticAlgorithm.txt";
            using (StreamWriter writer = new StreamWriter(fileOutName))
            {
                Console.Write("\tВведіть ім'я файлу: ");
                var fileName = Console.ReadLine();
                Console.WriteLine();
                try
                {
                    string[] lines = File.ReadAllLines(fileName);

                    if (lines.Length < 3)
                    {
                        Console.WriteLine("Некоректна структура файлу.");
                        return;
                    }

                    var n = Cheking.ChekingValue(lines[0]);

                    var durationValues = Array.ConvertAll(lines[1].Split(' '), int.Parse);
                    var weightValues = Array.ConvertAll(lines[2].Split(' '), int.Parse);

                    if (durationValues.Length != n || weightValues.Length != n)
                    {
                        Console.WriteLine("Кількість значень тривалості та ваги не відповідає зазначеній кількості робіт.");
                        return;
                    }

                    var tasks = TaskGenerator.GeneratDataManually(durationValues, weightValues);


                    foreach (var task in tasks)
                    {
                        writer.Write($"(t:{task.Duration}, u:{task.Weight})");
                        Console.Write($"(t:{task.Duration}, u:{task.Weight}); ");
                    }
                    var res = ProbabilisticAlgorithm.FindBestSchedule(tasks, 100000);
                    ShowSchedule(res, writer);

                    Console.WriteLine($"Цільова функція: {ProbabilisticAlgorithm.TargetFunction(res)}");
                    writer.WriteLine($"Цільова функція: {ProbabilisticAlgorithm.TargetFunction(res)}");

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка при зчитуванні файлу: {ex.Message}");
                }
            }
        }
        public void ExperimentProbabilityAlgorithm()
        {
            var fileOutName = "Subgroup_Work_Effect_Study.txt";
            using (StreamWriter writer = new StreamWriter(fileOutName))
            {
                Console.Write("\tВведіть кількість робіт : ");
                var valueTask = Console.ReadLine();
                var n = Cheking.ChekingValue(valueTask);

                Console.Write("\tВведіть мінімальне значення тривалості : ");
                var valueDurMin = Console.ReadLine();
                var tMin = Cheking.ChekingValue(valueDurMin);

                Console.Write("\tВведіть максимальне значення тривалості : ");
                var valueDurMax = Console.ReadLine();
                var tMax = Cheking.ChekingValue(valueDurMax);

                Console.Write("\tВведіть мінімальне значення ваги : ");
                var valueUMin = Console.ReadLine();
                var uMin = Cheking.ChekingValue(valueUMin);

                Console.Write("\tВведіть максимальне значення ваги : ");
                var valueUMax = Console.ReadLine();
                var uMax = Cheking.ChekingValue(valueUMax);
                Console.WriteLine();

                var tasks = TaskGenerator.GenerateRandom(n, tMin, tMax, uMin, uMax);

                foreach (var x in tasks)
                {
                    writer.Write($"(t:{x.Duration}, u:{x.Weight})");
                    Console.Write($"(t:{x.Duration}, u:{x.Weight}); ");
                }
                Console.WriteLine();
                Console.WriteLine();

                writer.WriteLine();
                writer.WriteLine();

                double averageValue = 0;
                int value = 0;
                List<double> AvarageValue = new List<double>();
                for (int j = 0; j < 3; j++)
                {
                    for (int i = 0; i < 20; i++)
                    {
                        var res = ProbabilisticAlgorithm.FindBestSchedule(tasks, 100000, (n % 4 + 1) * 6 + value);
                        ShowSchedule(res, writer);
                        var objectiveFunction = ProbabilisticAlgorithm.TargetFunction(res);
                        Console.WriteLine(objectiveFunction);
                        writer.WriteLine(objectiveFunction);
                        averageValue += objectiveFunction;
                    }
                    Console.WriteLine();
                    AvarageValue.Add(averageValue / 20);
                    averageValue = 0;
                    value += 8;
                }
                for (int i = 0; i < AvarageValue.Count; i++)
                {
                    writer.WriteLine($"Середнє значення ЦФ експеременту {i + 1} : {AvarageValue[i]}");
                    Console.WriteLine($"Середнє значення ЦФ експеременту {i + 1} : {AvarageValue[i]}");
                }
                for (int i = 1; i < AvarageValue.Count; i++)
                {
                    double percentageDifference = ((AvarageValue[0] - AvarageValue[i]) / AvarageValue[0]) * 100;
                    writer.WriteLine($"Відсоткове зменшення ЦФ екс. {i + 1} відносно експерименту 1: {percentageDifference:F2}%");
                    Console.WriteLine($"Відсоткове зменшення ЦФ екс. {i + 1} 3 відносно експерименту 1: {percentageDifference:F2}%");
                }
            }

        }

        public void ExperimentComparingAlgorithmsAccuracy()
        {
            var fileOutName = "Algorithm_Comparison_Precision_Study.txt";
            var dataFileOutName = "Algorithm_Comparison_Data.txt";

            using (StreamWriter writer = new StreamWriter(fileOutName))
            using (StreamWriter dataWriter = new StreamWriter(dataFileOutName))
            {
                Console.Write("\tВведіть мінімальне значення тривалості : ");
                var valueDurMin = Console.ReadLine();
                var tMin = Cheking.ChekingValue(valueDurMin);

                Console.Write("\tВведіть максимальне значення тривалості : ");
                var valueDurMax = Console.ReadLine();
                var tMax = Cheking.ChekingValue(valueDurMax);

                Console.Write("\tВведіть мінімальне значення ваги : ");
                var valueUMin = Console.ReadLine();
                var uMin = Cheking.ChekingValue(valueUMin);

                Console.Write("\tВведіть максимальне значення ваги : ");
                var valueUMax = Console.ReadLine();
                var uMax = Cheking.ChekingValue(valueUMax);

                Console.WriteLine();
                List<int> numberOfWorks = new List<int>() { 20, 40, 60, 80, 100 };
                List<double> valueObjectiveFunction = new List<double>();
                List<double> valueGreedyFunction = new List<double>();

                double averageValue = 0;

                foreach (int numberOfWork in numberOfWorks)
                {
                    var tasks = TaskGenerator.GenerateRandom(numberOfWork, tMin, tMax, uMin, uMax);

                   
                    dataWriter.WriteLine(numberOfWork);

           
                    List<double> durations = new List<double>();
                    List<double> weights = new List<double>();

                    foreach (var task in tasks)
                    {
                        writer.Write($"(t:{task.Duration}, u:{task.Weight})");
                        Console.Write($"(t:{task.Duration}, u:{task.Weight}); ");
                        durations.Add(task.Duration);
                        weights.Add(task.Weight);
                    }
                    Console.WriteLine();
                    Console.WriteLine();

                    writer.WriteLine();
                    writer.WriteLine();

                
                    dataWriter.WriteLine(string.Join(", ", durations));
                    dataWriter.WriteLine(string.Join(", ", weights));

                    var resGredy = GreedyAlgorithm.Calculate(tasks);
                    ShowSchedule(resGredy, writer);
                    var targetFunctionGreedy = ProbabilisticAlgorithm.TargetFunction(resGredy);
                    Console.WriteLine($"ЦФ жадібного алгоритму: {targetFunctionGreedy}");
                    writer.WriteLine($"ЦФ жадібного алгоритму: {targetFunctionGreedy}");
                    valueGreedyFunction.Add(targetFunctionGreedy);

                    for (int i = 0; i < 20; i++)
                    {
                        writer.WriteLine();
                        Console.WriteLine();

                        var resProbality = ProbabilisticAlgorithm.FindBestSchedule(tasks, 100000);
                        ShowSchedule(resProbality, writer);
                        var targetFunctionProbability = ProbabilisticAlgorithm.TargetFunction(resProbality);
                        Console.WriteLine($"ЦФ ймовірносного алгоритму: {targetFunctionProbability}");
                        writer.WriteLine($"ЦФ ймовірносного алгоритму: {targetFunctionProbability}");
                        averageValue += targetFunctionProbability;
                    }
                    valueObjectiveFunction.Add(averageValue / 20);
                    averageValue = 0;
                }
                Console.WriteLine();
                for (int i = 0; i < numberOfWorks.Count; i++)
                {
                    Console.WriteLine($"Середнє значення ЦФ при n = {numberOfWorks[i]}: {valueObjectiveFunction[i]}");
                    writer.WriteLine($"Середнє значення ЦФ при n = {numberOfWorks[i]}: {valueObjectiveFunction[i]}");
                    Console.WriteLine($"Значення ЦФ жад. алгоритму при n = {numberOfWorks[i]}: {valueGreedyFunction[i]}");
                    writer.WriteLine($"Значення ЦФ жад. алгоритму при n = {numberOfWorks[i]}: {valueGreedyFunction[i]}");
                    Console.WriteLine();
                    writer.WriteLine();
                }
                for (int i = 0; i < numberOfWorks.Count; i++)
                {
                    double deviation = ((valueObjectiveFunction[i] - valueGreedyFunction[i]) / valueGreedyFunction[i]) * 100;
                    Console.WriteLine($"Середнє відхилення при n = {numberOfWorks[i]}: {deviation}%");
                    writer.WriteLine($"Середнє відхилення при n = {numberOfWorks[i]}: {deviation}%");
                    Console.WriteLine();
                    writer.WriteLine();
                }
            }
        }

        public void TimeComplexityExperiment()
        {
            var fileOutName = "Time_Complexity_Experiment.txt";
            var dataFileOutName = "Time_Complexity_Data.txt";

            using (StreamWriter writer = new StreamWriter(fileOutName))
            using (StreamWriter dataWriter = new StreamWriter(dataFileOutName))
            {
                Console.Write("\tВведіть мінімальне значення тривалості : ");
                var valueDurMin = Console.ReadLine();
                var tMin = Cheking.ChekingValue(valueDurMin);

                Console.Write("\tВведіть максимальне значення тривалості : ");
                var valueDurMax = Console.ReadLine();
                var tMax = Cheking.ChekingValue(valueDurMax);

                Console.Write("\tВведіть мінімальне значення ваги : ");
                var valueUMin = Console.ReadLine();
                var uMin = Cheking.ChekingValue(valueUMin);

                Console.Write("\tВведіть максимальне значення ваги : ");
                var valueUMax = Console.ReadLine();
                var uMax = Cheking.ChekingValue(valueUMax);
                Console.WriteLine();

                List<int> numberOfWorks = new List<int>() { 20, 40, 60, 80, 100 };
                List<double> executionTimes = new List<double>();
                double averageValue = 0;

                foreach (int numberOfWork in numberOfWorks)
                {
                    var tasks = TaskGenerator.GenerateRandom(numberOfWork, tMin, tMax, uMin, uMax);
                    dataWriter.WriteLine(numberOfWork);

                    List<double> durations = new List<double>();
                    List<double> weights = new List<double>();

                    foreach (var x in tasks)
                    {
                        writer.Write($"(t:{x.Duration}, u:{x.Weight})");
                        Console.Write($"(t:{x.Duration}, u:{x.Weight}); ");
                        durations.Add(x.Duration);
                        weights.Add(x.Weight);
                    }
                    Console.WriteLine();
                    Console.WriteLine();

                    writer.WriteLine();
                    writer.WriteLine();

                    dataWriter.WriteLine(string.Join(", ", durations));
                    dataWriter.WriteLine(string.Join(", ", weights));

                    for (int i = 0; i < 20; i++)
                    {
                        var stopwatch = Stopwatch.StartNew();

                        var res = ProbabilisticAlgorithm.FindBestSchedule(tasks, 10000);

                        stopwatch.Stop();
                        var executionTime = stopwatch.Elapsed.TotalSeconds;

                        averageValue += executionTime;
                        ShowSchedule(res, writer);
                        var objectiveFunction = ProbabilisticAlgorithm.TargetFunction(res);
                        Console.WriteLine($"ЦФ - {objectiveFunction}");
                        writer.WriteLine($"ЦФ - {objectiveFunction}");
                        Console.WriteLine($"Time - {executionTime} c.");
                        writer.WriteLine($"Time - {executionTime} c.");
                    }
                    executionTimes.Add(averageValue / 20);
                    averageValue = 0;
                    Console.WriteLine();
                    writer.WriteLine();
                }
                Console.WriteLine();
                writer.WriteLine();
                for (int i = 0; i < numberOfWorks.Count; i++)
                {
                    Console.WriteLine($"Середній час роботи для n = {numberOfWorks[i]}: {executionTimes[i]} с");
                    writer.WriteLine($"Середній час роботи для n = {numberOfWorks[i]}: {executionTimes[i]} с");
                    Console.WriteLine();
                    writer.WriteLine();
                }
            }
        }

        static void ShowSchedule(List<List<Tuple<Task, Task>>> schedule, StreamWriter writer)
        {
            Console.WriteLine();
            writer.WriteLine();
            Console.WriteLine();
            writer.WriteLine();
            Console.WriteLine("Результуючий розклад : ");
            writer.WriteLine("Результуючий розклад : ");
            writer.WriteLine();
            Console.WriteLine();
            foreach (var m in schedule)
            {
                foreach (var t in m)
                {
                    Console.Write($"[({t.Item1.Duration} , {t.Item1.Weight}); ({t.Item2.Duration} , {t.Item2.Weight})]   ");
                    writer.Write($"[({t.Item1.Duration} , {t.Item1.Weight}); ({t.Item2.Duration} , {t.Item2.Weight})]   ");
                }
                Console.WriteLine();
                Console.WriteLine();
                writer.WriteLine();
                writer.WriteLine();
            }
        }
        public void Exit()
        {
            Environment.Exit(0);
        }
    }
       
    public interface IDataOutPut
    {
        void GenerataValueRandom();
        void Exit();
        void GenerataValueManually();
        void GenerateFromFile();
        void ExperimentComparingAlgorithmsAccuracy();
        void ExperimentProbabilityAlgorithm();
        void TimeComplexityExperiment();
    }
}
