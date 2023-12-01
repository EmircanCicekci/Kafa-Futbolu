using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Menu : MonoBehaviour
{
    public GameObject panelLoadding, panelTransit;
    public Image img_loading;
    public static bool isLoadding;
    public Text txt_loadding;
    void Start()
    {
        if (isLoadding == false)
        {
            StartCoroutine(WaitLoaddingMenu());

        }
        else
        {
            panelLoadding.SetActive(false);
        }
    }


    void Update()
    {
        if (img_loading.fillAmount < 1)
        {
            img_loading.fillAmount += 0.001f;
        }
        if (img_loading.fillAmount >= 1)
        {
            isLoadding = true;
        }
        txt_loadding.text = (int)(img_loading.fillAmount * 100) + "%";
    }
    IEnumerator WaitLoaddingMenu()
    {
        yield return new WaitForSeconds(1f);
        panelTransit.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        panelLoadding.SetActive(false);
        yield return new WaitForSeconds(1.5f);
        panelTransit.SetActive(false);

    }
    public void ButtonPlay()
    {
        Application.LoadLevel("Play");
    }
    public void ButtonSettings()
    {
        Application.LoadLevel("Ayarlar");
    }
    public void ButtonExit()
    {
        Debug.Log("Çýktýn");
        Application.Quit();
    }
}
