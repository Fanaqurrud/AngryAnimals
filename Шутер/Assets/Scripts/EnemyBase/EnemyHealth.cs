using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{
    public int Health = 1;
    public UnityEvent EventOnTakeDamage;
    public void TakeDamage(int damagevalue)
    {
        Health -= damagevalue;

        if (Health <= 0 )
        {
            Die();
        }
        EventOnTakeDamage.Invoke();
    }
    public void Die()
    {
        Destroy(gameObject);        
    }
}
