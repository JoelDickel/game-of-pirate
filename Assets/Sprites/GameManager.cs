using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{   
    public static float time;
    public Text textTime;


    public GameObject pannelSettings;
    private bool pannelOn;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if(time == 0)
        {
            time = 60;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void BtnOneMinute()
    {
        time = 60f;
        textTime.text = "1 min";
    }

    public void BtnTwoMinute()
    {
        time = 120f;
        textTime.text = "2 min";
    }

    public void BtnThreeMinute()
    {
        time = 180f;
        textTime.text = "3 min";
    }


    public void BtnPannelSettins()
    {
        if (pannelOn == false)
        {
            pannelSettings.SetActive(true);
            pannelOn = true;
        }
        else
        {
            pannelSettings.SetActive(false);
            pannelOn = false;
        }
    }
}
