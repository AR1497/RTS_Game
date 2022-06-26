using System;
using Abstractions.Commands.CommandsInterfaces;
using UserControlSystem.CommandsRealization;

namespace UserControlSystem
{
    public sealed class StopCommandCommandCreator : CommandCreatorBase<IHoldPositionCommand>
    {
        protected override void ClassSpecificCommandCreation(Action<IHoldPositionCommand> creationCallback)
            => creationCallback?.Invoke(new HoldPositionUnitCommand());
    }
}