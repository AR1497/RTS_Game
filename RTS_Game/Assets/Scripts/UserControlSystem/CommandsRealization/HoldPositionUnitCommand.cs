using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace UserControlSystem.CommandsRealization
{
    public sealed class HoldPositionUnitCommand : IHoldPositionCommand
    {
        public Vector3 Target { get; private set; }
    }
}