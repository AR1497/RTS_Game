using Abstractions;
using Core.CommandExecutors;
using UnityEngine;

namespace Core
{ 
    public class Unit : MonoBehaviour, ISelectable, IAttackable, IUnit
    {
        [SerializeField] private float _maxHealth = 70;
        [SerializeField] private Transform _pivotPoint;
        [SerializeField] private Sprite _icon;
        [SerializeField] private GameObject _selected;

        private float _health = 70;

        public Transform Target => gameObject.transform;
        public Transform PivotPoint => _pivotPoint;

        public Sprite Icon => _icon;
        public Vector3 RallyPoint { get; set; }

        public float Health => _health;
        public float MaxHealth => _maxHealth;

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