using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Minmenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(3);
    }
    public void CreditsGame()
    {
        SceneManager.LoadScene(1);
    }

    public void LeaveGame()
    {
        Application.Quit();
    }
}
