using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public int buttonWidth;
    public int buttonHeight;
    private int origin_x;
    private int origin_y;
    public GUISkin mySkin;



    // Start is called before the first frame update
    void Start()
    {
        buttonWidth = 50;
        buttonHeight = 20;
        origin_x = Screen.width / 2 - buttonWidth / 2;
        origin_y = Screen.height / 2 - buttonHeight * 2;

    }

    // Update is called once per frame
    void OnGUI()
    {
        GUI.skin = mySkin;
        if (GUI.Button(new Rect(origin_x, origin_y, buttonWidth, buttonHeight), "Scene1"))
        {
            Application.LoadLevel(1);
        }

        if (GUI.Button(new Rect(origin_x, origin_y + buttonHeight + 10, buttonWidth, buttonHeight), "Scene2"))
        {
            Application.LoadLevel(2);
        }
        if (GUI.Button(new Rect(origin_x, origin_y + buttonHeight *2 + 20, buttonWidth, buttonHeight), "Scene3"))
        {
            Application.LoadLevel(3);
        }

        if (GUI.Button(new Rect(origin_x, origin_y + buttonHeight * 3 + 40, buttonWidth, buttonHeight), "quit"))
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
               Application.Quit();
            #endif
        }
            

            
    }
}
