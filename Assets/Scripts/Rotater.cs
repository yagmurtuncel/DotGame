using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    private Vector2 _centre;
    private float _angle;

    private float RotateSpeed = 2f;
    private float Radius = 9f;


    private void Start()
    {
        _centre = transform.position;
    }

    private void Update()
    {

        _angle += RotateSpeed * Time.deltaTime;

        var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
        transform.position = _centre + offset;

        if(_angle >=9f)
        {
            Radius = -9f;
        }
    }




}
