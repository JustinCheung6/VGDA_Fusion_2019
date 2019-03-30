using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public KeyCode pauseKey;
    private bool paused = false;
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void onEnabled()
    {
        UpdateHandler.UpdateOccurred += checkPauseMenu;
    }
    void onDisabled()
    {
        UpdateHandler.UpdateOccurred -= checkPauseMenu;
    }

    // Update is called once per frame
    void checkPauseMenu()
    {
        if (Input.GetKey(pauseKey))
        {
            if(paused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }
    private void resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
    }
    private void pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }
}
