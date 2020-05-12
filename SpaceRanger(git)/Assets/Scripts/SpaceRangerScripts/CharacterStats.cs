﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterStats : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth { get; private set; }

    public Stat damage;
    public Stat armor;

    private void Awake()
    {
        currentHealth = maxHealth;
    }
    

public void TakeDamage (int damage)
    {
        currentHealth -= damage;

        if(currentHealth <= 0)
        {
            //Die
        }
    }
}
