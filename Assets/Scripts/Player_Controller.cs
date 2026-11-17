
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Player_Controller : MonoBehaviour
{
    public float speed = 5f;

    public float gravity = -9.81f;
    public float verticalSpeed;

    float horizontalMove;
    float verticalMove;
    CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    void Update()
    {
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        if (controller.isGrounded == true)
        {
            verticalSpeed = 0f;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                verticalSpeed = 5f;
            }
        }

        verticalSpeed += gravity * Time.deltaTime;

        Vector3 direction = new Vector3(horizontalMove, verticalSpeed, verticalMove);
        controller.Move(direction * speed * Time.deltaTime);
    }
}