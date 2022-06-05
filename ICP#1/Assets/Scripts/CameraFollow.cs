using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	[SerializeField]
    private Transform playerTransform;
    private Vector3 offset;

	private void Start()
	{
		offset = transform.position - playerTransform.position;
	}

	// Update is called once per frame
	void Update()
    {
		if (!playerTransform) return;
		transform.position = playerTransform.position + offset;
    }
}
