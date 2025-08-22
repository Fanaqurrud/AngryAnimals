using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public EnemyHealth EnemyHealth;
    public bool DieOnAnyCollision;
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.GetComponent<bullet>())
            {
                EnemyHealth.TakeDamage(1);
            }
        }
        if (DieOnAnyCollision == true)
        {
            if (other.isTrigger == false)
            {
                EnemyHealth.TakeDamage(10000);
            }
        }
    }
}
