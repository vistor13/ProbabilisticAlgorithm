using Coursova.RunApplication;

namespace Coursova.Algorithm
{
    public static class TaskGenerator
    {
        public static List<Task> GenerateRandom(int n, double durationMin , double durationMax , double weightMin , double weightMax)
        {
            var random = new Random(1231);
            var result = new List<Task>();

            for (int i = 0; i < n; i++)
            {
                var duration = random.NextDouble() * (durationMax - durationMin) + durationMin;
                var weight = random.NextDouble() * (weightMax - weightMin) + weightMin;
                duration = Math.Round(duration, 0);
                weight = Math.Round(weight, 0);
                result.Add(new Task(duration, weight));
            }
            return result;
        }
        public static List<Task> GeneratDataManually(int[] durationVector, int[] weightVector)
        {
            var result = new List<Task>();

            for (int i = 0; i < durationVector.Length; i++)
            {
                var duration = durationVector[i];
                var weight = weightVector[i];
                result.Add(new Task(duration, weight));
            }
            return result;
        }
     

    }
}
