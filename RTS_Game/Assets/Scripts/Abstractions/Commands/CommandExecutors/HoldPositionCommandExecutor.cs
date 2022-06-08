using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

public class HoldPositionCommandExecutor : CommandExecutorBase<IHoldPositionCommand>
{
    public override void ExecuteSpecificCommand(IHoldPositionCommand command)
    {
        Debug.Log($"{name} has stopped!");
    }
}
