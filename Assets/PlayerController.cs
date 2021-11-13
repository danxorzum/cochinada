using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Transform gun;
    public GameObject granade;

    public float speed= 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;
    public float grounDistance = 0.4f;
    public Transform groundCheck;
    public LayerMask groundMask;

    CharacterController _controller;
    Vector3 _velcity;
    bool _isGrounded;



    void Start()
    {
        _controller = gameObject.GetComponent<CharacterController>();
    }


    void Update()
    {
        _isGrounded = Physics.CheckSphere(groundCheck.position, grounDistance, groundMask);
        if(_isGrounded && _velcity.y < 0)
        {
            _velcity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        if (Input.GetButtonDown("Fire1"))
        {
        Instantiate(granade, gun.position, gun.rotation).GetComponent<Granade>().Divide();
        }

        Vector3 move = transform.right * x + transform.forward*z;
        _controller.Move(move * speed * Time.deltaTime);
        if (Input.GetButtonDown("Jump")&& _isGrounded)
        {
            _velcity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        _velcity.y += gravity * Time.deltaTime;
        _controller.Move(_velcity* Time.deltaTime);

    }
}
