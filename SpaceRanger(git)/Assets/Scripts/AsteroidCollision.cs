using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidCollision : MonoBehaviour
{

    public GameObject explosion;


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Bullet")
        {
            Destroy(col.gameObject);
            Destroy(this);
            Instantiate(explosion, transform.position, transform.rotation);
        }
    }
}
