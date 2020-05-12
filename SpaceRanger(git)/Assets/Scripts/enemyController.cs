using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
	public Transform target;
	public GameObject explosion;
	private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target);
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void OnCollisionEnter(Collision col) {
    	if(col.gameObject.tag == "Bullet") {
    		Destroy(col.gameObject);
    		Destroy(this);
    		Instantiate(explosion,transform.position,transform.rotation);
    		Destroy(gameObject);
    	}
    }
}







