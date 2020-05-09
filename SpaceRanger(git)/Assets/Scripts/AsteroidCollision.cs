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
        if(col.collider.CompareTag("Bullet"))
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
            GameObject exp = Instantiate(explosion, transform.position, transform.rotation);
            exp.transform.localScale = new Vector3(5,5,5);
        }
    }
}
