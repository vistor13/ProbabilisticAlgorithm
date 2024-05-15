
namespace Coursova.Algorithm
{
    public static class ProbabilisticAlgorithm
    {
        private static List<List<Task>> DivideIntoTwoGroups(List<Task> tasks)
        {
            var res = new List<List<Task>>() { new List<Task>(), new List<Task>() };
            Random rnd = new Random();
            var shuffledList = tasks.OrderBy(x => rnd.Next()).ToList();

            res[rnd.Next(0, 1)].AddRange(shuffledList.GetRange(0, 2));

            for (int i = 2; i < tasks.Count; i += 2)
            {
                double probabiliti = ((double)i - res[0].Count) / i;

                res[rnd.NextDouble() < probabiliti ? 0 : 1].AddRange(shuffledList.GetRange(i, 2));
            }
 
            return res;
        }

        private static List<Tuple<Task, Task>> DivideIntoPairs(List<Task> tasks, int valueInSubGroup)
        {
            Random random = new Random();

            var sortedTasks = tasks.OrderBy(x => x.Duration).ToList();


            var res = new List<Tuple<Task, Task>>();

            var groups = new List<List<Task>>();

            while (sortedTasks.Count > 0)
            {
                int groupSize = Math.Min(sortedTasks.Count, valueInSubGroup);

                var currentGroup = sortedTasks.Take(groupSize).ToList();
                groups.Add(currentGroup);

                sortedTasks.RemoveRange(0, groupSize);
            }

            foreach (var group in groups)
            {
                do
                {
                    int Index1, Index2;
                    do
                    {
                        Index1 = random.Next(group.Count);
                        Index2 = random.Next(group.Count);
                    }
                    while (Index1 == Index2);

                    res.Add(group[Index1].Duration >= group[Index2].Duration ?
                        Tuple.Create(group[Index1], group[Index2]) : Tuple.Create(group[Index2], group[Index1]));

                    group.RemoveAt(Index1);

                    if (Index1 < Index2)
                        group.RemoveAt(Index2 - 1);
                    else
                        group.RemoveAt(Index2);

                }
                while (group.Count != 0);
            }
            return res;
        }
        private static List<Tuple<Task, Task>> CriterionMakeSchedule(List<Tuple<Task, Task>> taskTuples)
        {
            return taskTuples.OrderBy(t => (t.Item1.Duration + t.Item2.Duration) / (t.Item1.Weight + t.Item2.Weight)).ToList();
        }
        public static double TargetFunction(List<List<Tuple<Task, Task>>> schedule)
        {
            double res = 0;
            int count = 0;
            foreach (var m in schedule)
            {
                double totalTime = 0;
                foreach (var t in m)
                {
                    res += (t.Item1.Duration + totalTime) * t.Item1.Weight;
                    res += (t.Item2.Duration + totalTime) * t.Item2.Weight;
                    totalTime += t.Item1.Duration;
                    count += 2;
                }
            }
            return res / count;
        }

        private static List<List<Tuple<Task, Task>>> MakeSchedule(List<Task> tasks, int valueInSubGroup)
        {
            var res = new List<List<Tuple<Task, Task>>>();
            var splitedTask = DivideIntoTwoGroups(tasks);
            foreach (var m in splitedTask)
            {
                res.Add(CriterionMakeSchedule(DivideIntoPairs(m, valueInSubGroup)));
            }
            return res;
        }

        public static List<List<Tuple<Task, Task>>> FindBestSchedule(List<Task> tasks, int n = 100000,int valueInSubGroup=6)
        {
            List<List<Tuple<Task, Task>>> bestSchedule = new();
            double bestScheduleValue = double.MaxValue;

            for (int i = 0; i < n; i++)
            {
                var schedule = MakeSchedule(tasks, valueInSubGroup);
                var ScheduleValue = TargetFunction(schedule);

                if (ScheduleValue < bestScheduleValue)
                {
                    bestSchedule = schedule;
                    bestScheduleValue = ScheduleValue;
                }
            }

            return bestSchedule;
        }
    }

}
