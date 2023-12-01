using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ball : MonoBehaviour
{
    private GameObject _player, _AI;
    public GameObject goals;




    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _AI = GameObject.FindGameObjectWithTag("AI");
    }


    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _player.GetComponent<Player>().canShoot = true;
        }
        if (collision.gameObject.tag == "canShootAI")
        {
            _AI.GetComponent<AI>().canShootAI = true;
        }
        if (collision.gameObject.tag == "canHeadAI")
        {
            _AI.GetComponent<AI>().canHead = true;
        }
        if (collision.gameObject.tag == "GoalsRight")
        {
           
            if (GameController.instance.isScore == false && GameController.instance.EndMatch == false)
            {
                Instantiate(goals, new Vector3(0, -2, 0), Quaternion.identity);
                GameController.number_GoalsLeft++;
                GameController.instance.isScore = true;
                GameController.instance.ContinueMatch(true);
            }
        }
        if (collision.gameObject.tag == "GoalsLeft")
        {
            
            {
                if (GameController.instance.isScore == false && GameController.instance.EndMatch == false)
                {
                    Instantiate(goals, new Vector3(0, -2, 0), Quaternion.identity);
                    GameController.number_GoalsRight++;
                    GameController.instance.isScore = true;
                    GameController.instance.ContinueMatch(false);
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _player.GetComponent<Player>().canShoot = false;
        }
        if (collision.gameObject.tag == "canShootAI")
        {
            _AI.GetComponent<AI>().canShootAI = false;
        }
        if (collision.gameObject.tag == "canHeadAI")
        {
            _AI.GetComponent<AI>().canHead = false;
        }
    }
}
