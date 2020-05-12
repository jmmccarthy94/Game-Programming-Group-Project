using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject deathMenuUI;
    public GameObject introPage;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !introPage.activeInHierarchy && !deathMenuUI.activeInHierarchy)
        {
            Debug.Log("Pausing Game");
            if(GameIsPaused)
            {
                Resume();
            }else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading menu");
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void reloadLvl1()
    {
        Debug.Log("Reload level");
        //deathMenuUI.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void death()
    {
        deathMenuUI.SetActive(true);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game");
        #if UNITY_EDITOR
    		UnityEditor.EditorApplication.isPlaying = false;
    	#else
    		Application.Quit();
    	#endif
    }
}
