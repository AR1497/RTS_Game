using System.Collections.Generic;
using Abstractions;
using Abstractions.Commands;
using UnityEngine;
using UserControlSystem.UI.View;
using Zenject;

namespace UserControlSystem.UI.Presenter
{
    public sealed class CommandButtonsPresenter : MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectable;
        [SerializeField] private CommandButtonsView _view;
        private ISelectable _currentSelectable;

        [Inject] private CommandButtonsModel _buttonModel;

        private void Start()
        {
            _view.OnClick += _buttonModel.OnCommandButtonClicked;
            _buttonModel.OnCommandSent += _view.UnblockAllInteractions;
            _buttonModel.OnCommandCancel += _view.UnblockAllInteractions;
            _buttonModel.OnCommandAccepted += _view.BlockInteractions;

            _selectable.OnNewValue += ONSelected;
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