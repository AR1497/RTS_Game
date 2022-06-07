using UnityEngine;
using Abstractions;

public class Beings : MonoBehaviour, ISelectable
{
    [SerializeField]
    private float _maxHealth = 50;
    [SerializeField]
    private Sprite _icon;
    [SerializeField]
    private GameObject _selected;

    private float _health = 50;

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
