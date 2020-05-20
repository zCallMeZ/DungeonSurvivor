using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject panelMenu;
    [SerializeField] private GameObject panelCredits;
    [SerializeField] private GameObject panelPause;

    void Update()
    {
        //if (Input.GetButtonDown("Pause"))
        //{
        //    ActivatePanelPause();
        //}
    }

    public void ActivatePanelCredits()
    {
        panelCredits.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void DesactivatePanelCredits()
    {
        panelCredits.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void ActivatePanelPause()
    {
        panelPause.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void DesactivatePanelPause()
    {
        panelPause.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void ActivatePanelMenu()
    {
        panelMenu.gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void DesactivatePanelMenu()
    {
        panelMenu.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
