using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    //public Animator anim;
    //public triggerAnimation next;

    void Start()
    {
        //anim.enabled = true;
        //anim.SetBool("fade", false);
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            //anim.SetBool("fade", true);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            //Debug.Log("Collision with end level");
            //next = GameObject.Find("GameplayPlane").GetComponent(triggerAnimation);
            //next.FadeToNextLevel();
        }

        if(col.gameObject.CompareTag("Bullet"))
        {
            Destroy(col.gameObject);
        }
    }
}
