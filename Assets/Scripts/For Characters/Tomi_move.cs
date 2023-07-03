using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;



public class Tomi_move : MonoBehaviour
{
    [SerializeField] float speed = 200f;

    Rigidbody2D rb2d;
    Animator anim;
    ParticleSystem power;


    Canvas GoDead;

    // Start is called before the first frame update
    void Start()
    {
        GoDead = GameObject.Find("GameOverScreen").GetComponent<Canvas>();
        power = GameObject.Find("Tomi_pow_light").GetComponent<ParticleSystem>();
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        power.Stop();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        PowerofLight();

    }

    private void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(horizontalMovement * speed * Time.deltaTime, rb2d.velocity.y);
        anim.SetFloat("h_speed", Mathf.Abs(rb2d.velocity.x));

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
      
        if (collision.gameObject.CompareTag("Wall"))
        { 
            if (Input.GetKey(KeyCode.Space))
            {
               
                
                collision.gameObject.SetActive(false);
                
            }
            else
            {
                Destroy(gameObject);
                GoDead.enabled = true;
                
            }    
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            GoDead.enabled = true;
        }
        else if (collision.gameObject.CompareTag("Dead_plant"))
        {

            Destroy(gameObject);
            GoDead.enabled = true;
        }


    }

    void PowerofLight()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && PauseMenu.isPaused == false )
        {
            power.Play();
            Debug.Log("ParticleSystem is Playing");
            
        }
        else if(Input.GetKeyUp(KeyCode.Space) && PauseMenu.isPaused == false)
        {
            power.Stop();
            Debug.Log("ParticleSystem is stopping");
            
        }
       
    }

}

