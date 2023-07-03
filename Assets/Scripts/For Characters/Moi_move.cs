using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moi_move : MonoBehaviour
{

    
    [SerializeField] float speed = 200f;
    
    

    Rigidbody2D rb2d;
    Animator anim;
    BoxCollider2D collid;
    Transform trans;
    Canvas GoDead;
    
    // Start is called before the first frame update
    void Start()
    {
       
        
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        collid = GetComponent<BoxCollider2D>();
        trans = GetComponent<Transform>();
        GoDead = GameObject.Find("GameOverScreen").GetComponent<Canvas>();



    }

    // Update is called once per frame
    void Update()
    {
       
        
        if (Input.GetKey(KeyCode.Space) && PauseMenu.isPaused == false)
        {
            collid.size = new Vector3(4.726764f, 3.946493f);
            trans.localScale = new Vector3(0.4f, 0.4f);
        }
        else
        {
            collid.size = new Vector3(collid.size.x, 4.75f);
            trans.localScale = new Vector3(1, 1);
        }
       
        
        
        
    }
    private void FixedUpdate()
    {
        
        
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(horizontalMovement * speed * Time.deltaTime, rb2d.velocity.y);

        
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        
        

    }
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            GoDead.enabled = true;
        }


        if (collision.gameObject.CompareTag("Dead_plant"))
        {

            Destroy(gameObject);
            GoDead.enabled = true;

        }

        if (collision.gameObject.CompareTag("Wall"))

        {
            Destroy(gameObject);
            GoDead.enabled = true;
        }




    }
}
