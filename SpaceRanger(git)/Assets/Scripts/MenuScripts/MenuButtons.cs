using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuButtons : MonoBehaviour
{
    public void Begin ()
    {
        PauseMenu.GameIsPaused = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame ()
    {
        #if UNITY_EDITOR
    		UnityEditor.EditorApplication.isPlaying = false;
    	#else
    		Application.Quit();
    	#endif
    }

}