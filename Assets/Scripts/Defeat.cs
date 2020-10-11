using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defeat : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    private void OnEnable() {
        this.audioSource.PlayOneShot(this.audioClip);
    }

    public void tryAgain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void home()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}
