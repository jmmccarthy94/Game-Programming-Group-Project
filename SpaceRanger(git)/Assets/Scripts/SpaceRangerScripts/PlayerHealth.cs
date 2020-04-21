using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    // GameObject enemyAttack = GameObject.FindGameObjectWithTag("Enemy");
    Animator animator;
    Transform enemy;
    NavMeshAgent agent;
    float waitHit = 1.3f;
    float timer;



    // Start is called before the first frame update
    void Start()
    {
        enemy = PlayerManager.instance.Enemy.transform;
        currentHealth = startingHealth;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        float distance = Vector3.Distance(transform.position, enemy.position);
        //Debug.Log("playerHealth:  " + enemy.position + transform.position);

        if (distance <= (agent.stoppingDistance + 2f) && timer >= waitHit)
        {
            currentHealth = TakeDamage(currentHealth);
            timer = 0;
        }



        /*
        if (enemyAttack.GetComponent<EnemyMovement>().attackDis)
        {
            animator.SetTrigger("Damage");
            //animator.SetInteger()
            Debug.Log("Owwwww");
            currentHealth -= 10;
        }
        */
    }
    public int TakeDamage(int currentHealth)
    {
        //yield return new WaitForSeconds(2);
        Debug.Log("OWWWWW");
        currentHealth -= 10;
        animator.SetTrigger("Damage");
        if (currentHealth == 0)
        {
            IsDead();
        }
        return currentHealth;
    }

    public void IsDead()
    {

        animator.SetTrigger("Death");
    }
}
