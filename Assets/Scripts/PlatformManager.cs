using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject platformPrefab;
    public int numberOfPlatforms = 5;
    public float platformLength = 30f;
    public Transform player;
    public GameObject[] obstaclePrefabs;
    public GameObject collectiblePrefab;
    public int obstaclesPerPlatform = 2;
    public int collectiblesPerPlatform = 1;
    public DecorGenerator decorGenerator;

    private float spawnZ = 0f;
    private float safeZone = 45f;
    private List<GameObject> activePlatforms = new List<GameObject>();

    void Start()
    {
        // Spawn initial platforms
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            SpawnPlatform();
        }
    }

    void Update()
    {
        // Check if it's time to spawn a new platform
        if (player.position.z - safeZone > spawnZ - (numberOfPlatforms * platformLength))
        {
            SpawnPlatform();
            DeletePlatform();
        }
    }

    void SpawnPlatform()
    {
        Vector3 spawnPosition = Vector3.forward * spawnZ;
        GameObject platform = Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        activePlatforms.Add(platform);

        // Spawn obstacles on the platform
        for (int i = 0; i < obstaclesPerPlatform; i++)
        {
            SpawnObstacle(platform.transform, spawnPosition);
        }

        // Spawn collectibles on the platform
        for (int i = 0; i < collectiblesPerPlatform; i++)
        {
            SpawnCollectible(platform.transform, spawnPosition);
        }

        spawnZ += platformLength;

        // Generate decor in front of this platform
        if (decorGenerator != null)
        {
            float middleZ = spawnZ - (platformLength / 2f);
            decorGenerator.GenerateDecorAtZ(middleZ);
        }


    }

    void SpawnObstacle(Transform parent, Vector3 platformPos)
    {
        int lane = Random.Range(-1, 2); // -1, 0, 1
        float zOffset = Random.Range(5f, platformLength - 5f);
        Vector3 position = platformPos + new Vector3(lane * 2f, 0.5f, zOffset);
        int index = Random.Range(0, obstaclePrefabs.Length);
        Instantiate(obstaclePrefabs[index], position, Quaternion.identity);
    }

    void SpawnCollectible(Transform parent, Vector3 platformPos)
    {
        int lane = Random.Range(-1, 2); // -1, 0, 1
        float zOffset = Random.Range(5f, platformLength - 5f);
        Vector3 position = platformPos + new Vector3(lane * 2f, 1f, zOffset);
        Instantiate(collectiblePrefab, position, Quaternion.identity);
    }

    void DeletePlatform()
    {
        // Remove the oldest platform
        Destroy(activePlatforms[0]);
        activePlatforms.RemoveAt(0);
    }
}
