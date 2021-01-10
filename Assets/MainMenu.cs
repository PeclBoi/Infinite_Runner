using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI Text;
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Start()
    {
        int sound = PlayerPrefs.GetInt("sound");
        if (sound == 1)
        {
            Text.text = "SOUND ON";
        }
        else 
        {
            Text.text = "SOUND OFF";
        }
    }

    public void ChangeSound()
    {
        int sound = PlayerPrefs.GetInt("sound");
        if(sound == 1)
        {
            Debug.Log("sound off");
            PlayerPrefs.SetInt("sound", 0);
            Text.text = "SOUND OFF";
        }
        else
        {
            Debug.Log("sound on");
            PlayerPrefs.SetInt("sound", 1);
            Text.text = "SOUND ON";
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
