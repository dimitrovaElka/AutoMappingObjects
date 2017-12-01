
namespace Employees.App
{
    using Employees.App.Command;
    using System;
    using System.Linq;
    using System.Reflection;
    internal class CommandParser
    {
        public static ICommand Parse(IServiceProvider serviceProvider, string commandName)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var commandTypes = assembly.GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(ICommand)));
            var commandType = commandTypes.SingleOrDefault(t => t.Name == $"{commandName}Command");
            if (commandType == null)
            {
                throw new InvalidOperationException("Invalid command!");
            }
            var constructor = commandType.GetConstructors().FirstOrDefault();

            var constructorParams = constructor.GetParameters()
                .Select(pi => pi.GetType());

            var constructorArgs = constructorParams.Select(p => serviceProvider.GetService(p)).ToArray();

            var command = (ICommand)constructor.Invoke(constructorArgs);
            return command;
        }
    }
}
