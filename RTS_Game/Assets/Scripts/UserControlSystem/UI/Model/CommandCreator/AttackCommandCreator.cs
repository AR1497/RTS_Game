using System;
using Abstractions.Commands.CommandsInterfaces;

namespace UserControlSystem
{
    public sealed class AttackCommandCreator : CommandCreatorBase<IAttackCommand>
    {
        protected override void ClassSpecificCommandCreation(Action<IAttackCommand> creationCallback)
        {

        }
    }
}