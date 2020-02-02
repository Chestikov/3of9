using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Helmet : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private float _durability;

    public event Action<float> DurabilityChanged;

    public void ReduceDurability(float incomingDamage)
    {
        _durability -= incomingDamage / 10;
        DurabilityChanged?.Invoke(_durability);
    }
}

public class HelmetView : MonoBehaviour
{
    [SerializeField] private Image _itemIcon;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private TextMeshProUGUI _durabilityText;

    private Helmet _helmet;

    private void OnEnable() => _helmet.DurabilityChanged += OnDurabilityChanged;

    private void OnDisable() => _helmet.DurabilityChanged -= OnDurabilityChanged;

    private void OnDurabilityChanged(float value) => _durabilityText.text = value.ToString();
}
