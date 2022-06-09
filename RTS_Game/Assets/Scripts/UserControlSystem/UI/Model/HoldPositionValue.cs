using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace UserControlSystem
{
    [CreateAssetMenu(fileName = nameof(HoldPositionValue), menuName = "Strategy Game/" + nameof(HoldPositionValue), order = 0)]
    public sealed class HoldPositionValue : ScriptableObjectValueBase<IHoldPositionCommand>
    {

    }
}