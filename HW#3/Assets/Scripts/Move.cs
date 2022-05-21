using System;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float speed = 10f; 
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 moveDirection  = new Vector3(-Input.GetAxis("Vertical"), 0f, 0f);
        //rb.MovePosition(transform.position + (moveDirection  * _forceAmount * Time.deltaTime));
        rb.velocity = moveDirection * speed;
        
        if(this.transform.position.x <= -50 || this.transform.position.x >= 50 ) {
            Destroy(this.gameObject);
            FindObjectOfType<GameManager>().EndGame();
		}
    }
}
