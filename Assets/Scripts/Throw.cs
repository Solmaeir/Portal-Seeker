using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public float launchForce = -100f; 

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            Vector2 newVelocity = rb.velocity + (Vector2.left * launchForce);
            rb.velocity = newVelocity;
           
        }
    }
}
