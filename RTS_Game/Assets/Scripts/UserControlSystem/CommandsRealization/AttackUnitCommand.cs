using Abstractions.Commands.CommandsInterfaces;

namespace UserControlSystem.CommandsRealization
{
    public sealed class AttackUnitCommand : IAttackCommand
    {
        public AttackUnitCommand(IAttackable target)
        {
            Target = target;
        }

        public IAttackable Target { get; }
    }
}
