using UnityEngine;

public class FishSpawner : MonoBehaviour
{
    public GameObject fishPrefab;
    public Transform[] spawnPoints;

    public float minSpawnTime = 1f;
    public float maxSpawnTime = 3f;

    void Start()
    {
        Invoke(nameof(SpawnFish), Random.Range(minSpawnTime, maxSpawnTime));
    }

    void SpawnFish()
    {
        // Pick a random spawn point
        int index = Random.Range(0, spawnPoints.Length);

        // Spawn the fish
        Instantiate(fishPrefab, spawnPoints[index].position, Quaternion.identity);

        // Schedule the next fish
        Invoke(nameof(SpawnFish), Random.Range(minSpawnTime, maxSpawnTime));
    }
}