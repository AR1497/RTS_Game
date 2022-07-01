using Abstractions.Commands;
using UnityEngine;

public interface IAttackable : ICommand
{
    public Transform Target { get; }
}
