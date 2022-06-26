using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using System.Threading;
using System.Threading.Tasks;

public class HoldPositionCommandExecutor : CommandExecutorBase<IHoldPositionCommand>
{
    public CancellationTokenSource CancellationTokenSource { get; set; }
    public override async Task ExecuteSpecificCommand(IHoldPositionCommand command)
    {
        CancellationTokenSource?.Cancel();
    }
}
