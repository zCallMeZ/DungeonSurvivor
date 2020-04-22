using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    float totalHealth = 100f;
    float highDmg = 5f;
    float normalDmg = 5f;
    float lowDmg = 5f;
    float health = 10f;

    Score score;
    //[SerializeField] private TextMeshProUGUI healthText;

    private void Start()
    {
        totalHealth = 100f;
    }
    private void Update()
    {
        //healthText.text = totalHealth.ToString("F0");

        if (totalHealth <= 0f)
        {
            totalHealth = 0f;
        }
    }

    void TakeHighDmg()
    {
        health -= highDmg;
    }

    void TakeNormalDmg()
    {
        health -= normalDmg;
    }

    void TakeLowDmg()
    {
        health -= lowDmg;
    }

    private void TakeHealth()
    {
        totalHealth += health;

        if (totalHealth >= 100f)
        {
            totalHealth = 100f;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "zombie1")
        {
            TakeLowDmg();
            score.GetLowPoint();
        }
        if (collision.gameObject.tag == "zombie2")
        {
            TakeNormalDmg();
            score.GetNormalPoint();
        }
        if (collision.gameObject.tag == "zombie3")
        {
            TakeHighDmg();
            score.GetHighPoint();
        }
        if (collision.gameObject.tag == "health")
        {
            TakeHealth();
        }
    }
}
