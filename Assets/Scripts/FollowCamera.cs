using UnityEngine;

public class CameraFollowRotation : MonoBehaviour
{
    public Transform cameraTransform;

    void Update()
    {
        Vector3 direction = cameraTransform.forward;
        direction.y = 0;
        if (direction.magnitude > 0.1f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), Time.deltaTime * 5f);
        }
    }
}
