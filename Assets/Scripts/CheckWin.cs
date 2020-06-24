using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWin : MonoBehaviour
{
    private bool isOpen = false;
    private bool canWin = false;

    [SerializeField] private GameObject panelWin;

    private void Update()
    {
        if (canWin)
        {
            panelWin.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("chest"))
        {
            isOpen = true;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(isOpen)
        {
            if (collision.gameObject.CompareTag("chest")) 
            {
                canWin = true;
            }
        }
    }
}
