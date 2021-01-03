using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform initPart;
    [SerializeField] private Transform[] courseParts;
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
        //TODO Delete older Parts
        if (Vector3.Distance(player.transform.position, lastEndPosition) < PLAYER_DISTANCE_SPAWN_LEVEL_PART)
        {
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
        Transform levelPartTransform = Instantiate(courseParts[Random.Range(0, courseParts.Length)], spawnPosition, Quaternion.identity);
        Destroy(levelPartTransform.gameObject, 20);
        return levelPartTransform;
    }
}
