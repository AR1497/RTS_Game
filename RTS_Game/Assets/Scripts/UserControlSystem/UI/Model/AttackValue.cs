using UnityEngine;
using Utils;

namespace UserControlSystem
{
    [CreateAssetMenu(fileName = nameof(AttackValue), menuName = "Strategy Game/" + nameof(AttackValue), order = 0)]
    public class AttackValue : StatelessScriptableObjectValueBase<IAttackable>
    {

    }
}