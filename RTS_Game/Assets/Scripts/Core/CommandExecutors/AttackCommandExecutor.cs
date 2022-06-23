using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace Abstractions.Commands.CommandExecutors
{
    public class AttackCommandExecutor : CommandExecutorBase<IAttackCommand>
    {
        public override void ExecuteSpecificCommand(IAttackCommand command)
        {
            Debug.Log($"Attacking {command.Target.Target.position}");
        }
    }
}