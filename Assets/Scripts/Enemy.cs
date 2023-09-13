using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private int _health;

    public int Health => _health;

    public void TakeDamage(int damage)
    {
        if (damage > 0)
            _health -= damage;
    }
}
