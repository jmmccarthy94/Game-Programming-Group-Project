using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    Animator animator;
    public float health = 50f;
    

    private void Start()
    {
        animator = GetComponent<Animator>();
        
    }
    public void TakeDamage(float amount)
    {

        animator.SetTrigger("TakeDamage");
        
        health -=amount;
        if(IsDead())
        {
            
            Debug.Log(health);
            Die();
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
        Destroy(gameObject);
    }
}
