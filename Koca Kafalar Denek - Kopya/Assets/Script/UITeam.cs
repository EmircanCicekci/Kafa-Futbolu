using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITeam : MonoBehaviour
{
    public static UITeam instance;
    public Sprite[] FlagTeam;
    public string[] NameTeam;

    public Sprite[] head, shoe;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
