using Abstractions.Commands.CommandsInterfaces;
using System.Numerics;

namespace UserControlSystem.CommandsRealization
{
    public sealed class MoveUnitCommand : IMoveCommand
    {
        public Vector3 Target { get; }

        public MoveUnitCommand(Vector3 target)
        {
            Target = target;
        }
    }
}
