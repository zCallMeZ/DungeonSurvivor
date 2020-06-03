using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Security.Cryptography;

public class PlayerHealth1 : MonoBehaviour
{
    float healthMax = 100;
    float curHealth = 100;
    float takeDmg = 5;
    float takeHealth = 10;

    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] Transform respawn;

    private void Start()
    {
        curHealth = healthMax;
    }
    void Update()
    {
        healthText.text = curHealth.ToString("F0");

        if (curHealth <= 0)
        {
            curHealth = 0f;
        }
    }

    void TakeDmg()
    {
        curHealth -= takeDmg;
    }

    void TakeHealth()
    {
        curHealth -= takeHealth;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Zombie1")) //TODO(@Bryan) Use more modern function collision.gameobject.CompareTage("zombie1")
        {
            TakeDmg();
        }
        if (collision.gameObject.CompareTag("Zombie2"))
        {
            TakeDmg();
            TakeDmg();
            TakeDmg();
        }
        if (collision.gameObject.CompareTag("Zombie3"))
        {
            TakeDmg();
            transform.position = respawn.transform.position;
        }
        if (collision.gameObject.CompareTag("Zombie4"))
        {
            TakeDmg();
        }
        //if (collision.gameObject.CompareTag("health"))
        //{
        //    TakeHealth();
        //}
    }

}
