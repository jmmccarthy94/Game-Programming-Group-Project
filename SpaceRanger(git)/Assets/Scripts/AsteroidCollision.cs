using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{

    public GameObject explosion;
    public int asteroidHealth = 100;


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.GetComponent<Collider>().CompareTag("Bullet"))
        {
            asteroidHealth -= 10;

            GameObject exp1 = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(col.gameObject);
            if(asteroidHealth <= 0)
            {
                Destroy(this.gameObject);
                GameObject exp2 = Instantiate(explosion, transform.position, transform.rotation);
                exp2.transform.localScale = new Vector3(5,5,5);
            }   
        }
        else if(col.GetComponent<Collider>().CompareTag("Player"))
        {
            Debug.Log("Collision!!");
            Destroy(this.gameObject);
            col.gameObject.GetComponent<SimpleHealthBar_SpaceshipExample.PlayerHealth>().TakeDamage(25); 
        }
    }
}
