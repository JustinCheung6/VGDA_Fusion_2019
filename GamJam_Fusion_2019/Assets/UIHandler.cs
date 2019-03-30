using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHandler : MonoBehaviour
{
    public Text ScoreText;
    private void OnEnable()
    {
        ScoreText.text = Score.score.ToString();
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ToMainMenu()
    {
        SceneManager.LoadScene(2);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
