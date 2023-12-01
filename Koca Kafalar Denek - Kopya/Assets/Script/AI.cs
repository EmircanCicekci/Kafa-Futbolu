using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    public float rangerDenfece, speed;
    public Transform denfece,checkGround;
    private GameObject _ball;
    private Rigidbody2D rb_AI;
    public bool canShootAI, canHead, grounded;
    public LayerMask ground_layer;

    void Start()
    {
        _ball = GameObject.FindGameObjectWithTag("Ball");
        rb_AI = GetComponent<Rigidbody2D>();
    }

 
    void Update()
    {
        if(GameController.instance.isScore==false&&GameController.instance.EndMatch==false)
        {
            Move();
            if (canShootAI == true)
            {
                Shoot();
            }
            if (canHead == true && grounded == true)
            {
                Jump();
            }
        }
    }
    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(checkGround.position, 0.2f, ground_layer);
    }
    public void Move()
      {
        if (Mathf.Abs(_ball.transform.position.x - transform.position.x) < rangerDenfece)
        {
            if (_ball.transform.position.x > transform.position.x && _ball.transform.position.x < -0.5f)
            {
                rb_AI.velocity = new Vector2(Time.deltaTime * speed, rb_AI.velocity.y);
            }
            else if(_ball.transform.position.y>=-0.5f && transform.position.x<=denfece.position.x)
            {
                rb_AI.velocity = new Vector2(0, rb_AI.velocity.y);
            }
            else
            {
                rb_AI.velocity = new Vector2(-Time.deltaTime * speed, rb_AI.velocity.y);
            }
        }
        else
        {
            if(_ball.transform.position.x > denfece.position.x && _ball.transform.position.x>1f)
            {
                rb_AI.velocity = new Vector2(-Time.deltaTime * speed, rb_AI.velocity.y);
            }
            else
            {
                rb_AI.velocity = new Vector2(0, rb_AI.velocity.y);
            }
        }



      }
    public void Shoot()
    {

        _ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(100,150));


    }
    public void Jump()
    {
        rb_AI.velocity = new Vector2(rb_AI.velocity.x, 15);
    }
}
