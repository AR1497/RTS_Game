using Abstractions;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UserControlSystem;
using Utils;
using Zenject;

[CreateAssetMenu(fileName = "AssetInstaller", menuName = "Installers/AssetInstaller")]
public class AssetInstaller : ScriptableObjectInstaller<AssetInstaller>
{
    [SerializeField] private AssetsContext _legacyContext;
    [SerializeField] private ScriptableObjectValueBase<Vector3> _vector3Value;
    [SerializeField] private ScriptableObjectValueBase<IAttackCommand> _atackCommand;
    [SerializeField] private ScriptableObjectValueBase<IPatrolCommand> _patrolCommand;
    [SerializeField] private ScriptableObjectValueBase<IHoldPositionCommand> _holdPositionCommand;
    [SerializeField] private ScriptableObjectValueBase<ISelectable> _selectable;

    public override void InstallBindings()
    {
        Container.BindInstances(_legacyContext, _vector3Value, _atackCommand, _patrolCommand, _holdPositionCommand, _selectable);
    }
}