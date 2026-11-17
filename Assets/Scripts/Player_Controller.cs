
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Player_Controller : MonoBehaviour
{
    public float speed = 5f;
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
        Vector3 direction = new Vector3(horizontalMove, 0, verticalMove);
        controller.Move(direction * speed * Time.deltaTime);
    }
}










// public float speed = 5f;

//    public float jumpForce = 5f;
//    public float gravity = -9.81f;

//    float horizontalMove;
//float verticalMove;
//float verticalSpeed;
//CharacterController controller;

//void Start()
//{
//    controller = GetComponent<CharacterController>();
//}
//void Update()
//{
//    horizontalMove = Input.GetAxis("Horizontal");
//    verticalMove = Input.GetAxis("Vertical");
//    if (controller.isGrounded)
//    {
//        verticalSpeed = 0;

//        if (Input.GetKeyDown(KeyCode.Space))
//        {
//            verticalSpeed = jumpForce;
//        }
//    }
//    verticalSpeed += gravity * Time.deltaTime;
//    Vector3 direction = new Vector3(horizontalMove, 0, verticalMove);
//    Vector3 jumpDirection = Vector3.up * verticalSpeed;
//    controller.Move((direction * speed + jumpDirection) * Time.deltaTime);
//}