using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{
    public void StartGame(string lvlName)
    {
        Application.LoadLevel(lvlName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ShowCredits(GameObject creditsObj)
    {
        if (!creditsObj.activeSelf)
            creditsObj.SetActive(true);
        else
            creditsObj.SetActive(false);
    }
}
