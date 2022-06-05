using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public class CubeScript : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("isLocalPlayer: " + isLocalPlayer);

        if (isLocalPlayer)
        {
            Move();
        }
    }

    void Move()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Move");
            transform.position += new Vector3(0, 0.1f, 0);
        }
    }
}
