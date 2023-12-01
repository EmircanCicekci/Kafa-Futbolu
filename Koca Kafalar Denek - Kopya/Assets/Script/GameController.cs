using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public Text txt_GoalsRight, txt_GoalsLeft, txt_timeMatch;
    public static int number_GoalsRight, number_GoalsLeft;
    public bool isScore, EndMatch;
    public float timeMatch;
    public GameObject _ball,_AI,_Player;
    public GameObject PanelPause;
    public Image flagLeft, flagRight;
    public Text nameLeft, nameRight;


    public SpriteRenderer headPlayer, shoePlayer, headAI, shoeAI;
    


    public void Awake()
    {
        if (instance==null)
        {
            instance = this;
        }
    }
    void Start()
    {
        number_GoalsLeft = 0;
        number_GoalsRight = 0;
        timeMatch = 60;
        _ball = GameObject.FindGameObjectWithTag("Ball");
        _AI= GameObject.FindGameObjectWithTag("AI");
        _Player = GameObject.FindGameObjectWithTag("Player");

        flagLeft.sprite = UITeam.instance.FlagTeam[PlayerPrefs.GetInt("valueAI", 1) - 1];
        nameLeft.text = UITeam.instance.NameTeam[PlayerPrefs.GetInt("valueAI", 1) - 1];
        flagRight.sprite = UITeam.instance.FlagTeam[PlayerPrefs.GetInt("valuePlayer", 1) - 1];
        nameRight.text = UITeam.instance.NameTeam[PlayerPrefs.GetInt("valuePlayer", 1) - 1];

        headPlayer.sprite = UITeam.instance.head[PlayerPrefs.GetInt("valuePlayer", 1) - 1];
        shoePlayer.sprite = UITeam.instance.shoe[PlayerPrefs.GetInt("valuePlayer", 1) - 1];

        headAI.sprite = UITeam.instance.head[PlayerPrefs.GetInt("valueAI", 1) - 1];
        shoeAI.sprite = UITeam.instance.shoe[PlayerPrefs.GetInt("valueAI", 1) - 1];
        StartCoroutine(BeginMatch());
    }

 
    void Update()
    {
        txt_GoalsLeft.text = number_GoalsLeft.ToString();
        txt_GoalsRight.text=number_GoalsRight.ToString();
        txt_timeMatch.text = timeMatch.ToString();
    }
    IEnumerator BeginMatch()
    {
        
        while(true)
        {
            yield return new WaitForSeconds(1f);
            if (timeMatch>0)
            {
                timeMatch--;
                
            }
            else
            {
                StartCoroutine(WaitEndGame());
                EndMatch = true;
                break;
            }
        }
    }
    public void ContinueMatch(bool winPlayer)
    {
        StartCoroutine(WaitContinueMatch(winPlayer));
    }
    IEnumerator WaitContinueMatch(bool winPlayer)
    {
        yield return new WaitForSeconds(2f);
        isScore = false;
        if (EndMatch==false)
        {
            _ball.transform.position = new Vector3(0, 0, 0);
            _ball.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            _AI.transform.position = new Vector3(-15, 0, 0);
            _Player.transform.position = new Vector3(-1, 0, 0);
            if(winPlayer==true)
            {
                _ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(100, 200));
                
            }
            else
            {
                _ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-100, 200));
            }
        }
    }

    public void ButtonPause()
    {
        PanelPause.SetActive(true);
        Time.timeScale = 0;
    }
    public void ButtonResume()
    {
        PanelPause.SetActive(false);
        Time.timeScale = 1;
    }
    public void ButtonLose()
    {
        number_GoalsLeft = 3;
        number_GoalsRight = 0;
        timeMatch = 0;
        StartCoroutine(WaitEndGame());
    }
    IEnumerator WaitEndGame()
    {
        yield return new WaitForSeconds(3f);
        Application.LoadLevel("EndGame");
    }
    public void ButtonSettings()
    {
        Application.LoadLevel("AyarlarPause");
    }

    


}
