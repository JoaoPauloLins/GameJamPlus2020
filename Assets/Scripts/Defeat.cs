using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defeat : MonoBehaviour
{
    public void tryAgain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
