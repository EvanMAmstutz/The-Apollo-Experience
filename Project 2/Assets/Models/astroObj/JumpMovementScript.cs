using UnityEngine;
using System.Collections;

public class JumpMovementScript : MonoBehaviour 
{
	public bool shouldBeJumping = true;    ///gives you control in inspector to trigger it or not

	public float delta = 0.5f;  // Amount to move left and right from the start point
	public float speed = 2.0f; 
	private Vector3 startPos;

	void Start()
	{ 
		startPos = transform.position;
	}
	void Update()
	{

		if (shouldBeJumping) {
			Vector3 v = startPos;
			Vector3 currentV = this.transform.position;
			v.y += delta / 2 + delta / 2 * Mathf.Sin (Time.time * speed);
			v.x = currentV.x;
			v.z = currentV.z;
			transform.position = v;
		}
	}
}
