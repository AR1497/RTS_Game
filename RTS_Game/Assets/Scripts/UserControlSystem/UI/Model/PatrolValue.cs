using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace UserControlSystem
{
    [CreateAssetMenu(fileName = nameof(PatrolValue), menuName = "Strategy Game/" + nameof(PatrolValue), order = 0)]
    public sealed class PatrolValue : ScriptableObjectValueBase<IPatrolCommand>
    {

    }
}