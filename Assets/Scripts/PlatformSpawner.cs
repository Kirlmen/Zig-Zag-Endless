using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] GameObject platformPrefab;
    [SerializeField] Transform lastPlatformPiece;
    Vector3 lastPosition;
    Vector3 newPosition;
    private float spawnTimer;
    void Start()
    {
        lastPosition = lastPlatformPiece.position; //last position referansı
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isStarted)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer < 0)
            {
                spawnTimer = 0.2f;
                SpawnPlatform();
            }
        }
    }

    void SpawnPlatform()
    {
        GeneratePosition();
        Instantiate(platformPrefab, newPosition, Quaternion.identity);
    }

    void GeneratePosition()
    {
        newPosition = lastPosition;
        int random = Random.Range(0, 2);
        if (random > 0)
        {
            newPosition.x += 2f;
        }
        else
        {
            newPosition.z += 2f;
        }
        lastPosition = newPosition;


    }
}
