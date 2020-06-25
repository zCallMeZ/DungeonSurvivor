using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public float curHealth = 100.0f;
    private float takeHealth = 10.0f;

    [SerializeField] private float takeDmg = 5.0f;

    [SerializeField] private TextMeshProUGUI healthText;
    [SerializeField] private Transform respawn;

    private void Update()
    {
        healthText.text = curHealth.ToString("F0");

        if (curHealth <= 0)
        {
            curHealth = 0f;
        }
    }

    private void TakeDmg()
    {
        curHealth -= takeDmg;
    }

    private void TakeHealth()
    {
        curHealth -= takeHealth;
    }


    private void OnCollisionEnter2D(Collision2D collision)
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
