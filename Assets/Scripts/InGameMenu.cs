using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public GameObject menuPanel;
    bool menuActive = false;

    private void Start()
    {
        menuPanel.SetActive(false);
    }

    public void PauseButton()
    {
        menuActive = !menuActive;
        menuPanel.SetActive(menuActive);
        Time.timeScale = menuActive ? 0 : 1;
    }

    public void HomeButton()
    {
        SceneManager.LoadScene(0);
    }
}
