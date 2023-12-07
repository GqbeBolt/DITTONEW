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

    public LayerMask groundLayer;

    public float speed = 10;
    public float jumpPower = 15;//gravity 4
    public float rayDistance = 1.4f;
    public int jumpNumber;
    private int _jumpCounter;
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

        if (_requestedJump && (IsGrounded() || _jumpCounter > 0))
        {
            if (IsGrounded())
            {
                //if you jump from the ground set jump back to normal;
                _jumpCounter = jumpNumber - 1;
            }
            else // if not grounded just reduce jump counter
            {
                _jumpCounter--;
            }


            _rb.velocity *= Vector2.right;
            _rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            _requestedJump = false;
        }
        else if (_requestedJump)
        {
            _requestedJump = false;
        }

        if (_requestedSlowdown && _rb.velocity.y > 0)//variable jump height
        {
            _rb.velocity /= new Vector2(1, 2);
            _requestedSlowdown = false;
        }
        else if (_requestedSlowdown)
        {
            _requestedSlowdown = false;
        }
        Debug.Log(_rb.velocity.x);
        if (_rb.velocity.x < 2)
        {
            _spriteRenderer.flipX = true;
           
        }        
        if (_rb.velocity.x > -2)
        {
            _spriteRenderer.flipX = false;
           
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

    public void RequestSlowdown()
    {
        _requestedSlowdown = true;
    }
    //to do at mvhs:
    /*
     *  add landing animation
     *  add sprites
     *  fricitonless character collider
     *  
     *
     * 
     */
    
}
