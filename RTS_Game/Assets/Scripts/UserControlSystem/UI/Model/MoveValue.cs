using Abstractions;
using UnityEngine;
using UserControlSystem;

[CreateAssetMenu(fileName = nameof(MoveValue), menuName = "Strategy Game/" + nameof(MoveValue), order = 0)]
public class MoveValue : ScriptableObjectValueBase<IMovable>
{

}