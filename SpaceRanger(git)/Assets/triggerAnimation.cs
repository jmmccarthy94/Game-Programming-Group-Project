using UnityEngine;
using UnityEngine.SceneManagement;

public class triggerAnimation : MonoBehaviour
{
    public Animator animator;
    private int levelToLoad;

    public void FadeToNextLevel()
    {
        Debug.Log("Going to next level");
        FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("fadeOut");

    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
