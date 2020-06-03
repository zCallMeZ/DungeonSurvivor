using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    float healthMax;
    [SerializeField] float curHealth = 3f;
    float takeDmg = 1f;

    private void Start()
    {
        healthMax = curHealth;
    }

    void Update()
    {

        if (curHealth <= 0)
        {
            curHealth = 0f;
            Destroy(gameObject);
        }
    }

    void TakeDmg()
    { 
        curHealth -= takeDmg;
    }


<<<<<<< HEAD:Assets/ZombieHealth.cs
    void OnCollisionEnter2D(Collision2D other)
=======
    void OnCollisionEnter2D(Collision2D collision)
>>>>>>> master:Assets/Scripts/Enemy/ZombieHealth.cs
    {
        if (collision.gameObject.CompareTag("Bullet")) //TODO(@Bryan) Use more modern function collision.gameobject.CompareTage("zombie1")
        {
            TakeDmg();
        }
    }
}


