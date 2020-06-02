using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ZombieHealthAndScore : MonoBehaviour
{
    float healthMax = 15;
    float curHealth = 15;
    float takeDmg = 5;

    float score = 10;
    float curScore = 0;

    [SerializeField] TextMeshProUGUI scoreText;
    private void Start()
    {
        curHealth = healthMax;
    }
    void Update()
    {
        scoreText.text = curScore.ToString("F0");

        if (curHealth <= 0)
        {
            curHealth = 0f;
            Destroy(gameObject);
        }
    }

    void TakeDmg()
    { 
        curHealth -= takeDmg;
        curScore += score;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("bullet")) //TODO(@Bryan) Use more modern function collision.gameobject.CompareTage("zombie1")
        {
            TakeDmg();
        }

    }

}


