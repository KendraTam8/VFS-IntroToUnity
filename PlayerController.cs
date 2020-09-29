using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{

    [SerializeField]
    private Transform _CameraPivot;

    [SerializeField]
    private Transform _CameraTransform;

    [SerializeField]
    private float _MoveSpeed = 8f;

    [SerializeField]
    private float _JumpSpeed = 12f;

    [SerializeField]
    private KeyCode _KeyToJump = KeyCode.Space;

    private Rigidbody _RB;
    private float _XInput;
    private float _ZInput;
    private bool _JumpPressed = false;

    private void Awake()
    {
        _RB = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        ReadInputs();
        MouseBasedRotations();
        CameraZoom();
    }


    private void CameraZoom()
    {
        var newZoom = _CameraTransform.localPosition;
        newZoom.z += Input.mouseScrollDelta.y;
        newZoom.z = Mathf.Clamp(newZoom.z, -24, 0);
        _CameraTransform.localPosition = newZoom;
    }

    private void MouseBasedRotations()
    {
        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");

        transform.Rotate(0f, mouseX, 0f);
        _CameraPivot.Rotate(-mouseY, 0f, 0f);
    }

    private void ReadInputs()
    {
        _XInput = Input.GetAxis("Horizontal");
        _ZInput = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(_KeyToJump))
        {
            _JumpPressed = true;
        }
    }

    private void FixedUpdate()
    {
        ApplyMovePhysics();
    }

    private void ApplyMovePhysics()
    {
        var newVel = new Vector3(_XInput, 0, _ZInput) * _MoveSpeed;
        newVel = transform.TransformVector(newVel);

        newVel.y = _JumpPressed ? _JumpSpeed : _RB.velocity.y;
        _RB.velocity = newVel;

        _JumpPressed = false;
    }
}

