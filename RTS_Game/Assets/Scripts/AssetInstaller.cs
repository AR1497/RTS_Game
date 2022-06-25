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
    [SerializeField] private ScriptableObjectValueBase<Vector3> _vector3Value;
    [SerializeField] private ScriptableObjectValueBase<IAttackable> _atackCommand;
    [SerializeField] private ScriptableObjectValueBase<IPatrolCommand> _patrolCommand;
    [SerializeField] private ScriptableObjectValueBase<ISelectable> _selectable;
    [SerializeField] private StatefulScriptableObjectValueBase<ISelectable> _selectedValues;
    [SerializeField] private Sprite _sprite;

    public override void InstallBindings()
    {
        Container.BindInstances(_assetContext, _vector3Value, _atackCommand, _patrolCommand, _selectable);
        Container.Bind<IAwaitable<IAttackable>>().FromInstance(_atackCommand);
        Container.Bind<IAwaitable<Vector3>>().FromInstance(_vector3Value);
        Container.Bind<IObservable<ISelectable>>().FromInstance(_selectedValues);
        Container.Bind<Sprite>().WithId("Chomper").FromInstance(_sprite);
    }
}