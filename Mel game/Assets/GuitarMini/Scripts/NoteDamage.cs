using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteDamage : MonoBehaviour
{

    public float damageAmount = 0f;
    public bool canDamage;
    public float damageTimeout = 0f;

    void Start()
    {
        canDamage = true;
    }

    public void OnTriggerEnter(Collider player)
    {
        if (canDamage && player.gameObject.CompareTag("Player"))
        {
            Health.health -= damageAmount;
            StartCoroutine(damageTimer());
        }
    }

    //Wait A Sec To Damage Again
    private IEnumerator damageTimer()
    {
        canDamage = false;
        yield return new WaitForSeconds(damageTimeout);
        canDamage = true;
    }
}
