using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forwardSpeed = 5f;
    public float horizontalSpeed = 5f;

    void Update()
    {
        transform.Translate(Vector3.forward * forwardSpeed * Time.deltaTime);
        float h = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * h * horizontalSpeed * Time.deltaTime);
    }
}