using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    public float velocity = 500;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire3") && !PauseMenu.GameIsPaused) {
            Fire();
        }
    }

    void Fire()
    {
        //Rigidbody newBullet = Instantiate(bullet, transform.position, transform.rotation) as Rigidbody;
        //newBullet.AddForce(transform.forward * velocity, ForceMode.VelocityChange);
        var bullet = (GameObject)Instantiate(
    		bulletPrefab,
    		bulletSpawn.position,
    		bulletSpawn.rotation);
    	bullet.GetComponent<Rigidbody>().velocity=bullet.transform.forward*250;
        Destroy(bullet, 5.0f);
    }
}
