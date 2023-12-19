using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVarientMoveController : MonoBehaviour
{
    private MoveController _moveController;
    public Animator spriteChildAnim;

    public void Start()
    {
        _moveController = GetComponent<MoveController>();
    }

    void Update()
    {
        //collect input date but wait till fixed update to apply
        _moveController.SetInputs(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));//get inputs
        
        if (Input.GetButtonDown("Jump"))
        {
            _moveController.RequestJump();
        }
        if (Input.GetButtonUp("Jump"))//veriable jump hight input
        {
            _moveController.RequestSlowdown();
        }
    }

    private void FixedUpdate()
    {
        spriteChildAnim.SetFloat("Speed", Mathf.Abs(_moveController.getXVel()));
        spriteChildAnim.SetFloat("YVel", _moveController.getYVel());
    }
}
