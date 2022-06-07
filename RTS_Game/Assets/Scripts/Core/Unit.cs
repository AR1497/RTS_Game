using Abstractions;
using UnityEngine;

public class Unit : MonoBehaviour, ISelectable
{
    [SerializeField]
    private float _maxHealth = 70;
    [SerializeField]
    private Sprite _icon;
    [SerializeField]
    private GameObject _selected;

    private float _health = 70;

    public float Health => _health;
    public float MaxHealth => _maxHealth;
    public Sprite Icon => _icon;

    public void UnsetSelected()
    {
        _selected.SetActive(false);
    }

    public void SetSelected()
    {
        _selected.SetActive(true);
    }
}
