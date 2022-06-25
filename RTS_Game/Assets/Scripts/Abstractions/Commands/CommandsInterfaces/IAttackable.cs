using Abstractions;
using UnityEngine;

public interface IAttackable : IHealthHolder
{
    public Transform Target { get; }
}
