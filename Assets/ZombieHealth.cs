using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ZombieHealth : MonoBehaviour
{
    float healthMax = 15;
    float curHealth = 15;
    float takeDmg = 5;

    private void Start()
    {
        curHealth = healthMax;
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


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) //TODO(@Bryan) Use more modern function collision.gameobject.CompareTage("zombie1")
        {
            TakeDmg();
        }
    }
}


