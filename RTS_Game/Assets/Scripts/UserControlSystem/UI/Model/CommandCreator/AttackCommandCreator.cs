using Abstractions.Commands.CommandsInterfaces;
using UserControlSystem.CommandsRealization;

namespace UserControlSystem
{
    public class AttackCommandCreator : CancellableCommandCreatorBase<IAttackCommand, IAttackable>
    {
        protected override IAttackCommand CreateCommand(IAttackable argument) => new AttackUnitCommand(argument);
    }
}