using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject platformPrefab;
    public int numberOfPlatforms = 5;
    public float platformLength = 30f;
    public Transform player;

    private float spawnZ = 0f;
    private float safeZone = 45f;
    private List<GameObject> activePlatforms = new List<GameObject>();

    void Start()
    {
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            SpawnPlatform();
        }
    }

    void Update()
    {
        if (player.position.z - safeZone > spawnZ - (numberOfPlatforms * platformLength))
        {
            SpawnPlatform();
            DeletePlatform();
        }
    }

    void SpawnPlatform()
    {
        GameObject go = Instantiate(platformPrefab, Vector3.forward * spawnZ, Quaternion.identity);
        activePlatforms.Add(go);
        spawnZ += platformLength;
    }

    void DeletePlatform()
    {
        Destroy(activePlatforms[0]);
        activePlatforms.RemoveAt(0);
    }
}
