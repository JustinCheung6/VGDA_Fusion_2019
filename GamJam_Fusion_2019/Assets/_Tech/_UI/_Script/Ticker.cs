using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Ticker : MonoBehaviour
{
    public Image currentTicker;
    public Text ratioText;

    private float timeLeft = 0;
    private float maxTime = 10;

    //eat my candy ass

    private void Start()
    {
        currentTicker = GetComponent<Image>();
    }

    private void OnEnable()
    {
        UpdateHandler.UpdateOccurred += UpdateRemainingTime;
    }

    private void OnDisable()
    {
        UpdateHandler.UpdateOccurred -= UpdateRemainingTime;
    }

    private void UpdateRemainingTime()
    {
        if (timeLeft < maxTime)
        {
            incrementTicker(Time.deltaTime);
        }
        else
        {
            Time.timeScale = 0;
        }
    }
    private void updateTicker()
    {
        float ratio = timeLeft / maxTime;
        currentTicker.rectTransform.localScale = new Vector3(ratio, 1, 1);
        ratioText.text = (ratio*100).ToString("0") + '%';
    }

    private void incrementTicker(float value)
    {
        timeLeft += value;
        if (timeLeft > maxTime)
        {
            timeLeft = maxTime;
        }
        updateTicker();
    }

    private void decrementTicker(float value)
    {
        timeLeft -= value;
        if (timeLeft < 0)
        {
            timeLeft = 0;
            Debug.Log("dead");
        }
        updateTicker();
    }
}
