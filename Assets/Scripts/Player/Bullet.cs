using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float time = 3.0f;

    private void Start()
    {
        Destroy(gameObject, time);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
