using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO Mettre des commentaires + Enlever les using non utilisés

public class ZombieHealth : MonoBehaviour
{
    [SerializeField] private float curHealth = 3.0f;
    private float healthMax;
    private float takeDmg = 1.0f;

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


