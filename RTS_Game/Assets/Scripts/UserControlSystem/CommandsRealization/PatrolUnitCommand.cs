using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace UserControlSystem.CommandsRealization
{
    public class PatrolUnitCommand : IPatrolCommand
    {
        private readonly Vector3 _from;
        private readonly Vector3 _to;

        public PatrolUnitCommand(Vector3 @from, Vector3 to)
        {
            _from = @from;
            _to = to;
        }

        public Vector3 FromPosition => _from;
        public Vector3 ToPosition => _to;
        public void Patrol(Vector3 from, Vector3 to)
        {
            Debug.Log($"Patrolling from {from} to {to}");
        }
    }
}