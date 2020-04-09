using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{

    //variables
    public static float health = 0f;
    public float HP = 10;
    public float healthCap = 0f;

    void Start()
    {
        health = HP;
    }

    void Update()
    {
        if (health <= 0f)
        {
            Die();
        }

        if (health >= healthCap)
        {
            health = healthCap;
        }

        HP = health;
    }

    //Death
    void Die()
    {
        Destroy(gameObject);
    }
}