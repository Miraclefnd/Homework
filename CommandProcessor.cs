using System.Collections;
using Practice.HomeWork.Abstractions;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using Practice.HomeWork.Abstractions.BLL;
using Practice.HomeWork.Models;

namespace Practice.HomeWork.Services.PL.Commands
{
    public class CommandProcessor : ICommandProcessor
    {
        private readonly Dictionary<int, ICommand> commands = new Dictionary<int, ICommand>();
        

        public CommandProcessor(IEnumerable<ICommand> command)
        {

            foreach (var item in command)
            {
                commands.Add(item.Number,item);
            }
        }


        public void Process(int number)
        {
            if (!this.commands.TryGetValue(number, out var command)) return;

            command.Execute();
        }

        public IEnumerable<ICommand> Commands => this.commands.Values.AsEnumerable();
    }
}