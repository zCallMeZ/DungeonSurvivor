using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject panelMenu;
    [SerializeField] private GameObject panelCredits;
    [SerializeField] private GameObject panelPause;

    [SerializeField] private GameObject panelGameOver;
    [SerializeField] private PlayerHealth playerHealth;

    private const int activatePanel = 0;
    private const int desactivatePanel = 1;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (panelPause.activeSelf)
            {
                DesactivatePanelPause();
            }
            else
            {
                ActivatePanelPause();
            }
        }

        float playerDeath = playerHealth.GetPlayerLife();

        if (playerDeath <= 0.0f)
        {
            panelGameOver.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
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

    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
