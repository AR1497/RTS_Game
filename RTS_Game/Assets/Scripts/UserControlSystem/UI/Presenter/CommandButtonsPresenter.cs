using System;
using System.Collections.Generic;
using Abstractions;
using Abstractions.Commands;
using UniRx;
using UnityEngine;
using UserControlSystem.UI.View;
using Zenject;

namespace UserControlSystem.UI.Presenter
{
    public sealed class CommandButtonsPresenter : MonoBehaviour
    {
        [SerializeField] private CommandButtonsView _view;
        private ISelectable _currentSelectable;

        [Inject] private CommandButtonsModel _buttonModel;
        [Inject] private IObservable<ISelectable> _selectedValues;

        private void Start()
        {
            _view.OnClick += _buttonModel.OnCommandButtonClicked;
            _buttonModel.OnCommandSent += _view.UnblockAllInteractions;
            _buttonModel.OnCommandCancel += _view.UnblockAllInteractions;
            _buttonModel.OnCommandAccepted += _view.BlockInteractions;

            _selectedValues.Subscribe(ONSelected);
        }

        private void ONSelected(ISelectable selectable)
        {
            if (_currentSelectable == selectable)
            {
                return;
            }
            if (_currentSelectable != null)
            {
                _buttonModel.OnSelectionChanged();
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
    }
}