using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnimieVarientMoveController : MonoBehaviour
{
    private MoveController _moveController;
    private ShootProjectile shoot;

    public float viewRange = 6;
    public float stopRange = 3;

    public State currentState;
    public LayerMask layerMask;

    private Vector3 _startPos;
    private Transform _chasing;
    
    public enum State
    {
        Chase,
        Attack,
        Search,
    }
    public void Start()
    {
        _moveController = GetComponent<MoveController>();
        _startPos = transform.position;
        shoot = GetComponentInChildren<ShootProjectile>();
    }

    public void FixedUpdate()
    {
        switch (currentState)
        {
            case State.Chase: 
                Chase();
                Attack();
                break;
            case State.Attack:
                Attack();
                break;
            case State.Search: 
                Search();
                break;
            
        }
    }

    public void Attack()
    {
        shoot.TryShoot();
        if (Vector3.Distance(transform.position, _chasing.position) > stopRange)
        {
            currentState = State.Chase;
            return;
        }
    }



    public void Chase()
    {
        if (MoveTowards(_chasing.position))
        {
            currentState = State.Attack;
            return;
        }

        if (Vector3.Distance(transform.position, _chasing.position) > viewRange)
        {
            currentState = State.Search;
            return;
        }
    }

    public void Search()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position,viewRange,Vector2.zero,1,layerMask,-10,10);
        if (hit)//if you find someone
        {
            _chasing = hit.transform;
            currentState = State.Chase;
        }
        else
        {
            MoveTowards(_startPos, stopRange +1);
        }


    }
    
    public bool MoveTowards(Vector3 moveTo) {//returns true if your within stopRange of target
        return MoveTowards(moveTo, stopRange);
    }

    public bool MoveTowards(Vector3 moveTo, float stopRange)
    {
        if (moveTo.x + stopRange < transform.position.x)//to the left
        {
            _moveController.SetInputs(-1,0);
            return false;
        }
        else if (moveTo.x - stopRange > transform.position.x)//to the left
        {
            _moveController.SetInputs(1,0);
            return false;
        }
        else
        {
            _moveController.SetInputs(0,0);
            return true;
        }
    }

}
