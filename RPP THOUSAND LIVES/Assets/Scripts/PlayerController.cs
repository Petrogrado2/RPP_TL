using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public float velocidade;

    public float maxSpeed;

    public float jumpSpeed;

    public float maxJumpTime;

    public Vector3 groundOffSet;

    public Vector3 boxSize;

    public LayerMask groundLayer;

    [SerializeField] private PlayerInput playerInput;

    private Rigidbody2D _rigidbody2D;

    private GameInput _gameInput;

    private PlayerInput _PlayerInput;

    private Vector2 _movimento;

    private bool _doJump;

    private bool _isGrounded;

    private float _starJumpTime;

    private bool _doDoubleJump;

    private bool _isMovingRight;

    private Animator _playerAnimator;

    private void OnEnable()
    {
        playerInput.onActionTriggered += PlayerInputOnActionTriggered;
    }

    private void OnDisable()
    {
        playerInput.onActionTriggered -= PlayerInputOnActionTriggered;
    }

   
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
        _gameInput = new GameInput();
        
    }

    private void Update()
    {
        CheckGround();
        AnimationUpdaates();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*
        _rigidbody2D.AddForce(_movimento * velocidade);
        if (Mathf.Abs(_rigidbody2D.velocity.x) > maxSpeed)
            _rigidbody2D.velocity = new Vector2(Mathf.Sign(_rigidbody2D.velocity.x) * maxSpeed, _rigidbody2D.velocity.y);
        */  
        _rigidbody2D.velocity = new Vector2(_movimento.x * velocidade * Time.fixedDeltaTime, _rigidbody2D.velocity.y); 
        if(_isMovingRight && _movimento.x > 0) Flip();
        if(!_isMovingRight && _movimento.x < 0 ) Flip();
        Jump();
       
    }

    private void AnimationUpdaates()
    {
        _playerAnimator.SetFloat("Speed", Mathf.Abs(_movimento.x));
        _playerAnimator.SetBool("isGrounded", _isGrounded);
        _playerAnimator.SetFloat("VertSpeed", _rigidbody2D.velocity.y);
    }

    private void CheckGround()
    {
        //_isGrounded = ((bool)Physics2D.Linecast(start:(Vector2)transform.position,end: transform.position + groundOffSet, (int)groundLayer));

       /* RaycastHit2D hit = new RaycastHit2D();
        ContactFilter2D filter = new ContactFilter2D();
        filter.layerMask = groundLayer;
         */
       
       
         RaycastHit2D[] hit = Physics2D.BoxCastAll((transform.position + new Vector3(groundOffSet.x * transform.localScale.x, groundOffSet.y,0)),boxSize, 0,
            Vector2.up, groundOffSet.z,groundLayer);
         _isGrounded = false;
         if (hit.Length > 0)
         {
             foreach (RaycastHit2D  raycastHit2D in hit)
             {
                 if (Vector2.Angle(raycastHit2D.normal, Vector2.up) < 20 && raycastHit2D.point.y < transform.position.y - 1.5f)
                 {
                     _isGrounded = true;
                     break;
                 }
             }
             
         }
        if (_isGrounded && _doDoubleJump) _doDoubleJump = false;
    }

    private void Jump()
    {
        if (_doJump)
        {
           // _rigidbody2D.AddForce(Vector2.up * jumpSpeed);
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, jumpSpeed * Time.fixedDeltaTime);
            if (Time.time - _starJumpTime > maxJumpTime) _doJump = false;
        }
    }

    private void PlayerInputOnActionTriggered(InputAction.CallbackContext obj)
    {
        if(string.Compare(strA:obj.action.name, strB:_gameInput.Gameplay.Move.name, StringComparison.Ordinal)==0)
        {
            _movimento = obj.ReadValue<Vector2>();
            _movimento.y = 0;
            Debug.Log(message: _movimento.ToString());
        }
        if (string.Compare(strA: obj.action.name, strB: _gameInput.Gameplay.Jump.name, StringComparison.Ordinal) == 0)
        {
          

            if (obj.started)
            {
                if (_isGrounded)
                {
                    _doJump = true;
                    _starJumpTime = Time.time;
                }
                else
                {
                    if (!_doDoubleJump)
                    {
                        _doDoubleJump = true;
                        _doJump = true;
                        _starJumpTime = Time.time;
                    }
                }
                
            }

            if (obj.canceled) _doJump = false;
        }
    }

    private void Flip()
    {
        _isMovingRight = !_isMovingRight;
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
    private void OnDrawGizmos()
    {
        //Debug.DrawLine(start: transform.position, end: (Vector3)transform.position + groundOffSet, Color.red);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position + new Vector3(groundOffSet.x * transform.localScale.x, groundOffSet.y,0), boxSize );
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position + new Vector3(groundOffSet.x * transform.localScale.x, groundOffSet.y + groundOffSet.z,0), boxSize); 
    }
}
