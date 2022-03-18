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

        public void CreateCommand(Command cmd)
        {
           if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }
            else
            {
                _context.Commands.Add(cmd);
                SaveChanges();
            }
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(c => c.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCommand(Command cmd)
        {
            //
        }
    }
}
