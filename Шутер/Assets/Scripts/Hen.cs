using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hen : MonoBehaviour
{
    public Rigidbody Rigidbody;
    private Transform _playerTransform;
    public float Speed = 3f;
    public float TimeToReachSpeed = 1f;

    private void Start()
    {
        _playerTransform = FindObjectOfType<PlayerMove>().transform;
    }
    void FixedUpdate()
    {
        Vector3 toPlayer = (_playerTransform.position - transform.position).normalized;
        Vector3 force = Rigidbody.mass * (toPlayer * Speed - Rigidbody.velocity)/TimeToReachSpeed;
        Rigidbody.AddForce(force);
    }
}
