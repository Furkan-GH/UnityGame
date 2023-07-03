using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightLeftControl : MonoBehaviour
{
    Canvas GoDead;

    private bool mainCameraCollision = false;
    private bool blokeCollision = false;


    void Start()
    {
        GoDead = GameObject.Find("GameOverScreen").GetComponent<Canvas>();
    }

        private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("MainCamera"))
        {
            mainCameraCollision = true;
        }
        else if (collision.collider.CompareTag("Bloke"))
        {
            blokeCollision = true;
        }

        CheckCollision();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("MainCamera"))
        {
            mainCameraCollision = false;
        }
        else if (collision.collider.CompareTag("Bloke"))
        {
            blokeCollision = false;
        }

        CheckCollision();
    }

    private void CheckCollision()
    {
        if (mainCameraCollision && blokeCollision)
        {
            Destroy(gameObject);
            GoDead.enabled = true;
            
        }
    }









}
