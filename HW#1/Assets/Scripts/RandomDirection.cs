using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomDirection : MonoBehaviour
{
    [SerializeField] private float _min = -10f;
    [SerializeField] private float _max = 10f;

    private Vector3 RandomVector(float min, float max) {
        var x = Random.Range(min, max);
        var y = Random.Range(min, max);
        var z = Random.Range(min, max);
        return new Vector3(x, y, z);
    }

    private void OnCollisionEnter(Collision other)
    {
        var rb = GetComponent<Rigidbody>();

        rb.velocity = RandomVector(_min, _max);
    }

}


