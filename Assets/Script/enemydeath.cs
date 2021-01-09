using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class enemydeath : MonoBehaviour
{
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnCollisiontEnter2D(Collision other)
    {
          if(other.gameObject.tag == "Projectile")
        {
            ScoreScript.scoreValue += 1000000;
            Debug.Log("hit");
            Destroy(enemy);
        }
    }
}
