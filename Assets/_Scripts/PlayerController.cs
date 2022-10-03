using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;
    // Player movement
    public PlayerAction inputAction;
    Vector2 move;
    Vector2 rotate;
    private float walkspeed = 5f;
    public Camera playerCamera;
    Vector2 cameraRotation;

    // Player Jump
    Rigidbody rb;
    private float distanceToTheGround;
    private bool isGrounded = true;
    private float jump = 30f;

    // Player animation
    Animator playerAnimator;
    private bool isWalking = false;

    // Projectile bullets
    public GameObject bullet;
    public Transform projectilePos;

    // Start is called before the first frame update
    void Start()
    {
        if (!instance)
        {
            instance = this;
        }
        // Using controller from PlayerInputController
        inputAction = PlayerInputController.controller.inputAction;

        inputAction.Player.Move.performed += cntxt => move = cntxt.ReadValue<Vector2>();
        inputAction.Player.Move.canceled += cntxt => move = Vector2.zero;

        inputAction.Player.Jump.canceled += cntxt => Jump();

        inputAction.Player.Shoot.performed += cntxt => Shoot();

        rb = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
        distanceToTheGround = GetComponent<Collider>().bounds.extents.y;
    }

    private void Jump()
    {
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jump);
            isGrounded = false;
        }
    }

    public void Shoot()
    { 
        Rigidbody bulletRb = Instantiate(bullet, projectilePos.position, Quaternion.identity).GetComponent<Rigidbody>();
        bulletRb.AddForce(transform.forward * 100f, ForceMode.Impulse);
        bulletRb.AddForce(transform.up * 5f, ForceMode.Impulse);
        bulletRb.gameObject.tag = "Projectile";
    }

    // Update is called once per frame
    void Update()
    {
        // Forward
        transform.Translate(Vector3.forward * move.y * Time.deltaTime*walkspeed, Space.Self);
        // Right
        transform.Translate(Vector3.right * move.x * Time.deltaTime * walkspeed, Space.Self);

        isGrounded = Physics.Raycast(transform.position, -Vector3.up, distanceToTheGround + 2f);
    }
}
