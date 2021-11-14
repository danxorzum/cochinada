using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 _velocity = Vector3.zero;
    public Vector3 _acceleration = Vector3.zero;
    private Vector3 _inputVelocity = Vector3.zero;
    private Vector3 _currentDirectionVelocity = Vector3.zero;
    public Vector3 gravity = new Vector3(0, -150, 0);
    public float jumpForce = 8f;
    public bool enableGravity = true;
    public float speed = 5f;
    public float mouseSensitivity = 5f;

    CharacterController _cc;
    private float _xMovement;
    private float _zMovement;

    private float _xMouseAxis;
    private float _yMouseAxis;

    Transform _camera;

    void Awake()
    {
        _cc = gameObject.GetComponent<CharacterController>();
        _camera = Camera.main.transform;
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update() {
        _xMovement = Input.GetAxis("Horizontal");
        _zMovement = Input.GetAxis("Vertical");

        if(Input.GetKeyDown(KeyCode.Space)){
            _velocity.y = jumpForce;
        }

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;   
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        _xMouseAxis -= mouseY;
        _xMouseAxis = Mathf.Clamp(_xMouseAxis, -85f, 80f);
        _yMouseAxis += mouseX;

        _camera.transform.rotation = Quaternion.Euler(_xMouseAxis, _yMouseAxis, 0);
    }

    private void FixedUpdate()
    {
        UpdateMotion(Time.fixedDeltaTime);
    }

    public void UpdateMotion(float deltaTime)
    {
        Vector3 dir = Vector3.Cross(_camera.transform.right, Vector3.up);

        _inputVelocity = Vector3.SmoothDamp(_inputVelocity, (_camera.transform.right * _xMovement + dir * _zMovement) * speed, ref _currentDirectionVelocity, .1f);

        enableGravity = !_cc.isGrounded;

        ApplyGravity(deltaTime);

        _cc.Move((_inputVelocity + _velocity) * deltaTime);
    }

    public void ApplyGravity(float deltaTime)
    {
        if (enableGravity)
        {
            _acceleration += gravity;
            _velocity += _acceleration * deltaTime;
        }

        _acceleration *= 0;
    }


}
