using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    float healthMax;
    [SerializeField] float curHealth = 3f;
    float takeDmg = 1f;
    bool isDead = false;

    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        healthMax = curHealth;
    }

    void Update()
    {
        if (curHealth <= 0)
        {
            curHealth = 0f;
            isDead = true;
           
        }
        if (isDead)
        {
            animator.SetBool("isDead", true);
            Destroy(this);
            Destroy (gameObject, 1.0f);
        }
    }

    void TakeDmg()
    { 
        curHealth -= takeDmg;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            TakeDmg();
        }
    }
}


