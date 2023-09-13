using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private UnityEvent _healthUpdated;
    [SerializeField] private int _health;

    public event UnityAction HealthUpdated
    {
        add => _healthUpdated.AddListener(value);
        remove => _healthUpdated.RemoveListener(value);
    }

    public int Health => _health;

    public void TakeDamage(int damage)
    {
        if (damage > 0)
        {
            _health -= damage;
            _healthUpdated?.Invoke();
        }
    }

    private void Start()
    {
        _healthUpdated?.Invoke();
    }
}