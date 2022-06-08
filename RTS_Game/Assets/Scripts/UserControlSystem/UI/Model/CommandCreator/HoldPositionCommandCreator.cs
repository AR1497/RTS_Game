using System;
using Abstractions.Commands.CommandsInterfaces;

namespace UserControlSystem
{
    public sealed class HoldPositionCommandCreator : CommandCreatorBase<IHoldPositionCommand>
    {
        protected override void ClassSpecificCommandCreation(Action<IHoldPositionCommand> creationCallback)
        {

        }
    }
}