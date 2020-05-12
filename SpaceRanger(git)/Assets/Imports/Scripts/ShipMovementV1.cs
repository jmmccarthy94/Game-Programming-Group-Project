using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovementV1 : MonoBehaviour
{
    public float movementSpeed = 30.0f;
    //public GameObject damageFX;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        var cameraOffset = GameObject.Find("Main Camera").transform.position.z + 20;

        Vector3 direction = new Vector3(horizontal, vertical, 0);
        Vector3 finalDirection = new Vector3(horizontal, vertical, 10.0f);

        transform.position += new Vector3(horizontal, vertical, cameraOffset) * movementSpeed * Time.deltaTime;
        // Limit to camera view
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, -16, 16),
            Mathf.Clamp(transform.position.y, -5, 15),
            cameraOffset);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(finalDirection), Mathf.Deg2Rad * 50.0f);
    }

    /*
    void OnCollisionEnter(Collision col)
    {
        if(col.collider.CompareTag("Asteroid"))
        {
            Debug.Log("Collision!!");
            Destroy(col.gameObject);
            GameObject exp = Instantiate(damageFX, transform.position, transform.rotation);
            col.gameObject.GetComponent<PlayerHealth>().TakeDamage(25);
        }
    }
    */
}
