using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCircle : MonoBehaviour
{
	[SerializeField]
	private Transform Torus;

	public float speed;

    // Update is called once per frame
    void Update()
    {
		transform.Rotate(new Vector3(0, speed / 8, 0));
		Torus.Rotate(new Vector3(speed/2, speed/2, speed/2));
    }
}
