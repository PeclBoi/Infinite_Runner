using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDeath : MonoBehaviour
{
    public static bool playerDead = false;
    public GameObject DeathScreenCanvas;
    public TextMeshProUGUI Text;
    public GameObject ScoreText;
    public GameObject JumpButton;
    public GameObject SlideButton;
    public GameObject PauseButton;


    public void Start()
    {
        DeathScreenCanvas.SetActive(false);
        Debug.Log("Start PlayerDeath");
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("Trigger " + collider.gameObject.name + ";" + collider.gameObject.tag);
        if (collider.gameObject.tag != "Projectile")
        {
            DeathScreenCanvas.SetActive(true);
            JumpButton.SetActive(false);
            ScoreText.SetActive(false);
            SlideButton.SetActive(false);
            PauseButton.SetActive(false);
            Time.timeScale = 0f;
            playerDead = true;
            Text.text += ScoreScript.scoreValue;
        }
    }
}
