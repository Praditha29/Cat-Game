using UnityEngine;
using System.Collections.Generic;

public class FishSpawner : MonoBehaviour
{
    public GameObject fishPrefab;

    public Transform spawnAreaMin;
    public Transform spawnAreaMax;

    public int minFish = 1;
    public int maxFish = 10;

    public float minimumDistance = 1.5f;

    private List<Vector3> fishPositions = new List<Vector3>();

    void Start()
    {
        SpawnFishes();
    }

    public void SpawnFishes()
    {
        fishPositions.Clear();

        int fishCount = Random.Range(minFish, maxFish + 1);

        Debug.Log("Fish spawned: " + fishCount);

        for (int i = 0; i < fishCount; i++)
        {
            SpawnFish();
        }
    }

    void SpawnFish()
    {
        Vector3 spawnPosition;
        int attempts = 0;

        do
        {
            float randomX = Random.Range(
                spawnAreaMin.position.x,
                spawnAreaMax.position.x
            );

            float randomY = Random.Range(
                spawnAreaMin.position.y,
                spawnAreaMax.position.y
            );

            spawnPosition = new Vector3(randomX, randomY, 0);

            attempts++;

        } while (!IsPositionValid(spawnPosition) && attempts < 50);

        fishPositions.Add(spawnPosition);

        Instantiate(
            fishPrefab,
            spawnPosition,
            Quaternion.identity
        );
    }

    bool IsPositionValid(Vector3 position)
    {
        foreach (Vector3 existingPosition in fishPositions)
        {
            if (Vector3.Distance(position, existingPosition) < minimumDistance)
            {
                return false;
            }
        }

        return true;
    }
}