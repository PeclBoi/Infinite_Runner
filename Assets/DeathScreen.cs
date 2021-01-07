using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DeathScreen : MonoBehaviour
{
    public GameObject DeathScreenCanvas;

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        PlayerDeath.playerDead = false;
        DeathScreenCanvas.SetActive(false);
        SceneManager.LoadScene("Menu");
    }

    public void QuitGame()
    {
        Debug.Log("Quit.");
        Application.Quit();
    }
}
