using Abstractions;
using Core.CommandExecutors;
using UnityEngine;

namespace Core
{ 
    public class Unit : MonoBehaviour, ISelectable
    {
        [SerializeField] private float _maxHealth = 70;
        [SerializeField] private Transform _pivotPoint;
        [SerializeField] private Sprite _icon;
        [SerializeField] private GameObject _selected;

        private float _health = 70;

        public Transform PivotPoint => _pivotPoint;
        public Sprite Icon => _icon;
        public float Health => _health;
        public float MaxHealth => _maxHealth;

        public Vector3 RallyPoint { get; internal set; }

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