using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDialog : MonoBehaviour
{
    public GameObject startDialog;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        startDialog.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        startDialog.SetActive(false);
        Time.timeScale = 1f;
    }
}
