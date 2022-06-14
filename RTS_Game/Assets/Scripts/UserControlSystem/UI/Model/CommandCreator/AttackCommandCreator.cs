using System;
using Abstractions.Commands.CommandsInterfaces;
using UserControlSystem.CommandsRealization;
using Utils;
using Zenject;

namespace UserControlSystem
{
    public class AttackCommandCreator : CancellableCommandCreatorBase<IAttackCommand, IAttackable>
    {
        //[Inject] private AssetsContext _context;
        //private Action<IAttackCommand> _creationCallback;

        protected override IAttackCommand CreateCommand(IAttackable argument) => new AttackUnitCommand(argument);

    //    [Inject]
    //    private void Init(ScriptableObjectValueBase<IAttackable> groundClicks)
    //    {
    //        groundClicks.OnNewValue += onNewValue;
    //    }


    //    private void onNewValue(IAttackable target)
    //    {
    //        _creationCallback?.Invoke(_context.Inject(new AttackUnitCommand(target)));
    //        _creationCallback = null;
    //    }
    //    protected override void ClassSpecificCommandCreation(Action<IAttackCommand> creationCallback)
    //    {
    //        _creationCallback = creationCallback;
    //    }
    //    public override void ProcessCancel()
    //    {
    //        base.ProcessCancel();
    //        _creationCallback = null;
    //    }
    }
}