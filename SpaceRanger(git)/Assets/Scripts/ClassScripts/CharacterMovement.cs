using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    public float gravity;
    private Vector3 direction;
    private Vector3 walkingVelocity;
    private Vector3 fallingVelocity;
    private CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        jumpHeight = 3.0f;
        speed = 5.0f;
        direction = Vector3.zero;
        gravity = 9.8f;
        walkingVelocity = Vector3.zero;
        fallingVelocity = Vector3.zero;
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.z = Input.GetAxis("Vertical");
        direction = direction.normalized;
        if (direction != Vector3.zero)
            transform.forward = direction;
        walkingVelocity = direction * speed;
        controller.Move(walkingVelocity * Time.deltaTime);

        fallingVelocity.y -= gravity * Time.deltaTime;

        if (Input.GetButtonDown("Jump"))
        {
            fallingVelocity.y = Mathf.Sqrt(gravity * jumpHeight);

        }
        controller.Move(fallingVelocity * Time.deltaTime);

    }
}
