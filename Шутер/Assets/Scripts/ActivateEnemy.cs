using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEnemy : MonoBehaviour
{
    public float DistanceToActivate = 20f;
    public bool _isActive = true;
    private Activator Activator;

    private void Start()
    {
        Activator = FindAnyObjectByType<Activator>();
        Activator.ObjectsToActivate.Add(this);
    }
    public void CheckDistance(Vector3 playerPosition)
    {
        float distance = Vector3.Distance(transform.position, playerPosition);
        if (_isActive)
        {
            if (distance > DistanceToActivate + 2f)
            {
                Deactivate();
            }
        }
        else
        {
            if (distance < DistanceToActivate)
            {
                Activate();
            }
        }
    }

    public void Activate()
    {
        _isActive = true;
        gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        _isActive = false;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        Activator.ObjectsToActivate.Remove(this);
    }
}
