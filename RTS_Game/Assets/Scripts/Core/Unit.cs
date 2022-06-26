using Abstractions;
using Assets.Scripts.Abstractions;
using Core.CommandExecutors;
using UnityEngine;

namespace Core
{ 
    public class Unit : MonoBehaviour, ISelectable, IAttackable, IUnit, IDamageDealer
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private HoldPositionCommandExecutor _holdPositionCommand;
        [SerializeField] private float _maxHealth = 70;
        [SerializeField] private Transform _pivotPoint;
        [SerializeField] private Sprite _icon;
        [SerializeField] private int _damage = 25;
        [SerializeField] private GameObject _selected;

        private float _health = 70;

        public Transform Target => gameObject.transform;
        public Transform PivotPoint => _pivotPoint;

        public Vector3 CurrenntPosition => gameObject.transform.position;

        public Sprite Icon => _icon;

        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public int Damage => _damage;

        public void ReceiveDamage(int amount)
        {
            if (_health <= 0)
            {
                return;
            }
            _health -= amount;
            if (_health <= 0)
            {
                _animator.SetTrigger("PlayDead");
                Invoke(nameof(Destroy), 1f);
            }
        }

        private async void Destroy()
        {
            await _holdPositionCommand.ExecuteSpecificCommand(new HoldPositionCommand());
            Destroy(gameObject);
        }

        public void UnsetSelected()
        {
            _selected.SetActive(false);
        }

        public void SetSelected()
        {
            _selected.SetActive(true);
        }
    }
}