using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private float score;
    public Text scoreBox;

    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreBox.text = "Score: " + score.ToString() +"\n";
    }

    public void playerScored(float points) {
        score += points;
    }
}
