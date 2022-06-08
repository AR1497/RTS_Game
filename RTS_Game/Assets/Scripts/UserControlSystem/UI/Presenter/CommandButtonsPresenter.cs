using System;
using System.Collections.Generic;
using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UserControlSystem.CommandsRealization;
using UserControlSystem.UI.View;
using Utils;
using Zenject;

namespace UserControlSystem.UI.Presenter
{
    public sealed class CommandButtonsPresenter : MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectable;
        [SerializeField] private CommandButtonsView _view;
        [SerializeField] private AssetsContext _context;
        [Inject] private CommandButtonsModel _model;

        private ISelectable _currentSelectable;

        private void Start()
        {
            _view.OnClick += _model.OnCommandButtonClicked;
            _model.OnCommandSent += _view.UnblockAllInteractions;
            _model.OnCommandCancel += _view.UnblockAllInteractions;
            _model.OnCommandAccepted += _view.BlockInteractions;

            _selectable.OnSelected += ONSelected;
            ONSelected(_selectable.CurrentValue);
        }

        private void ONSelected(ISelectable selectable)
        {
            if (_currentSelectable == selectable)
            {
                return;
            }
            if (_currentSelectable != null)
            {
                _model.OnSelectionChanged();
            }
            _currentSelectable = selectable;

            _view.Clear();
            if (selectable != null)
            {
                var commandExecutors = new List<ICommandExecutor>();
                commandExecutors.AddRange((selectable as Component).GetComponentsInParent<ICommandExecutor>());
                _view.MakeLayout(commandExecutors);
            }
        }

        //private void ONButtonClick(ICommandExecutor commandExecutor)
        //{
        //    switch (commandExecutor)
        //    {
        //        case var command when commandExecutor as CommandExecutorBase<IProduceUnitCommand>:
        //            if (command != null)
        //            {
        //                command.ExecuteCommand(_context.Inject(new ProduceUnitCommandHeir()));
        //            }
        //            break;
        //        case var command when commandExecutor as CommandExecutorBase<IAttackCommand>:
        //            if (command != null)
        //            {
        //                command.ExecuteCommand(new AttackUnitCommand());
        //            }
        //            break;
        //        case var command when commandExecutor as CommandExecutorBase<IMoveCommand>:
        //            if (command != null)
        //            {
        //                command.ExecuteCommand(new MoveUnitCommand());
        //            }
        //            break;
        //        case var command when commandExecutor as CommandExecutorBase<IPatrolCommand>:
        //            if (command != null)
        //            {
        //                command.ExecuteCommand(new PatrolUnitCommand());
        //            }
        //            break;
        //        case var command when commandExecutor as CommandExecutorBase<IHoldPositionCommand>:
        //            if (command != null)
        //            {
        //                command.ExecuteCommand(new HoldPositionUnitCommand());
        //            }
        //            break;
        //        default:
        //            throw new ApplicationException($"{nameof(CommandButtonsPresenter)}.{nameof(ONButtonClick)}:" +
        //                $"Unknown type of commands executor: {commandExecutor.GetType().FullName}!");
        //    }                           
        //}
    }
}