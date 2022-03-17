using Commander.Models;

namespace Commander.Data
{
    public class MockCommanderRepo : ICommanderRepository
    {
        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>()
            {
               new Command { Id = 0, HowTo = "BoilAndEgg", Line = "Boil water", Platform = "sdfed" },
               new Command { Id = 1, HowTo = "BoilAndEgg", Line = "Boil water", Platform = "sdfed" },
               new Command { Id = 2, HowTo = "BoilAndEgg", Line = "Boil water", Platform = "sdfed" }
            };

            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command { Id = 0, HowTo = "BoilAndEgg", Line = "Boil water", Platform = "sdfed" };
        }
    }
}
