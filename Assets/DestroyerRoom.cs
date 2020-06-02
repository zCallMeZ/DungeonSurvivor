using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyerRoom : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ground") && !collision.transform.IsChildOf(transform))
        {
            Destroy(gameObject);
        }
    }
}
