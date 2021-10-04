#if ENABLE_INPUT_SYSTEM 
using UnityEngine.InputSystem;
#endif

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    private AudioSource audioSource;
    public AudioClip dam;
    public AudioClip exertion;
    public AudioClip oof;

    private float speed;
    public float speedMin;
    public float speedMax;
    public float gravity = -10f;
    public float jumpHeight = 2f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float swayTimerMin;
    public float swayTimerMax;
    private float swayTimer;
    public float swayLengthMax;
    private float swayLength;

    private Cinemachine.CinemachineVirtualCamera cam;

    Vector3 velocity;
    bool isGrounded;

    private Animator cameraAnim;

    private bool doOnce;
    [System.NonSerialized]
    public bool roundActive;

    private bool doOnceTwo;
    private bool doOnceThree;

    private Animator anim;

    private Timer timer;

    [System.NonSerialized]
    public bool canMove;

    public float timeToStagger;

    public float maxRandomStumble;
    public float minRandomStumbe;
    private float randomStumbleTime;

    private int directionInt;

    public bool canSway;


#if ENABLE_INPUT_SYSTEM
    InputAction movement;
    InputAction jump;

    void Start()
    {
        audioSource = GameObject.FindGameObjectWithTag("VoiceSFX").GetComponent<AudioSource>();
        canMove = true;
        randomStumbleTime = Random.Range(minRandomStumbe, maxRandomStumble);
        cam = GameObject.FindGameObjectWithTag("TheCam").GetComponent<Cinemachine.CinemachineVirtualCamera>();
        cameraAnim = cam.GetComponent<Animator>();
        doOnceTwo = false;
        speed = 1;
        swayTimer = Random.Range(swayTimerMin, swayTimerMax);
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
        if (roundActive)
        {
            swayTimer -= Time.deltaTime;
            if (swayTimer <= 0)
            {
                speed = Mathf.Lerp(speed, ((int)Random.Range(speedMin + 0.4f, speedMax)), 0.5f);
                swayTimer = Random.Range(swayTimerMin, swayTimerMax);
                anim.speed = speed - 0.5f;
                doOnceTwo = true;
                swayLength = swayLengthMax;
            }

            if (swayLength > 0)
            {
                swayLength -= Time.deltaTime;
            }

            if (swayLength <= 0 && doOnceTwo)
            {
                doOnceTwo = false;
                speed = 1;
                anim.speed = speed + 0.2f;
                swayLength = 0;
            }
        }
        
       
       

        if (canMove)
        {
            anim.SetFloat("PlayerSpeed", new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).magnitude, 1f, Time.deltaTime * 10f);
            anim.SetFloat("HorizontalDirection", Input.GetAxis("Horizontal"), 1f, Time.deltaTime * 10f);
            anim.SetFloat("VerticalDirection", Input.GetAxis("Vertical"), 0.5f, Time.deltaTime * 10f);
        }
        

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
        if (canMove)
        {
            randomStumbleTime -= Time.deltaTime;
            if (Mathf.Abs(move.x) > Mathf.Abs(move.z))
            {
                controller.Move(new Vector3(move.x, move.y, 0).normalized * speed * Time.deltaTime);
            }
            else
            {
                controller.Move(new Vector3(0, move.y, move.z).normalized * speed * Time.deltaTime);
            }
        }
        
        //controller.Move(move * speed * Time.deltaTime);

        if (move.magnitude > 0.1f)
        {
            cameraAnim.SetTrigger("SwayCamera");
        }
        else
        {
            cameraAnim.SetTrigger("UnSway");
        }

        if (jumpPressed && isGrounded)
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
        if (canSway)
        {
            if (randomStumbleTime <= 0 && !doOnceThree)
            {
                doOnceThree = true;
                audioSource.clip = exertion;
                audioSource.Play();
                RandomStumble();
                canMove = false;
            }
        }
        

        if (canSway)
        {

            if (directionInt != 0)
            {
                if (directionInt == 1)
                {

                    anim.SetFloat("PlayerSpeed", 1f);
                    anim.SetFloat("VerticalDirection", -1f, 0.2f, Time.deltaTime * 10);
                    controller.Move((Vector3.forward.normalized * 2.5f) * Time.deltaTime);
                    
                }
                if (directionInt == 2)
                {

                    anim.SetFloat("PlayerSpeed", 1f);
                    anim.SetFloat("VerticalDirection", 1f, 0.2f, Time.deltaTime * 10);
                    controller.Move((Vector3.back.normalized * 2.5f) * Time.deltaTime);
                    
                }
                if (directionInt == 3)
                {

                    anim.SetFloat("PlayerSpeed", 1f);
                    anim.SetFloat("HorizontalDirection", 1f, 0.2f, Time.deltaTime * 10);
                    controller.Move((Vector3.left.normalized * 2.5f) * Time.deltaTime);
                    
                }
                if (directionInt == 4)
                {

                    anim.SetFloat("PlayerSpeed", 1f);
                    anim.SetFloat("HorizontalDirection", -1f, 0.2f, Time.deltaTime * 10);
                    controller.Move((Vector3.right.normalized * 2.5f) * Time.deltaTime);
                    
                }
            }
        }
        
        
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("AShelf") || hit.gameObject.CompareTag("ATable"))
        {
                if (hit.gameObject.GetComponent<KinematicOnTouch>() != null)
                {
                    int randomClip = Random.Range(1, 3);
                   if (randomClip == 1)
                   {
                        audioSource.clip = dam;
                        audioSource.Play();
                   }
                    if (randomClip == 2)
                    {
                        audioSource.clip = oof;
                        audioSource.Play();
                    }

                    hit.gameObject.GetComponent<KinematicOnTouch>().Touched();
                }
            
        }
    }

    private void RandomStumble()
    {
        
        int direction = Random.Range(1, 5);
        if (direction == 1)
        {
            StartCoroutine(StaggerTiming());
            directionInt = direction;
           
        }

        else if (direction == 2)
        {
            StartCoroutine(StaggerTiming());
            directionInt = direction;

        }

        else if (direction == 3)
        {
            StartCoroutine(StaggerTiming());
            directionInt = direction;

        }
        else
        {
            StartCoroutine(StaggerTiming());
            directionInt = direction;

        }
    }

    IEnumerator StaggerTiming()
    {
        
       
        yield return new WaitForSeconds(timeToStagger);
        randomStumbleTime = Random.Range(minRandomStumbe, maxRandomStumble);
        doOnceThree = false;
        directionInt = 0;
        canMove = true;
    }
}
