using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace Core.Command
{
    public class HoldPosition : CommandExecutorBase<IHoldPositionCommand>
    {
        public override void ExecuteSpecificCommand(IHoldPositionCommand command)
        {
            Debug.Log("Stop");
        }
    }
}