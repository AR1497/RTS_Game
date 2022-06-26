using Abstractions;
using UnityEngine;

public class Tree : MonoBehaviour, ISelectable
{
    [SerializeField]
    private float _maxHealth = 100;
    [SerializeField] 
    private Transform _pivotPoint;
    [SerializeField]
    private Sprite _icon;
    [SerializeField]
    private GameObject _selected;

    private float _health = 100;

    public Vector3 CurrenntPosition => gameObject.transform.position;

    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Transform PivotPoint => _pivotPoint;
    public Sprite Icon => _icon;

    public Transform Target => gameObject.transform;

    public void UnsetSelected()
    {
        _selected.SetActive(false);
    }

    public void SetSelected()
    {
        _selected.SetActive(true);
    }
}
