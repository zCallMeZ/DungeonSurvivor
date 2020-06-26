using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject panelMenu;
    [SerializeField] private GameObject panelCredits;
    [SerializeField] private GameObject panelPause;
    [SerializeField] private GameObject panelControls;

    [SerializeField] private GameObject panelWin;
    [SerializeField] private GameObject panelGameOver;

    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private CheckWin checkWin;

    private const int activatePanel = 0;
    private const int desactivatePanel = 1;

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        checkWin = FindObjectOfType<CheckWin>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
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

        bool isWin = checkWin.GetIsWin();

        if (isWin)
        {
            panelWin.gameObject.SetActive(true);
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

    public void ActivatePanelWin()
    {
        panelWin.gameObject.SetActive(true);
        Time.timeScale = activatePanel;
    }

    public void DesactivatePanelWin()
    {
        panelWin.gameObject.SetActive(false);
        Time.timeScale = desactivatePanel;
    }

    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }

    public void ActivatePanelControls()
    {
        panelControls.gameObject.SetActive(true);
        Time.timeScale = activatePanel;
    }

    public void DesactivatePanelControls()
    {
        panelControls.gameObject.SetActive(false);
        Time.timeScale = desactivatePanel;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
