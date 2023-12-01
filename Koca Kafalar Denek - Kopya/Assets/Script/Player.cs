using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public float horialAxis, speed;
    private Rigidbody2D rb_player;
    public bool canShoot, grounded;
    public GameObject _ball;
    public Transform checkGround;
    public LayerMask ground_layer;



    void Start()
    {
        rb_player = GetComponent<Rigidbody2D>();
        _ball = GameObject.FindGameObjectWithTag("Ball");
    }

   
    void Update()
    {
        horialAxis = Input.GetAxis("Horizontal");
    }

    public void FixedUpdate()
    {
        rb_player.velocity = new Vector2(Time.deltaTime * speed * horialAxis, rb_player.velocity.y);
        grounded = Physics2D.OverlapCircle(checkGround.position, 0.2f, ground_layer);
         
    }

    public void Move(int value)
    {
        if (GameController.instance.isScore == false && GameController.instance.EndMatch == false)
        {
            horialAxis = value;
        }
    }
    public void StopMove()
    {

        horialAxis = 0;

    }


    public void Shoot()
    {
        if(canShoot==true)
        {
            _ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-400, 500));
        }
    }
    public void Jump()
    {
        if (grounded ==true && GameController.instance.isScore == false && GameController.instance.EndMatch == false)
        {
            rb_player.velocity = new Vector2(rb_player.velocity.x, 15);
        }
    }
}

