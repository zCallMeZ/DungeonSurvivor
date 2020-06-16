using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public float curHealth = 100;
    private float takeHealth = 10;
    [SerializeField] private float takeDmg = 5;

    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Transform respawn;

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
        if (collision.gameObject.CompareTag("Zombie1"))
        {
            TakeDmg();
        }
        if (collision.gameObject.CompareTag("Zombie2"))
        {
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
        if (collision.gameObject.CompareTag("health"))
        {
            TakeHealth();
        }
    }
    public float GetPlayerLife()
    {
        return curHealth;
    }

}
