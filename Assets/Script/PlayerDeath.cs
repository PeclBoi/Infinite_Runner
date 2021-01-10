using System.Collections;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class PlayerDeath : MonoBehaviour
{
    [SerializeField] AudioClip deathSound;
    public static bool playerDead = false;
    public GameObject DeathScreenCanvas;
    public TextMeshProUGUI Score;
    public GameObject ScoreText;
    public GameObject JumpButton;
    public GameObject SlideButton;
    public GameObject PauseButton;
    public GameObject runner;
    private bool state = false;
    
    public void Start()
    {
        DeathScreenCanvas.SetActive(false);
        Debug.Log("Start PlayerDeath");
    }
    public void Update()
    {
        
        runner = GameObject.Find("Runner");
        Vector2 worldpos = runner.transform.position;
        if (worldpos.y < -15 && state== false && playerDead != true)
        {
            Debug.Log(worldpos);
            DeathScreenCanvas.SetActive(true);
            JumpButton.SetActive(false);
            ScoreText.SetActive(false);
            SlideButton.SetActive(false);
            PauseButton.SetActive(false);
            Time.timeScale = 0f;
            playerDead = true;
            Score.text += ScoreScript.scoreValue;
            Scoreboard.AddHighscoreEntry(Convert.ToInt32(ScoreScript.scoreValue));
            state = true;
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Trigger " + collider.gameObject.name + ";" + collider.gameObject.tag);
        if (collider.gameObject.tag != "Projectile" && playerDead != true)   
        {
            if (PlayerPrefs.GetInt("sound") == 1)
            {
                GameObject.Find("Sound").GetComponent<AudioSource>().PlayOneShot(deathSound);
            }
            DeathScreenCanvas.SetActive(true);
            JumpButton.SetActive(false);
            ScoreText.SetActive(false);
            SlideButton.SetActive(false);
            PauseButton.SetActive(false);
            Time.timeScale = 0f;
            playerDead = true;
            Score.text += ScoreScript.scoreValue;
            Scoreboard.AddHighscoreEntry(Convert.ToInt32(ScoreScript.scoreValue));
        }
    }
    
}
