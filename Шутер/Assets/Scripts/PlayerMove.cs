using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public float MoveSpeed;
    public float JumpSpeed;
    public float Friction;
    public bool Grounded;
    public float MaxSpeed;

    public Transform ColliderTransform;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Grounded)
            {
                Rigidbody.AddForce(0, JumpSpeed, 0, ForceMode.VelocityChange);
            }
        }
        if ((Input.GetKey(KeyCode.LeftControl)) || (Input.GetKey(KeyCode.S)) || Grounded == false)
        {
            ColliderTransform.localScale = Vector3.Lerp(ColliderTransform.localScale, new Vector3(1f, 0.5f, 1f), Time.deltaTime * 15f);
        }
        else
        {
            ColliderTransform.localScale = Vector3.Lerp(ColliderTransform.localScale, new Vector3(1f, 1f, 1f), Time.deltaTime * 15f);
        }
    }
    public void FixedUpdate()
    {
        float speedmultiplier = 1f;
        if (Grounded == false)
        {
            speedmultiplier = 0.2f;
            if (Input.GetAxis("Horizontal") > 0 && Rigidbody.velocity.x > MaxSpeed)
            {
                speedmultiplier = 0f;
            }

            if (Input.GetAxis("Horizontal") < 0 && Rigidbody.velocity.x < -MaxSpeed)
            {
                speedmultiplier = 0f;
            }
        }


        Rigidbody.AddForce(Input.GetAxis("Horizontal") * MoveSpeed * speedmultiplier, 0, 0, ForceMode.VelocityChange);
        if (Grounded)
        {
            Rigidbody.AddForce(-Rigidbody.velocity.x * Friction, 0, 0, ForceMode.VelocityChange);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        
        float angle = Vector3.Angle(collision.contacts[0].normal, Vector3.up);
        if (angle < 45) {
            Grounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        Grounded = false;
    }
}
