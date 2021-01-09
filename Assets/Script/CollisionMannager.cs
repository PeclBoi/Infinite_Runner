using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;
public class CollisionMannager : MonoBehaviour 
{
    public static bool playerDead = false;
    public GameObject DeathScreenCanvas;
    public TextMeshProUGUI Text;
    public GameObject ScoreText;
    public GameObject JumpButton;
    public GameObject SlideButton;
    public GameObject PauseButton;
    [SerializeField] private LayerMask layerMask;

    public bool isOnGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.4f, layerMask);
        return hit.collider != null;
    }
    void Update()
    {
        Vector2 worldpos = gameObject.transform.position;
        if (worldpos.y == -10)
        {
            DeathScreenCanvas.SetActive(true);
            JumpButton.SetActive(false);
            ScoreText.SetActive(false);
            SlideButton.SetActive(false);
            PauseButton.SetActive(false);
            Time.timeScale = 0f;
            playerDead = true;
            Text.text += ScoreScript.scoreValue;
            Scoreboard.AddHighscoreEntry(Convert.ToInt32(ScoreScript.scoreValue));
        }
    }
}
