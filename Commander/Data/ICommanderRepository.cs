﻿using Commander.Models;

namespace Commander.Data
{
    public interface ICommanderRepository
    {

        bool SaveChanges();
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);   
        void CreateCommand(Command cmd);

        void UpdateCommand(Command cmd);

    }
}
