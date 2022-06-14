﻿using System;
using System.Collections.Generic;
using System.Linq;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UnityEngine.UI;

namespace UserControlSystem.UI.View
{
    public sealed class CommandButtonsView : MonoBehaviour
    {
        public Action<ICommandExecutor> OnClick;

        [SerializeField] private GameObject _attackButton;
        [SerializeField] private GameObject _moveButton;
        [SerializeField] private GameObject _patrolButton;
        [SerializeField] private GameObject _holdPositionButton;
        [SerializeField] private GameObject _produceUnitButton;

        private Dictionary<Type, GameObject> _buttonsByExecutorType;

        private void Start()
        {
            _buttonsByExecutorType = new Dictionary<Type, GameObject>();
            _buttonsByExecutorType
                .Add(typeof(CommandExecutorBase<IAttackCommand>), _attackButton);
            _buttonsByExecutorType
                .Add(typeof(CommandExecutorBase<IMoveCommand>), _moveButton);
            _buttonsByExecutorType
                .Add(typeof(CommandExecutorBase<IPatrolCommand>), _patrolButton);
            _buttonsByExecutorType
                .Add(typeof(CommandExecutorBase<IHoldPositionCommand>), _holdPositionButton);
            _buttonsByExecutorType
                .Add(typeof(CommandExecutorBase<IProduceUnitCommand>), _produceUnitButton);
        }

        public void BlockInteractions(ICommandExecutor ce)
        {
            UnblockAllInteractions();
            GETButtonGameObjectByType(ce.GetType())
                .GetComponent<Selectable>().interactable = false;
        }

        public void UnblockAllInteractions() => SetInteractible(true);

        private void SetInteractible(bool value)
        {
            _attackButton.GetComponent<Selectable>().interactable = value;
            _moveButton.GetComponent<Selectable>().interactable = value;
            _patrolButton.GetComponent<Selectable>().interactable = value;
            _holdPositionButton.GetComponent<Selectable>().interactable = value;
            _produceUnitButton.GetComponent<Selectable>().interactable = value;
        }

        public void MakeLayout(List<ICommandExecutor> commandExecutors)
        {
            foreach (var currentExecutor in commandExecutors)
            {
                var buttonGameObject = GETButtonGameObjectByType(currentExecutor.GetType());
                buttonGameObject.SetActive(true);
                var button = buttonGameObject.GetComponent<Button>();
                button.onClick.AddListener(() => OnClick?.Invoke(currentExecutor));
            }
        }

        private GameObject GETButtonGameObjectByType(Type executorInstanceType)
        {
            return _buttonsByExecutorType
            .Where(type =>
            type.Key.IsAssignableFrom(executorInstanceType))
            .First()
            .Value;
        }

        public void Clear()
        {
            foreach (var kvp in _buttonsByExecutorType)
            {
                kvp.Value.GetComponent<Button>().onClick.RemoveAllListeners();
                kvp.Value.SetActive(false);
            }
        }
    }
}