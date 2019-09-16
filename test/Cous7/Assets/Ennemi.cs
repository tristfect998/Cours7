﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class Ennemi : MonoBehaviour, Damageable {
    public int lifeTotal = 1;

    public void TakeDamage(int damage)
    {
        lifeTotal -= damage;
        if(lifeTotal <= 0)
        {
            Die();
        }
    }

    public abstract void Die();

    protected void SetLife(int pLifeTotal)
    {
        lifeTotal = pLifeTotal;
    }
}
