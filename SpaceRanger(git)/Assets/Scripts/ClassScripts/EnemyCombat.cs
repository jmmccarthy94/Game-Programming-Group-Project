
using System.Collections;
using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    Animator animator;
    public float health = 50f;
    

    private void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log("OOOOO");
    }
    public void TakeDamage(float amount)
    {
        if (IsDead())
        {

            Debug.Log(health);
            Die();
        }
        else
        {
            Debug.Log("WHY");
            animator.SetTrigger("TakeDamage");

            health -= amount;
        }
        
    }

    public bool IsDead()
    {
        if (health <= 0)
        {
            return true;
        }
        else
            return false;


    }
    void Die()
    {
        animator.SetFloat("Speed", 0f);
        animator.SetTrigger("death");
        StartCoroutine(Death());
        
    }
    IEnumerator Death()
    {
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
