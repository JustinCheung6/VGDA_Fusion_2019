using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
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
    }
    void OnDisable()
    {
        UpdateHandler.UpdateOccurred -= checkPauseMenu;
    }

    // Update is called once per frame
    void checkPauseMenu()
    {
        if (Input.GetKeyDown(pauseKey))
        {
            if (paused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }
    public void resume()
    {
        Time.timeScale = 1f;
        pauseMenu.SetActive(false);
        paused = false;
    }
    public void pause()
    {
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
        paused = true;
    }
    public void quitGame()
    {
        Application.Quit();
    }
}
