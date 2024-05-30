using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    Rigidbody rb;
    private float movespeed;
    private float minX;
    private float maxX;

    private bool movingRight;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        movespeed = 0.1f;
        minX = -24.0f;
        maxX = 40.0f;
        movingRight = true;
    }

    private void Update()
    {
        Moving();
    }

    public Vector3 Moving() 
    {
        if (movingRight)
        {
            transform.Translate(Vector3.left * movespeed * Time.deltaTime);
            if (transform.position.x > maxX)
            {
                movingRight = false;
            }
        }
        else
        {
            transform.Translate(Vector3.right * movespeed * Time.deltaTime);
            if (transform.position.x < minX)
            {
                movingRight = true;
            }
        }
        return transform.position;
    }
}
