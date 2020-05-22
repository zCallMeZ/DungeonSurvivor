using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject panelMenu;
    [SerializeField] private GameObject panelCredits;
    [SerializeField] private GameObject panelPause;

    private const int activatePanel = 0;
    private const int desactivatePanel = 1;

    void Update() //TODO(@Solange) Remove this function if it's not used. Because this function will still be called every frame.
    {
        //if (Input.GetButtonDown("Pause"))
        //{
        //    ActivatePanelPause();
        //}
    }

    public void ActivatePanelCredits()
    {
        panelCredits.gameObject.SetActive(true);
        Time.timeScale = activatePanel;
    }

    public void DesactivatePanelCredits()
    {
        panelCredits.gameObject.SetActive(false);
        Time.timeScale = desactivatePanel; 
    }

    public void ActivatePanelPause()
    {
        panelPause.gameObject.SetActive(true);
        Time.timeScale = activatePanel;
    }

    public void DesactivatePanelPause()
    {
        panelPause.gameObject.SetActive(false);
        Time.timeScale = desactivatePanel;
    }

    public void ActivatePanelMenu()
    {
        panelMenu.gameObject.SetActive(true);
        Time.timeScale = activatePanel;
    }

    public void DesactivatePanelMenu()
    {
        panelMenu.gameObject.SetActive(false);
        Time.timeScale = desactivatePanel;
    }
}
