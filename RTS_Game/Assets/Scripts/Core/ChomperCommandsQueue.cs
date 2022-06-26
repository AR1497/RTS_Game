using UnityEngine;
using UniRx;
using Zenject;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using Core;

public class ChomperCommandsQueue : MonoBehaviour, ICommandsQueue
{
    [Inject] CommandExecutorBase<IMoveCommand> _moveCommandExecutor;
    [Inject] CommandExecutorBase<IPatrolCommand> _patrolCommandExecutor;
    [Inject] CommandExecutorBase<IAttackCommand> _attackCommandExecutor;
    [Inject] CommandExecutorBase<IHoldPositionCommand> _holdPositionCommandExecutor;
    private ReactiveCollection<ICommand> _innerCollection = new
    ReactiveCollection<ICommand>();
    [Inject]
    private void Init()
    {
        _innerCollection
        .ObserveAdd().Subscribe(ONNewCommand).AddTo(this);
    }
    private void ONNewCommand(ICommand command, int index)
    {
        if (index == 0)
        {
            ExecuteCommand(command);
        }
    }
    private async void ExecuteCommand(ICommand command)
    {
        await _moveCommandExecutor.TryExecuteCommand(command);
        await _patrolCommandExecutor.TryExecuteCommand(command);
        await _attackCommandExecutor.TryExecuteCommand(command);
        await _holdPositionCommandExecutor.TryExecuteCommand(command);
        if (_innerCollection.Count > 0)
        {
            _innerCollection.RemoveAt(0);
        }
        checkTheQueue();
    }
    private void checkTheQueue()
    {
        if (_innerCollection.Count > 0)
        {
            ExecuteCommand(_innerCollection[0]);
        }
    }
    public void EnqueueCommand(object wrappedCommand)
    {
        var command = wrappedCommand as ICommand;
        _innerCollection.Add(command);
    }
    public void Clear()
    {
        _innerCollection.Clear();
        _holdPositionCommandExecutor.ExecuteSpecificCommand(new HoldPositionCommand());
    }
}