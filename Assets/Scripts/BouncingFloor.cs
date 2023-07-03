using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncingFloor : MonoBehaviour
{

    Rigidbody2D rb;

    public float jumpForce = 1f;
    

    private void OnCollisionEnter2D(Collision2D col)
    {
        rb = col.collider.GetComponent<Rigidbody2D>();
        
        
        if(rb != null)
        {
            Vector2 jumpVelocity = rb.velocity;
            jumpVelocity.y = jumpForce;
            rb.velocity = jumpVelocity;
        }
        
    }




}
