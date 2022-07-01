using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour
{
    public GameObject[] AllPlayers;
    public GameObject Player;
    public GameObject endPanel, buttonPannel;
    public Text text;
    GameObject _temp;
    public static int sira=0;

    void Start()
    {
        text.text = 1 + "st";
    }

    void Update()
    {
        Debug.ClearDeveloperConsole();
        if (PlayerScript.gameEnd == false)
        {
            if (sira == 1)
                text.text = sira.ToString() + "st";
            if (sira == 2)
                text.text = sira.ToString() + "nd";
            if (sira == 3)
                text.text = sira.ToString() + "rd";
            if (sira > 3)
                text.text = sira.ToString() + "th";

            for (int i = 0; i <= 10; i++)
            {
                if (AllPlayers[i].name == Player.name)
                {
                    sira = i + 1;
                }
            }
        }

        if (PlayerScript.gameEnd == true)
        {
            endPanel.SetActive(true);
        }

        for (int a = 0; a <= 10; a++)
        {
            for (int b = 0; b <= 10; b++)
            {
                if (AllPlayers[b].transform.position.z < AllPlayers[b + 1].transform.position.z)
                {
                    _temp = AllPlayers[b];
                    AllPlayers[b] = AllPlayers[b + 1];
                    AllPlayers[b + 1] = _temp;

                }
            }
        }

       
        
        
        
    }
    private void FixedUpdate()
    {
        if (yuzdelik.yuzde == 100)
        {
            buttonPannel.SetActive(true);
        }
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
        yuzdelik.yuzde = 0;
        buttonPannel.SetActive(false);
        PlayerScript.gameEnd = false;
    }
    
}
