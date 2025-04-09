using UnityEngine;

public class Obstacle : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.HitObstacle();
        }
    }
}
