using Abstractions;
using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;
using UserControlSystem.UI.Model;
using Utils;
using Zenject;

namespace UserControlSystem
{
    public class UIModelInstaller : MonoInstaller
    {
        [SerializeField] private AssetsContext _assetContext;
        [SerializeField] private ScriptableObjectValueBase<Vector3> _vector3Value;
        [SerializeField] private ScriptableObjectValueBase<IAttackable> _attackable;
        [SerializeField] private ScriptableObjectValueBase<ISelectable> _selectable;

        public override void InstallBindings()
        {
            Container.Bind<AssetsContext>().FromInstance(_assetContext);
            Container.Bind<ScriptableObjectValueBase<Vector3>>().FromInstance(_vector3Value);
            Container.Bind<ScriptableObjectValueBase<IAttackable>>().FromInstance(_attackable);
            Container.Bind<ScriptableObjectValueBase<ISelectable>>().FromInstance(_selectable);

            Container.Bind<CommandCreatorBase<IProduceUnitCommand>>()
                .To<ProduceUnitCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IAttackCommand>>()
                .To<AttackCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IMoveCommand>>()
                .To<MoveCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IPatrolCommand>>()
                .To<PatrolCommandCreator>().AsTransient();
            Container.Bind<CommandCreatorBase<IHoldPositionCommand>>()
                .To<HoldPositionCommandCreator>().AsTransient();

            Container.Bind<CommandButtonsModel>().AsTransient();
            Container.Bind<BottomCenterModel>().AsTransient();
        }
    }
}