using UnityEngine;
using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using System.Threading.Tasks;

namespace Core
{
    public class MainBuilding : CommandExecutorBase<IProduceUnitCommand>, ISelectable
    {
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Transform PivotPoint => _pivotPoint;
        public Sprite Icon => _icon;
        public Vector3 RallyPoint { get; set; }

        [SerializeField] private Transform _unitsParent;
        [SerializeField] private float _maxHealth = 1000;
        [SerializeField] private Transform _pivotPoint;
        [SerializeField] private Sprite _icon;
        [SerializeField] private GameObject _selected;

        private float _health = 1000;

        public Vector3 CurrenntPosition => gameObject.transform.position;

        public override async Task ExecuteSpecificCommand(IProduceUnitCommand command)
        {
            await CreateUnitTask(command);
        }

        private async Task CreateUnitTask(IProduceUnitCommand command)
        {
            await Task.Delay(5000);
            Instantiate(command.UnitPrefab,
                                   new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)),
                                   Quaternion.identity,
                                   _unitsParent);
        }

        public void RecieveDamage(int amount)
        {
            if (_health <= 0)
            {
                return;
            }
            _health -= amount;
            if (_health <= 0)
            {
                Destroy(gameObject);
            }
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