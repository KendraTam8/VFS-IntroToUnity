using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D _Rigidbody;
    private SpriteRenderer _SpriteRenderer;
    private Animator _Animator;
    private float _XInput;
    private bool _IsJumping;
    private bool _IsGrounded;
    private bool _IsFacingLeft;

    [SerializeField]
    private float _MoveSpeed = 5f;
    [SerializeField]
    private float _JumpSpeed = 5f;
    [SerializeField]
    private float _GroundCheckDistance = 0.25f;
    [SerializeField]
    private float _GroundCheckOffset = 0.15f;
    [SerializeField]
    private LayerMask _LayerMask;
    [SerializeField]
    private string _XInputName = "XInput";
    [SerializeField]
    private string _IsGroundedName = "IsGrounded";
    [SerializeField]
    private string _JumpName = "Jump";

    private void Start()
    {
        _Rigidbody = GetComponent<Rigidbody2D>();
        _SpriteRenderer = GetComponent<SpriteRenderer>();
        _Animator = GetComponent<Animator>();
    }

    private void Update()
    {
        ReadInputs();
        HandleSprite();
        HandleAnimations();
    }


    private void FixedUpdate()
    {
        MovementPhysics();
        _IsGrounded = CheckGround(_GroundCheckOffset) || CheckGround(-_GroundCheckOffset);
    }

    private bool CheckGround(object p)
    {
        throw new System.NotImplementedException();
    }

    private void ReadInputs()
    {
        _XInput = Input.GetAxis("Horizontal"); //move with w/d or left/right arrow keys
        if (Input.GetButtonDown("Jump") == true && _IsGrounded == true) //jump is a predefined input button value (spacebar)
        {
            _IsJumping = true;
        }
    }

    private void HandleSprite()
    {
        if (_XInput == 0)
        {
            return;
        }
        if (_XInput < 0)
        {
            _IsFacingLeft = true;
        }
        else
        {
            _IsFacingLeft = false;
        }
        _SpriteRenderer.flipX = _IsFacingLeft;
    }
    
    private void HandleAnimations()
    {
        var xInput = _XInput;

        if (xInput < 0)
        {
            xInput = xInput * -1;
        }

        _Animator.SetFloat(_XInputName, xInput);
        _Animator.SetBool(_IsGroundedName, _IsGrounded);

        if (_IsJumping == true)
        {
            _Animator.SetTrigger(_JumpName);
        }
    }

    private void MovementPhysics()
    {
        //var compiles faster than types and will auto decide the variable type
        var xVelocity = _XInput * _MoveSpeed;
        var yVelocity = _IsJumping ? _JumpSpeed : _Rigidbody.velocity.y;

        var velocity = new Vector2(xVelocity, yVelocity);
        _Rigidbody.velocity = velocity;

        _IsJumping = false; //after physics is done updating, set to false
    }

    private bool CheckGround(float groundCheckOffset) 
    {
        var offset = new Vector2(groundCheckOffset, _GroundCheckDistance * -0.75f);
        var origin = offset + (Vector2)transform.position; //(Vector2) to cast so that instead of 3D it's 2D, transform.position = position in world space
        
        if (Physics2D.Raycast(origin, Vector2.down, _GroundCheckDistance, _LayerMask)) 
        {
            Debug.DrawRay(origin, Vector2.down * _GroundCheckDistance, Color.green);
            return true; 
        }
        else
        {
            Debug.DrawRay(origin, Vector2.down * _GroundCheckDistance, Color.red);
            return false;        
        }
    }

}
