using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static float scoreValue = 0;
    Text score;
    Pause pause;
    

    void Start()
    {
        score = GetComponent<Text> ();
        scoreValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Pause.isPaused != true && PlayerDeath.playerDead != true)
        {
            score.text = "Score:" + scoreValue;
            scoreValue = scoreValue + 1;
        }
        
    }
}
