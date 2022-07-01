using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace Core
{
    public class HoldPositionCommand : IHoldPositionCommand
    {
        public Vector3 Target => throw new System.NotImplementedException();
    }
}