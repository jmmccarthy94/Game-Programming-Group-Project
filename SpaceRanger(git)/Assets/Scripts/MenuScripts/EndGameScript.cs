using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndGameScript : MonoBehaviour
{
    public void MM ()
    {
        PauseMenu.GameIsPaused = false;
        SceneManager.LoadScene(0);
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