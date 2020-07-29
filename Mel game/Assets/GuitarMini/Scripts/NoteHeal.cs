using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteHeal : MonoBehaviour
{

    public float healthAmount = 0f;
    public bool canHeal;
    public float healTimeout = 0f;

    void Start()
    {
        canHeal = true;
    }

    public void OnTriggerEnter(Collider player)
    {
        if (canHeal && player.gameObject.CompareTag("Player"))
        {
            Health.health += healthAmount;
            StartCoroutine(healthTimer());
        }
    }

    //Wait A Sec To Heal Again
    private IEnumerator healthTimer()
    {
        canHeal = false;
        yield return new WaitForSeconds(healTimeout);
        canHeal = true;
    }
}
