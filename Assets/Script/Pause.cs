using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    public  GameObject Pausemenu;
    
    bool isPaused = false;
    // Start is called before the first frame update
    void Start()
    {
        Pausemenu.SetActive(false);
    }
    public void pauseGame()
    {
        Pausemenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void resumeGame()
    {
        Pausemenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

}
