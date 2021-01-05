using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 2f;
    public float runSpeed = 2f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    float stamina = 100f;
    float maxstamina = 100f;

    float number;

    public Slider slider;

    SavePlayerPos playerPosData;

    private void Awake()
    {
        playerPosData = FindObjectOfType<SavePlayerPos>();
        playerPosData.PlayerPosLoad();
    }

    private void Start()
    {
        number = runSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //if (stamina <= maxstamina)
        //{
        //    stamina += 5f * Time.deltaTime;
        //}

        //if (stamina <= 0f)
        //{
        //    runSpeed = speed;
        //}
        //else
        //{
        //    runSpeed = number;
        //}

        //slider.value = stamina;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (stamina > 0)
            {
                stamina -= 20f * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.W))
        {
            if (stamina <= maxstamina)
            {
                stamina += 10f * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.UpArrow))
        {
            if (stamina <= maxstamina)
            {
                stamina += 10f * Time.deltaTime;
            }
        }
        else
        {
            if (stamina <= 100)
            {
                stamina += 30f * Time.deltaTime;
            }
        }

        if (stamina <= 0f)
        {
            runSpeed = speed;
        }
        else
        {
            runSpeed = number;
        }

        slider.value = stamina;

        if (stamina < 100)
        {
            slider.gameObject.SetActive(true);
        }
        else
        {
            slider.gameObject.SetActive(false);
        }


        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (stamina > 0)
            {
                stamina -= 20f * Time.deltaTime;
                controller.Move(move * runSpeed * Time.deltaTime);
            }
            //controller.Move(move * runSpeed * Time.deltaTime);
        }

    }
}