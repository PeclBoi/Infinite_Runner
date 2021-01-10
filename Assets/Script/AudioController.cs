using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    // [SerializeField] AudioClip running;
    // Start is called before the first frame update
    bool running = false;
    void Start()
    {
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            Debug.Log("Main Sound on");
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
            running = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (PlayerPrefs.GetInt("sound") == 1)
        {
            Debug.Log("Main Sound on");
            audioSource = GetComponent<AudioSource>();
            audioSource.Play();
        }
        else if (PlayerPrefs.GetInt("sound") == 0)
        {
            Debug.Log("Main Sound off");
            audioSource = GetComponent<AudioSource>();
            audioSource.Stop();
        }
    }
}
