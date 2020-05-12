using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject object3;
    private Vector3 direction = new Vector3(0, 4, 0);
    private Vector3 angle = new Vector3(1, 1, 1);

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * Time.deltaTime, Space.World);
        transform.Rotate(angle, Space.World);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Instantiate(object3, new Vector3(0, 0, 0), Quaternion.identity);
        Destroy(gameObject);
        Quaternion target = Quaternion.Euler(30, 30, 30);
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime);
    }

}
