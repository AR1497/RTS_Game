using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace Abstractions
{
    public interface ISelectable : IHealthHolder, IIconHolder
    {
        Transform PivotPoint { get; }

        void UnsetSelected();
        void SetSelected();
    }
}