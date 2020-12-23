using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform initPart;
    [SerializeField] private Transform coursePart_1;
    //[SerializeField] private GameObject player;

    private const float PLAYER_DISTANCE_SPAWN_LEVEL_PART = 100f;
    private Vector3 lastEndPosition;

    private void Awake()
    {
        lastEndPosition = initPart.Find("EndPosition").position;
        SpawnLevelPart();
    }

    private void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        print(Vector3.Distance(player.transform.position, lastEndPosition));
        print(player.transform.position);
        if(Vector3.Distance(player.transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
            //spawn another Level Part
            SpawnLevelPart();
            SpawnLevelPart();
            SpawnLevelPart();
        }
    }

    private void SpawnLevelPart()
    {
        Transform lastLevelPartTransform = SpawnLevelPart(lastEndPosition);
        lastEndPosition = lastLevelPartTransform.Find("EndPosition").position;
    }
    private Transform SpawnLevelPart(Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(coursePart_1, spawnPosition, Quaternion.identity);
        print(levelPartTransform);
        return levelPartTransform;
    }
}
