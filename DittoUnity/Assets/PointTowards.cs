using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointTowards : MonoBehaviour
{

    private Transform _trans;
    public bool pointTowardsMouse;
    public Transform pointTowardsTrans;
    
    private Vector3 _pointTowards;
    private Vector3 _dir;

    private Camera _mainCam;

    void Start()
    {
        _trans = GetComponent<Transform>();
        _mainCam = Camera.main;
    }

    void Update()
    {
        if (pointTowardsMouse)
        {
            _pointTowards = _mainCam.ScreenToWorldPoint(Input.mousePosition);
            _pointTowards.z = _trans.position.z;
        }
        else
        {
            _pointTowards = pointTowardsTrans.position;
        }
        
        _dir = _pointTowards - _trans.position;
        if (_dir.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            _trans.right = -_dir;
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            _trans.right = _dir;
        }

        
    }
}
