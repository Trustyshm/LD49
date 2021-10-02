#if ENABLE_INPUT_SYSTEM 
using UnityEngine.InputSystem;
#endif

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -10f;
    public float jumpHeight = 2f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    

    Vector3 velocity;
    bool isGrounded;

    private bool doOnce;
    [System.NonSerialized]
    public bool roundActive;

    private Animator anim;

    private Timer timer;

#if ENABLE_INPUT_SYSTEM
    InputAction movement;
    InputAction jump;

    void Start()
    {
        anim = GetComponent<Animator>();
        roundActive = false;
        timer = GameObject.FindGameObjectWithTag("TheTimer").GetComponent<Timer>();
        movement = new InputAction("PlayerMovement", binding: "<Gamepad>/leftStick");
        movement.AddCompositeBinding("Dpad")
            .With("Up", "<Keyboard>/w")
            .With("Up", "<Keyboard>/upArrow")
            .With("Down", "<Keyboard>/s")
            .With("Down", "<Keyboard>/downArrow")
            .With("Left", "<Keyboard>/a")
            .With("Left", "<Keyboard>/leftArrow")
            .With("Right", "<Keyboard>/d")
            .With("Right", "<Keyboard>/rightArrow");
        
        jump = new InputAction("PlayerJump", binding: "<Gamepad>/a");
        jump.AddBinding("<Keyboard>/space");

        movement.Enable();
        jump.Enable();
    }
#endif

    // Update is called once per frame
    void Update()
    {

        anim.SetFloat("PlayerSpeed", new Vector3(Input.GetAxis("Horizontal"), 0 , Input.GetAxis("Vertical")).magnitude, 1f, Time.deltaTime * 10f);
        anim.SetFloat("HorizontalDirection", Input.GetAxis("Horizontal"), 1f, Time.deltaTime * 10f);
        anim.SetFloat("VerticalDirection", Input.GetAxis("Vertical"), 0.5f, Time.deltaTime * 10f);

        if (!doOnce)
        {
            if (Input.GetAxis("Horizontal") > 0.05 || Input.GetAxis("Vertical") > 0.05)
            {
                timer.StartTimer();
                doOnce = true;
                roundActive = true;
            }
        }
        float x;
        float z;
        bool jumpPressed = false;

        if (doOnce && !roundActive)
        {
            controller.velocity.Set(0, 0, 0);
            this.gameObject.SetActive(false);
        }
#if ENABLE_INPUT_SYSTEM
        var delta = movement.ReadValue<Vector2>();
        x = delta.x;
        z = delta.y;
        jumpPressed = Mathf.Approximately(jump.ReadValue<float>(), 1);
#else
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        jumpPressed = Input.GetButtonDown("Jump");
#endif

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        Vector3 move = transform.right * x + transform.forward * z;
        if (Mathf.Abs(move.x) > Mathf.Abs(move.z))
        {
            controller.Move(new Vector3(move.x, move.y, 0).normalized * speed * Time.deltaTime);
        }
        else
        {
            controller.Move(new Vector3(0, move.y, move.z).normalized * speed * Time.deltaTime);
        }
        //controller.Move(move * speed * Time.deltaTime);

        if(jumpPressed && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        if (Mathf.Abs(velocity.x) > Mathf.Abs(velocity.z))
        {
            velocity.z = 0;
            controller.Move(new Vector3(velocity.x, velocity.y, 0).normalized * Time.deltaTime);
        }
        else
        {
            velocity.x = 0;
            controller.Move(new Vector3(0, velocity.y, velocity.z).normalized * Time.deltaTime);
        }

        //controller.Move(velocity * Time.deltaTime);
    }
}
