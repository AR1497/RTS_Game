using Abstractions;
using UnityEngine;

public class Tree : MonoBehaviour, ISelectable
{
    [SerializeField]
    private float _maxHealth = 100;
    [SerializeField]
    private Sprite _icon;
    [SerializeField]
    private GameObject _selected;

    private float _health = 100;

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
