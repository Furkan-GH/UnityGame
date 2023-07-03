using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teri_move : MonoBehaviour
{

    [SerializeField] float speed = 200f;
    [SerializeField] float fire_speed = 50f;
   
    Rigidbody2D rb2d;
    Animator anim;

    Canvas GoDead;

    public GameObject fireball;
    public Transform firePoint;

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
        if (Input.GetKeyDown(KeyCode.Space) && PauseMenu.isPaused == false)
        {
            shoot();
        }
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

    public void shoot()
    {
        if (Input.GetAxisRaw("Horizontal") == -1)
        {
            GameObject fire = Instantiate(fireball, firePoint.position,Quaternion.identity);
            fire.GetComponent<Rigidbody2D>().velocity = new Vector2(-fire_speed * Time.deltaTime, 0);
        }
        if (Input.GetAxisRaw("Horizontal") == 1)
        {
            GameObject fire = Instantiate(fireball, firePoint.position, Quaternion.identity);
            fire.GetComponent<Rigidbody2D>().velocity = new Vector2(fire_speed * Time.deltaTime, 0);
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
