using UnityEngine;

namespace Abstractions.Commands.CommandsInterfaces
{
    public interface IPatrolCommand : ICommand
    {
        public Vector3 FromPosition { get; }
        public Vector3 ToPosition { get; }
        void Patrol(Vector3 from, Vector3 to);
    }
}