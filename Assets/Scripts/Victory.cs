using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Victory : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;

    private void OnEnable() {
        this.audioSource.PlayOneShot(this.audioClip);
    }
    
    public void finish()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    public void playAgain()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }
}
