using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using System.Threading;

public class HoldPositionCommandExecutor : CommandExecutorBase<IHoldPositionCommand>
{
    public CancellationTokenSource CancellationTokenSource { get; set; }
    public override void ExecuteSpecificCommand(IHoldPositionCommand command)
    {
        CancellationTokenSource?.Cancel();
    }
}
