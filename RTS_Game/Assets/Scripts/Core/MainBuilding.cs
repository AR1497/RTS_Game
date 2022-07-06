using UnityEngine;
using Abstractions;
using Abstractions.Commands;
using Abstractions.Commands.CommandsInterfaces;
using System.Threading.Tasks;

namespace Core
{
    public class MainBuilding : MonoBehaviour, ISelectable /*CommandExecutorBase<IProduceUnitCommand>, ISelectable*/
    {
        public float Health => _health;
        public float MaxHealth => _maxHealth;
        public Transform PivotPoint => _unitsParent;
        public Sprite Icon => _icon;

        public Vector3 RallyPoint { get; set; }

        [SerializeField] private Transform _unitsParent;
        [SerializeField] private float _maxHealth = 1000;
        [SerializeField] private Sprite _icon;
        [SerializeField] private GameObject _selected;

        private float _health = 1000;

        //public override async Task ExecuteSpecificCommand(IProduceUnitCommand command)
        //{
        //    await CreateUnitTask(command);
        //}

        //private async Task CreateUnitTask(IProduceUnitCommand command)
        //{
        //    await Task.Delay(2000);
        //    Instantiate(command.UnitPrefab, new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)), Quaternion.identity, _unitsParent);
        //}

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