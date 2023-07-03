using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Script : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f; // Düþmanýn hareket hýzý
    [SerializeField] float moveRange = 5f; // Düþmanýn hareket edebileceði maksimum mesafe


    [SerializeField] float health;

    private float leftBound;
    private float rightBound;
    private bool moveRight = true;


    private int fullScore = 50;


    Animator anim;

    ParticleSystem dead;
    // Start is called before the first frame update
    void Start()
    {
        health = 3;


        leftBound = transform.position.y - moveRange / 2f;
        rightBound = transform.position.y + moveRange / 2f;

        anim = GetComponent<Animator>();
        dead = GameObject.Find("Extinction").GetComponent<ParticleSystem>();    
        dead.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("live", true);

        if (transform.position.y >= rightBound)
        {
            moveRight = false;
        }
        else if (transform.position.y <= leftBound)
        {
            moveRight = true;
        }

        // Hareket et
        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
        }


    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Fireball")
        {
            health -= 1;
            if(health == 0)
            {
                Vector2 batPos = gameObject.transform.position; 
                dead.transform.position = batPos;
                gameObject.SetActive(false);
                dead.Play();
                GameManager.instance.ChangeScore(fullScore);
            }
        }
       
    }
}
