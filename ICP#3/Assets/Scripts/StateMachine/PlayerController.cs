using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	private CapsuleCollider capsuleCollider;
	private Rigidbody rb;

	public float acceleration;
	public float jumpForce;

	private float currentSpeed;

	public Transform followCamera;

	[HideInInspector]
	public float forwardInput = 0;
	[HideInInspector]
	public float horizontalInput = 0;

	[SerializeField]
	private Transform SpawnPosition;

	// Start is called before the first frame update
	void Start()
	{
		capsuleCollider = GetComponent<CapsuleCollider>();
		rb = GetComponent<Rigidbody>();
		currentSpeed = 100.0f;
	}

	// Update is called once per frame
	void Update()
	{
		forwardInput = Input.GetAxis("Vertical");
		horizontalInput = Input.GetAxis("Horizontal");

		if (Input.GetKeyDown(KeyCode.R))
		{
			transform.position = SpawnPosition.position;
			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
		}
	}

	public void Move()
	{
		Vector3 movedir = new Vector3(horizontalInput, 0, forwardInput);
		
		movedir.Normalize();

		Vector3 vel = ((followCamera.forward * forwardInput * acceleration) + (followCamera.right * horizontalInput * acceleration)) * currentSpeed / 100.0f;
		rb.velocity = new Vector3(vel.x, rb.velocity.y, vel.z);

		if (movedir != Vector3.zero)
		{
			transform.rotation = Quaternion.LookRotation(new Vector3(rb.velocity.x, 0, rb.velocity.z));
		}

		WallCheck();
	}

	//https://forum.unity.com/threads/object-wont-fall-when-i-apply-horizontal-velocity-and-is-colliding-with-wall.143698/#post-983138
	public void WallCheck()
	{
		// Get the velocity
		Vector3 horizontalMagnitude = rb.velocity;
		// Don't use the vertical velocity
		horizontalMagnitude.y = 0;
		// Calculate the approximate distance that will be traversed
		float distance = horizontalMagnitude.magnitude * Time.fixedDeltaTime;
		// Normalize horizontalMove since it should be used to indicate direction
		horizontalMagnitude.Normalize();
		RaycastHit hit;

		// Check if the body's current velocity will result in a collision
		if (rb.SweepTest(horizontalMagnitude, out hit, distance))
		{
			// If so, stop the movement
			if (Vector3.Angle(hit.normal, Vector3.up) > 60f && (hit.collider.gameObject.layer == LayerMask.NameToLayer("Default")))
				rb.velocity = new Vector3(0, rb.velocity.y, 0);
		}
	}


	//completely pointless, only used to enable bunnyhopping
	public void ApplySlowdown()
	{
		StartCoroutine(CheckBhop());
	}

	//completely pointless, only used to enable bunnyhopping
	public IEnumerator CheckBhop()
	{
		yield return new WaitForSeconds(0.25f);
		if (IsGrounded() || rb.velocity.y < 0)
			currentSpeed = 100.0f;
		else
			currentSpeed = Mathf.Clamp(currentSpeed + 15f, 100.0f, 225.0f);
		yield break;
	}

	public void Jump()
	{
		rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
		rb.AddForce(new Vector3(0, jumpForce, 0));
	}

	public void AddGravity(float force)
	{
		rb.AddForce(new Vector3(0, -force, 0));
	}

	public bool IsGrounded()
	{
		return Physics.CheckCapsule(capsuleCollider.bounds.center, new Vector3(capsuleCollider.bounds.center.x, capsuleCollider.bounds.min.y - 0.02f, capsuleCollider.bounds.center.z), 0.05f, LayerMask.GetMask("Default"));
	}

	//converts velocity vector to 2D, then gets its x, which is actually x and z velocities added together.
	public float GetVerticalVelocity()
	{
		return rb.velocity.y;
	}

}
