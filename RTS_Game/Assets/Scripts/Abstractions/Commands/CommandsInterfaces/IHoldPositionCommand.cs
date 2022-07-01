using UnityEngine;

namespace Abstractions.Commands.CommandsInterfaces
{
    public interface IHoldPositionCommand : ICommand
    {
        Vector3 Target { get; }
    }
}
