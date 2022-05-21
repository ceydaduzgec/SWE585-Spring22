using System;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float _forceAmount = 100f; 
    [SerializeField] private float _speed = .1f;

    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // If click right mouse button then jump the object
        if(Input.GetButtonDown("Fire1"))
        {
            rb.AddForce(Vector3.up * _forceAmount);
        }

        // Move object on x and z axis based on the input button
        // input buttons are either WASD or up, righ, left down arrow buttons
        Vector3 moveDirection  = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        rb.MovePosition(transform.position + (moveDirection * _speed * Time.deltaTime));
        

        // physics dont apply to transform
        //transform.position += moveDirection * _speed;
    }
}
