using UnityEngine;

namespace Abstractions
{
    public interface ISelectable : IHealthHolder
    {
        Transform PivotPoint { get; }
        Sprite Icon { get; }

        public Vector3 CurrenntPosition { get; }

        void SetSelected();
        void UnsetSelected();
    }
}