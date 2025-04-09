using UnityEngine;

public class DecorGenerator : MonoBehaviour
{
    public GameObject[] decorPrefabs;
    public float distanceFromPath = 5f;

    public void GenerateDecorAtZ(float zPos)
    {
        Vector3 leftPos = new Vector3(-distanceFromPath, 0, zPos);
        Vector3 rightPos = new Vector3(distanceFromPath, 0, zPos);

        SpawnRandomDecor(leftPos);
        SpawnRandomDecor(rightPos);
    }

    void SpawnRandomDecor(Vector3 position)
    {
        GameObject prefab = decorPrefabs[Random.Range(0, decorPrefabs.Length)];
        Quaternion randomRot = Quaternion.Euler(0, Random.Range(0, 360), 0);
        Instantiate(prefab, position, randomRot, this.transform);
    }
}
