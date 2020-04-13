using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovementV1 : MonoBehaviour
{
    public float movementSpeed = 25.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(horizontal, vertical, 0);
        Vector3 finalDirection = new Vector3(horizontal, vertical, 5.0f);

        transform.position += new Vector3(horizontal, vertical, 0) * movementSpeed * Time.deltaTime;
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(finalDirection), Mathf.Deg2Rad * 50.0f);
    }
}
