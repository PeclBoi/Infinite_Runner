using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using System;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] int offsetX;
    [SerializeField] int offsetY;
    [SerializeField] bool followY = true;
    Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();

        if(scene.name == "Game")
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform != null)
        {
            Follow();
        }

    }

    private void Follow()
    {
            Vector3 temp = transform.position;
            temp.x = playerTransform.position.x - offsetX;
            if (followY) { temp.y = playerTransform.position.y - offsetY; }
            transform.position = temp;
    }
}
