using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVarientMoveController : MonoBehaviour
{
    private MoveController _moveController;

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

}
