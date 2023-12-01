using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public Image flagLeft, flagRight;
    public Text nameLeft, nameRight;
    public Text result, goals;



    void Start()
    {

        flagLeft.sprite = UITeam.instance.FlagTeam[PlayerPrefs.GetInt("valueAI", 1) - 1];
        nameLeft.text = UITeam.instance.NameTeam[PlayerPrefs.GetInt("valueAI", 1) - 1];
        flagRight.sprite = UITeam.instance.FlagTeam[PlayerPrefs.GetInt("valuePlayer", 1) - 1];
        nameRight.text = UITeam.instance.NameTeam[PlayerPrefs.GetInt("valuePlayer", 1) - 1];


        goals.text = GameController.number_GoalsLeft + " " + GameController.number_GoalsRight;

        if (GameController.number_GoalsLeft > GameController.number_GoalsRight)
        {
            result.text = "Kaybettin !";

        }
        else if (GameController.number_GoalsLeft == GameController.number_GoalsRight)
        {
            result.text = "Berabere";
        }
        else
        {
            result.text = "Kazandýn !";
        }


    }




    void Update()
    {

    }

    public void ButtonMenu()
    {
        Application.LoadLevel("Menu");
    }
    public void ButtonRematch()
    {
        Application.LoadLevel("Game");
    }
    public void ButtonPlay()
    {
        Application.LoadLevel("Play");
    }


}
