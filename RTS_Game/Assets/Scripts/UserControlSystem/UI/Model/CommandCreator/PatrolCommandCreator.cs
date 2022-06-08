using System;
using Abstractions.Commands.CommandsInterfaces;

namespace UserControlSystem
{
    public sealed class PatrolCommandCreator : CommandCreatorBase<IPatrolCommand>
    {
        protected override void ClassSpecificCommandCreation(Action<IPatrolCommand> creationCallback)
        {

        }
    }
}