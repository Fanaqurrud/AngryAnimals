using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    public List<ActivateEnemy> ObjectsToActivate = new List<ActivateEnemy>();

    public Transform playerTransform;
    void Update()
    {
        for (int i = 0; i < ObjectsToActivate.Count; i++)
        {
            ObjectsToActivate[i].CheckDistance(playerTransform.position);
        }
    }
}
