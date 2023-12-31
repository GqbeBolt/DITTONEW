using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveController : MonoBehaviour
{

    private Rigidbody2D _rb;
    
    private Vector2 _currentInput;
    private bool _requestedJump;
    private bool _requestedSlowdown;
    private bool onGround;
    private bool jumpedOff;
    [SerializeField] private bool faceOtherDirection;

    public LayerMask groundLayer;

    public float speed = 10;
    public float jumpPower = 15;//gravity 4
    public float rayDistance = 1.4f;
    public int jumpNumber;
    public int _jumpCounter;
    public GameObject spriteObject;
    private SpriteRenderer _spriteRenderer;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _spriteRenderer = spriteObject.GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        //set movement
        _rb.velocity = new Vector2(_currentInput.x * speed, _rb.velocity.y); //dont change y velocity

       
        onGround = IsGrounded();

        if (onGround)
        {
            _jumpCounter = jumpNumber;
            jumpedOff = false;
        }

        if (_requestedJump)
        {
            if (onGround)
            {
                Jump();
            } else if (_jumpCounter > 0)
            {
                Jump();
                _jumpCounter--;
            } else
            {
                _requestedJump = false;
            }
        } 
        
        
        if (!onGround && !jumpedOff)
        {
            _jumpCounter = jumpNumber - 1;
            jumpedOff = true;
        }

        if (_requestedSlowdown && _rb.velocity.y > 0)//variable jump height
        {
            _rb.velocity /= new Vector2(1, 1.3f);
            _requestedSlowdown = false;
        }
        else if (_requestedSlowdown)
        {
            _requestedSlowdown = false;
        }
        
        //flipping sprite
        if (_rb.velocity.x > 0.1)
        {
            if (faceOtherDirection)
            {
                _spriteRenderer.flipX = true;
            } else
            {
                _spriteRenderer.flipX = false;
            }
            
           
        }        
        if (_rb.velocity.x < -0.1)
        {
            if (faceOtherDirection)
            {
                _spriteRenderer.flipX = false;
            }
            else
            {
                _spriteRenderer.flipX = true;
            };
           
        }


    }

    private bool IsGrounded()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundLayer);
    }

    public void SetInputs(float x, float y)
    {
        _currentInput.x = x;
        _currentInput.y = y;
    }

    public void RequestJump()
    {
        _requestedJump = true;
    }

    public void Jump()
    {
        _rb.velocity *= Vector2.right;
        _rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        _requestedJump = false;
    }

    public void RequestSlowdown()
    {
        _requestedSlowdown = true;
    }

    public float getXVel()
    {
        return _rb.velocity.x;
    }

    public float getYVel()
    {
        return _rb.velocity.y;
    }

    public void changeJumpHeight(float power)
    {
        jumpPower = power;
    }

    public void changeSpeed(float speed)
    {
        this.speed = speed;
    }

    public void changeJumpAmount(int jumpAmount)
    {
        jumpNumber = jumpAmount;
    }
}
