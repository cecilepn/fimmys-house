using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0f, 5f, -10f);

    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = player.position + offset;
        }
    }
}
