using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpForce : MonoBehaviour
{
    public float upForce = 2;
    public bool isIn;
    private void OnTriggerStay2D(Collider2D collision)
    {
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            isIn = true;
            Vector2 currentVelocity = rb.velocity;
            rb.velocity = new Vector2(currentVelocity.x, upForce);
        }
    }
}
