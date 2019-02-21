using System.Reflection;
using Practice.HomeWork.Abstractions;
using Practice.HomeWork.Abstractions.BLL;
using Practice.HomeWork.Services;
using Practice.HomeWork.Services.PL;
using Practice.HomeWork.Services.PL.Commands;
using SimpleInjector;

namespace Practice.HomeWork
{
    internal class Program
    {
        private static void Main()
        {
            // Your Inversion of Control (Simple Injector)
            var container = new Container();
            container.Register<ICommandProcessor, CommandProcessor>();
            container.Collection.Register<ICommand>
                (typeof(AddUserCommand),
                typeof(ListUsersCommand));
            container.Register<IUserStore,UserStore>();
            container.Register<IDatabaseService,InMemoryDatabaseService>(Lifestyle.Singleton);
            container.Register<CommandManager>();

            container.Verify();
            //var manager = new CommandManager();

            //manager.Start();

            CommandManager manager = container.GetInstance<CommandManager>();
            manager.Start();
        }
    }
}
