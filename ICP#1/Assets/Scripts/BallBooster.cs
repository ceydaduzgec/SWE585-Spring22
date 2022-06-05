using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBooster : MonoBehaviour
{
    [SerializeField]
    private Vector3 direction = new Vector3(-5, 0, 0);
    private Vector3 startPos;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(direction);
    }
}
