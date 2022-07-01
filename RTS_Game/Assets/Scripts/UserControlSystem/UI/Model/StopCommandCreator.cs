using System;
using Abstractions.Commands.CommandsInterfaces;
using UserControlSystem.CommandsRealization;
using Utils;
using Zenject;

namespace UserControlSystem
{
    public sealed class StopCommandCreator : CommandCreatorBase<IHoldPositionCommand>
    {
        [Inject] private AssetsContext _context;

        protected override void ClassSpecificCommandCreation(Action<IHoldPositionCommand> creationCallback)
            => creationCallback?.Invoke(_context.Inject(new HoldPositionUnitCommand()));
    }
}