
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Player_Controller : MonoBehaviour
{
    public float speed = 5f;

    public float gravity = -9.81f;
    public float verticalSpeed;
    public float jumpForce = 5f;

    float horizontalMove;
    float verticalMove;
    CharacterController controller;
    public Game_Manager gameManager;

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
                verticalSpeed = jumpForce;
            }
        }

        verticalSpeed += gravity * Time.deltaTime;

        Vector3 direction = new Vector3(horizontalMove, verticalSpeed, verticalMove);
        controller.Move(direction * speed * Time.deltaTime);
    }
    public void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Collectable"))
        {
            Collectable_Controller collectable =
                hit.gameObject.GetComponent<Collectable_Controller>();
            if (collectable.isCollected == false)
            {
                collectable.isCollected = true;
                gameManager.coinsCollected++;
                Destroy(hit.gameObject);
            }

        }
    }
}