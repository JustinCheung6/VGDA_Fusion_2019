using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Ticker : MonoBehaviour
{
    public delegate void OnDeath();

    public static event OnDeath OnDeathEvent ;
    
    public Image currentTicker;
    public Text ratioText;

    private float timeLeft = 0;
    [SerializeField]
    private float maxTime = 10f;

    //eat my candy ass

    private void Start()
    {
        currentTicker = GetComponent<Image>();
        Debug.Log("Showing Console info");
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
            if (OnDeathEvent != null)
            {
                OnDeathEvent();
                Debug.Log("Event Triggered");

            }
            //Time.timeScale = 0;
        }
    }
    private void updateTicker()
    {
        float ratio = timeLeft / maxTime;
        currentTicker.rectTransform.localScale = new Vector3(ratio, 1, 1);
        ratioText.text = (ratio*100).ToString("0") + '%';
    }

    public void incrementTicker(float value)
    {
        timeLeft += value;
        if (timeLeft > maxTime)
        {
            timeLeft = maxTime;
        }
        updateTicker();
    }

    public void decrementTicker(float value)
    {
        timeLeft -= value;
        if (timeLeft < 0)
        {
            timeLeft = 0;
            Debug.Log("dead");
            if (OnDeathEvent != null)
            {
                OnDeathEvent();
                Debug.Log("Event Triggered");

            }
            
                
        }
        updateTicker();
    }
}
