using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace Abstractions
{
    public interface ISelectable : IHealthHolder
    {
        Transform PivotPoint { get; }
        Sprite Icon { get; }

        public Vector3 CurrenntPosition { get; }

        //void ExecuteSpecificCommand(IProduceUnitCommand command);
        void SetSelected();
        void UnsetSelected();
    }
}