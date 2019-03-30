using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public KeyCode pauseKey;
    private bool paused = false;
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void OnEnable()
    {
        UpdateHandler.UpdateOccurred += checkPauseMenu;
        Debug.Log("We are enabled!");
    }
    void OnDisable()
    {
        UpdateHandler.UpdateOccurred -= checkPauseMenu;
        Debug.Log("We are disabled!");
    }

    // Update is called once per frame
    void checkPauseMenu()
    {
        if (Time.timeScale == 1f)
        {
            if(Input.GetKeyDown(pauseKey))
            {
                pause();
            }
        }
        else
        {
            if (Input.GetKeyDown(pauseKey))
            {
                resume();
            }
        }
        
    }
    private void resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        paused = false;
    }
    private void pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        paused = true;
    }
}
