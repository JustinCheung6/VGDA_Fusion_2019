using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    private AudioSource bsm;

    private void Start()
    {
        bsm = GetComponent<AudioSource>();
    }

    public void quitGame()
    {
        Debug.Log("Talk to me");
        bsm.Play();
        Application.Quit();
    }
    public void playGame()
    {
        Debug.Log("Talk to me");
        bsm.Play();
    }
}
