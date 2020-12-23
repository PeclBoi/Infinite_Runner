using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Transform coursePart_1;

    private void Awake()
    {
        SpawnLevelPart(new Vector3(5, -5));
        SpawnLevelPart(new Vector3(5, -5) + new Vector3(20, 0));
        SpawnLevelPart(new Vector3(5, -5) + new Vector3(20 + 20, 0));
    }

    private void SpawnLevelPart(Vector3 spawnPosition)
    {
        Instantiate(coursePart_1, spawnPosition, Quaternion.identity);
    }
}
