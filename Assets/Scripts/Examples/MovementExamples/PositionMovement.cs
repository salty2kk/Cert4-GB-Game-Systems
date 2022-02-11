using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionMovement : MonoBehaviour
{
    public float speed = 5f;


    void Update()
    {
        transform.position = transform.position + Vector3.forward * speed * Time.deltaTime;
    }
}

/*
Vector 3 defaults in Unity

v3.forward = 0, 0, 1
v3.back = 0, 0, -1
v3.up = 0, 1, 0
v3.down = 0, -1, 0
v3.right = 1, 0, 0
v3.left = -1, 0, 0
    


  */


