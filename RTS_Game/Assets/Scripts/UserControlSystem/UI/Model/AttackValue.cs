using Abstractions.Commands.CommandsInterfaces;
using UnityEngine;

namespace UserControlSystem
{
    [CreateAssetMenu(fileName = nameof(AttackValue), menuName = "Strategy Game/" + nameof(AttackValue), order = 0)]
    public class AttackValue : ScriptableObjectValueBase<IAttackCommand>
    {

    }
}