using Commander.Models;

namespace Commander.Data
{
    public class SqlCommanderRepo :ICommanderRepository
    {
        private readonly CommanderContext _context;
        public SqlCommanderRepo(CommanderContext commanderContext)
        {
            _context = commanderContext;
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(c => c.Id == id);
        }
    }
}
