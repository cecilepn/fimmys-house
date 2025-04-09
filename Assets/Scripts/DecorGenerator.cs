using UnityEngine;

public class DecorGenerator : MonoBehaviour
{
    public GameObject[] decorPrefabs;
    public float distanceFromPath = 5f;

    public void GenerateDecorAtZ(float zPos)
    {
        if (decorPrefabs.Length == 0) return;

        Vector3 leftPos = new Vector3(-distanceFromPath, 0, zPos);
        Vector3 rightPos = new Vector3(distanceFromPath, 0, zPos);

        SpawnDecor(leftPos);
        SpawnDecor(rightPos);
    }

    void SpawnDecor(Vector3 position)
    {
        GameObject prefab = decorPrefabs[0];
        Instantiate(prefab, position, Quaternion.identity, this.transform);
    }
}
