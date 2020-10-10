using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void play()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
    public void credits()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Créditos");
    }
    public void quit()
    {
        Application.Quit();
    }
}
