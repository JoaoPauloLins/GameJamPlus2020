using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    public void finish()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    public void playAgain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
