using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    private float healthMax;
    [SerializeField] private float curHealth = 3f;
    private float takeDmg = 1f;

    private void Start()
    {
        healthMax = curHealth;
    }

    public bool IsAlive()
    {
        return curHealth > 0;
    }

    private void TakeDmg()
    { 
        curHealth -= takeDmg;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDmg();
        }
    }
}


