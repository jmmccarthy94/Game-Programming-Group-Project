using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyMovement : MonoBehaviour
{
    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent agent;
    Animator animator;
    //float health;
    public bool attackDis = false;
    


    // Start is called before the first frame update
    void Start()
    {
       
        target = PlayerManager.instance.Player.transform;
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        //GameObject enemy = GameObject.
        //health
    }

    // Update is called once per frame
    void Update()
    {
        //EnemyCombat.IsDead();
        
        float distance = Vector3.Distance(target.position, transform.position);
        //Debug.Log("EnemyMovement:  " + target.position + transform.position);

        if (distance <= lookRadius && distance >= 2f)
        {
            animator.SetFloat("Speed", 1f);
            agent.SetDestination(target.position);
        } 
            
        else if(distance >= lookRadius || distance <=(agent.stoppingDistance + 4f))
        {
            animator.SetFloat("Speed", 0f);
            
            if(distance <= (agent.stoppingDistance + 2f))
            {
                attackDis = true;
                agent.velocity = Vector3.zero;
                animator.SetTrigger("attack");//attack the target
                FaceTarget();
                Debug.Log("Tarynnnnnn");
            }
           
            
        }
        
       /* else if((distance >= lookRadius))
        {
            animator.SetFloat("Speed", 0f);
        }
        */
    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
    /*
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.collider.name);
    }
    */
}
