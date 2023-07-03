using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Poi_move : MonoBehaviour
{


    [SerializeField] float speed = 200f;
    [SerializeField] float jumpForce = 500f;

    //ground hesabý - zýplama 
    [SerializeField] Transform feet;
    [SerializeField] float overlapBoxsize = 0.1f;
    [SerializeField] float gravityMultipler = 3f;
    bool jumpPressed = false;


    Canvas GoDead;



    Rigidbody2D rb2d;
    Animator anim;
    
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        GoDead = GameObject.Find("GameOverScreen").GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        //ground algýlama
        Collider2D col = Physics2D.OverlapBox(feet.position,new Vector2(transform.localScale.x,overlapBoxsize),0,LayerMask.GetMask("Ground", "Obstacle")); //ground algýlama
        
        if (Input.GetButtonDown("Jump") && col && PauseMenu.isPaused == false)
        {
            jumpPressed = true;
        }
        if (anim.GetBool("isJump") && col)
        {
            anim.SetBool("isJump", false);
        }
        
        

    }
    private void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(horizontalMovement * speed * Time.deltaTime, rb2d.velocity.y);
        
        anim.SetFloat("h_speed", Mathf.Abs(rb2d.velocity.x));
        


        if(Input.GetAxisRaw("Horizontal") == -1)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        

        if (jumpPressed)
        {
            rb2d.AddForce(new Vector2(0,jumpForce * Time.deltaTime),ForceMode2D.Impulse);
            anim.SetBool("isJump",true);
            jumpPressed = false;
        }

        if(rb2d.velocity.y < 0)
        {
            rb2d.velocity += new Vector2(0, Physics2D.gravity.y * (gravityMultipler - 1) * Time.deltaTime);
        }

        


    }
    //EDÝTÖRDE GÖRMEK ÝÇÝN
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(feet.position, new Vector2(transform.localScale.x, overlapBoxsize));
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
