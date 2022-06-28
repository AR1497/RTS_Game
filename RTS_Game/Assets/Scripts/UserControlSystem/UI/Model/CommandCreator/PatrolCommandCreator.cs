using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UserControlSystem.CommandsRealization;
using Zenject;

namespace UserControlSystem
{
    public sealed class PatrolCommandCreator : CancellableCommandCreatorBase<IPatrolCommand, Vector3>
    {
        [Inject] private SelectableValue _selectable;

        protected override IPatrolCommand CreateCommand(Vector3 argument) 
            => new PatrolUnitCommand(_selectable.CurrentValue.PivotPoint.position, argument);
    }
}