using System;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UserControlSystem.CommandsRealization;
using Utils;
using Zenject;

namespace UserControlSystem
{
    public sealed class MoveCommandCreator : CancellableCommandCreatorBase<IMoveCommand, Vector3>
    {
        [Inject] private AssetsContext _context;
        private Action<IMoveCommand> _creationCallback;

        protected override IMoveCommand CreateCommand(Vector3 argument) => new MoveUnitCommand(argument);

        [Inject]
        private void Init(ScriptableObjectValueBase<Vector3> groundClicks) => groundClicks.OnNewValue += ONNewValue;

        private void ONNewValue(Vector3 groundClick)
        {
            _creationCallback?.Invoke(_context.Inject(new MoveUnitCommand(groundClick)));
            _creationCallback = null;
        }

        protected override void ClassSpecificCommandCreation(Action<IMoveCommand> creationCallback)
            => _creationCallback = creationCallback;

        public override void ProcessCancel()
        {
            base.ProcessCancel();
            _creationCallback = null;
        }
    }
}