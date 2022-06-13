using System;
using Abstractions;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UserControlSystem.CommandsRealization;
using Utils;
using Zenject;

namespace UserControlSystem
{
    public class PatrolCommandCreator : CancellableCommandCreatorBase<IPatrolCommand, Vector3>
    {
        [Inject] private AssetsContext _context;
        [Inject] private ScriptableObjectValueBase<ISelectable> _selectedObject;

        private Action<IPatrolCommand> _creationCallback;

        protected override IPatrolCommand CreateCommand(Vector3 argument)
            => new PatrolUnitCommand(_selectedObject.CurrentValue.PivotPoint.position, argument);

        [Inject]
        private void Init(ScriptableObjectValueBase<Vector3> groundClicks)
        {
            groundClicks.OnNewValue += onNewValue;
        }

        private void onNewValue(Vector3 groundClick)
        {
            _creationCallback?.Invoke(_context.Inject(new PatrolUnitCommand(_selectedObject.CurrentValue.CurrenntPosition, groundClick)));
            _creationCallback = null;
        }

        protected override void ClassSpecificCommandCreation(Action<IPatrolCommand> creationCallback)
        {
            _creationCallback = creationCallback;
        }
    }
}