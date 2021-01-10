using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    bool running = false;
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            Debug.Log("Main Sound on");
            GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().Play();
            running = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("sound") == 1 && running == false)
        {
            Debug.Log("Main Sound on");
            GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().Play();
        }
        else if (PlayerPrefs.GetInt("sound") == 0)
        {
            
            GameObject.Find("BackgroundMusic").GetComponent<AudioSource>().Stop();
            running = false;
        }
    }
}
