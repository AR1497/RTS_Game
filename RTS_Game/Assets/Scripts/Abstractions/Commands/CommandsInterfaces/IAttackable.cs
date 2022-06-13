using Abstractions;
using Abstractions.Commands;
using UnityEngine;

public interface IAttackable : IHealthHolder
{
    public Transform Target { get; }
}
