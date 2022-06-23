using Abstractions.Commands.CommandsInterfaces;
using Core;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using Utils;

namespace Abstractions.Commands.CommandExecutors
{
    public class MoveCommandExecutor : CommandExecutorBase<IMoveCommand>
    {
        [SerializeField] private UnitMovementStop _stop;
        [SerializeField] private Animator _animator;
        [SerializeField] private HoldPositionCommandExecutor _holdPositionCommandExecutor;
        
        private static readonly int Walk = Animator.StringToHash("Walk");
        private static readonly int Idle = Animator.StringToHash("Idle");

        public override async void ExecuteSpecificCommand(IMoveCommand command)
        {
            GetComponent<NavMeshAgent>().destination = command.Target;
            _animator.SetTrigger(Walk);
            _holdPositionCommandExecutor.CancellationTokenSource = new CancellationTokenSource();
            try
            {
                await _stop
                .WithCancellation
            (
            _holdPositionCommandExecutor
            .CancellationTokenSource
            .Token
            );
            }
            catch
            {
                GetComponent<NavMeshAgent>().isStopped = true;
                GetComponent<NavMeshAgent>().ResetPath();
            }
            _holdPositionCommandExecutor.CancellationTokenSource = null;
            _animator.SetTrigger(Idle);
        }
    }
}