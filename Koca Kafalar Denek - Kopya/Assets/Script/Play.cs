using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Play : MonoBehaviour
{
    public Image flagPlayer ;
    public Text txtValuePlayer, namePlayer; 
    public Image flagAI ;
    public Text txtValueAI, nameAI;

    void Start()
    {
       // valueAI = PlayerPrefs.GetInt("valueAI", 1);
    }

    
    void Update()
    {
        // UI player
        flagPlayer.sprite = UITeam.instance.FlagTeam[PlayerPrefs.GetInt("valuePlayer", 1) - 1];
        namePlayer.text= UITeam.instance.NameTeam[PlayerPrefs.GetInt("valuePlayer", 1) - 1];
        txtValuePlayer.text = PlayerPrefs.GetInt("valuePlayer", 1) + "/8";
        //AI player
        flagAI.sprite = UITeam.instance.FlagTeam[PlayerPrefs.GetInt("valueAI", 1) - 1];
        nameAI.text = UITeam.instance.NameTeam[PlayerPrefs.GetInt("valueAI", 1) - 1];
        txtValueAI.text = PlayerPrefs.GetInt("valueAI", 1) + "/8";
    }
    
    public void ButtonBack()
    {
        Application.LoadLevel("Menu");
    }
    public void ButtonNext()
    {
        Application.LoadLevel("Game");
    }
    public void ButtonLeftPlayer()
    {
        if (PlayerPrefs.GetInt("valuePlayer", 1)<=1)
        {
            PlayerPrefs.SetInt("valuePlayer", 8);
        }
        else
        {
           int valuePlayer = PlayerPrefs.GetInt("valuePlayer", 1);
            valuePlayer--;
            PlayerPrefs.SetInt("valuePlayer", valuePlayer);
        }
    }
    public void ButtonRightPlayer()
    {
        if (PlayerPrefs.GetInt("valuePlayer", 1) >= 8)
        {
            PlayerPrefs.SetInt("valuePlayer", 1);
        }
        else
        {
           int valuePlayer = PlayerPrefs.GetInt("valuePlayer", 1);
            valuePlayer++;
            PlayerPrefs.SetInt("valuePlayer", valuePlayer);
        }
    }
    public void ButtonLeftAI()
    {
        if (PlayerPrefs.GetInt("valueAI", 1) <= 1)
        {
            PlayerPrefs.SetInt("valueAI", 8);
        }
        else
        {
            int valueAI = PlayerPrefs.GetInt("valueAI", 1);
            valueAI--;
            PlayerPrefs.SetInt("valueAI", valueAI);
        }


    }
    public void ButtonRightAI()
    {

        if (PlayerPrefs.GetInt("valueAI", 1) >= 8)
        {
            PlayerPrefs.SetInt("valueAI", 1);
        }
        else
        {
            int valueAI = PlayerPrefs.GetInt("valueAI", 1);
            valueAI++;
            PlayerPrefs.SetInt("valueAI", valueAI);
        }

    }
}

