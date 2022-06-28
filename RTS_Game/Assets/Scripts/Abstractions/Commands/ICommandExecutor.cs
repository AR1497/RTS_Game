using Abstractions.Commands.CommandsInterfaces;

namespace Abstractions.Commands
{
    public interface ICommandExecutor
    {
    }

    public interface ICommandExecutor<T> : ICommandExecutor where T : ICommand
    {
    }
}
