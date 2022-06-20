using Abstractions;
using Abstractions.Commands.CommandsInterfaces;
using System;
using UnityEngine;
using UserControlSystem;
using Utils;
using Zenject;

[CreateAssetMenu(fileName = "AssetInstaller", menuName = "Installers/AssetInstaller")]
public class AssetInstaller : ScriptableObjectInstaller<AssetInstaller>
{
    [SerializeField] private AssetsContext _assetContext;
    [SerializeField] private StatelessScriptableObjectValueBase<Vector3> _vector3Value;
    [SerializeField] private StatelessScriptableObjectValueBase<IAttackable> _atackCommand;
    [SerializeField] private ScriptableObjectValueBase<IPatrolCommand> _patrolCommand;
    [SerializeField] private StatefulScriptableObjectValueBase<ISelectable> _selectable;
    [SerializeField] private IObservable<ISelectable> _selectedValues;

    public override void InstallBindings()
    {
        Container.BindInstances(_assetContext, _vector3Value, _atackCommand, _patrolCommand, _selectable);
        Container.Bind<IAwaitable<IAttackable>>().FromInstance(_atackCommand);
        Container.Bind<IAwaitable<Vector3>>().FromInstance(_vector3Value);
        Container.Bind<IObservable<ISelectable>>().FromInstance(_selectedValues);
    }
}