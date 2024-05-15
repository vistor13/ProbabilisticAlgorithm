using Coursova.RunApplication;


namespace Coursova.RunApplication
{
    public class CommandInvoker
    {
        private IDataOutPut _dataOutput;
        public CommandInvoker(IDataOutPut dataOutput)
        {
            _dataOutput = dataOutput;
        }
        public Dictionary<Command, Action> RunCommand()
        {
            var dictionarycommand = new Dictionary<Command, Action>()
            {
                {Command.GenerataValueRandom, _dataOutput.GenerataValueRandom },
                {Command.Exit, _dataOutput.Exit },
                {Command.GenerataValueManually, _dataOutput.GenerataValueManually },
                {Command.GenerateFromFile, _dataOutput.GenerateFromFile },
                {Command.ExperimentComparingAlgorithmsAccuracy, _dataOutput.ExperimentComparingAlgorithmsAccuracy },
                {Command.ExperimentProbabilityAlgorithm, _dataOutput.ExperimentProbabilityAlgorithm },
                {Command.TimeComplexityExperiment, _dataOutput.TimeComplexityExperiment }


            };
            return dictionarycommand;
        }
    }
}
