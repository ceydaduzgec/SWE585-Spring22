using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushLeft : MonoBehaviour
{
    [SerializeField] private float _forceAmount = 100f; 

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {
         _rigidbody.AddForce(Vector3.left * _forceAmount);
    }
}

