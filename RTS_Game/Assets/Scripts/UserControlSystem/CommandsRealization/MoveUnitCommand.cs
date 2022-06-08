using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

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
