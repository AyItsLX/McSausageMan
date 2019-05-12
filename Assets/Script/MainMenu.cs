using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject PausePanel;
    public GameObject ReadyMenu;
    public GameObject PauseMenu;

    public static bool isReadying = false;
    public static bool isPaused = false;

    void Start ()
    {
        if (SceneManager.GetActiveScene().name == "GraphicMode" || SceneManager.GetActiveScene().name == "PrototypeMode")
        {
            isReadying = false;
            isPaused = false;
            ReadyMenu.SetActive(true);
            Time.timeScale = 1;
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "GraphicMode" || SceneManager.GetActiveScene().name == "PrototypeMode")
        {
            if (!isReadying && Input.GetKeyDown(KeyCode.Space))
            {
                isReadying = true;
                PausePanel.SetActive(true);
                ReadyMenu.SetActive(false);
            }

            if (isReadying && !GameOverScript.isDead &&!isPaused && Input.GetKeyDown(KeyCode.Escape))
            {
                PauseMenu.SetActive(true);
                isPaused = true;
                Time.timeScale = 0;
            }
            else if (isReadying && !GameOverScript.isDead && isPaused && Input.GetKeyDown(KeyCode.Escape))
            {
                PauseMenu.SetActive(false);
                isPaused = false;
                Time.timeScale = 1;
            }
        }
    }

    public void PrototypeMode()
    {
        SceneManager.LoadScene("PrototypeMode");
    }
    public void GraphicMode()
    {
        SceneManager.LoadScene("GraphicMode");
    }

    public void OnReturnPressed()
    {
        SceneManager.LoadScene("Intro");
        GameOverScript.isDead = false;
        Victory.isVictory = false;
        isReadying = false;
        isPaused = false;
    }

    public void OnQuitPressed()
    {
        Application.Quit();
    }
}
