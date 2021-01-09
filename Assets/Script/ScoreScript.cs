using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static float scoreValue = 0;
    private float secTillPoint = 0.5f;
    private float deltaTimeCounter = 0;
    Text score;
    Pause pause;


    void Start()
    {
        score = GetComponent<Text>();
        scoreValue = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (Pause.isPaused != true && PlayerDeath.playerDead != true)
        {
            deltaTimeCounter += Time.deltaTime;
            if (deltaTimeCounter >= secTillPoint)
            {
                deltaTimeCounter = 0;
                score.text = "Score:" + scoreValue;
                scoreValue += 1;
            }
        }

        if(scoreValue > GetTimeValue(3, secTillPoint))
        {
            Movement.SetDifficulty(1.3f);
        }
        else if(scoreValue > GetTimeValue(2, secTillPoint))
        {
            Movement.SetDifficulty(1.2f);
        }
        else if (scoreValue > GetTimeValue(1, secTillPoint))
        {
            Movement.SetDifficulty(1.1f);
        }

    }

    private float GetTimeValue(float min, float timeScale)
    {
        return (min * 60) / timeScale;
    }
}
