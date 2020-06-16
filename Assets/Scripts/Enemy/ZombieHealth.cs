using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieHealth : MonoBehaviour
{
    private float healthMax;
    [SerializeField] private float curHealth = 3f;
    private float takeDmg = 1f;
    private bool isDead = false;

    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        healthMax = curHealth;
    }

    private void Update()
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


