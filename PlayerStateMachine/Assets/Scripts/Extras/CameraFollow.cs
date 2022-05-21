using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[SerializeField]
    private Transform playerTransform;
	[SerializeField]
	private float mouseSensitivity;
	private Vector3 offset;

	//Note: Don't bother with vector rotation for rotatable cameras, use an r-theta polar coordinate system
	private void Start()
	{
		offset = transform.position - playerTransform.position;
	}

	// Update is called once per frame
	void LateUpdate()
    {
		if (!playerTransform) return;
		offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * mouseSensitivity, Vector3.up) * offset;
		transform.position = playerTransform.position + offset;
		transform.LookAt(playerTransform.position);
	}
}
