using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
	[SerializeField]
	private float speed;

	[SerializeField]
	private Animator animator;

	void FixedUpdate () {
		// Horizontal movement.
		float newVelocityX = 0f;
		if (Input.GetKey (KeyCode.LeftArrow)) {
			newVelocityX = -speed;
			animator.SetInteger ("DirectionX", -1);
		} else if (Input.GetKey (KeyCode.RightArrow)) {
			newVelocityX = speed;
			animator.SetInteger ("DirectionX", 1);
		} else {
			newVelocityX = 0f;
			animator.SetInteger ("DirectionX", 0);
		}

		// Vertical movement.
		float newVelocityY = 0f;
		if (Input.GetKey (KeyCode.DownArrow)) {
			newVelocityY = -speed;
			animator.SetInteger ("DirectionY", -1);
		} else if (Input.GetKey (KeyCode.UpArrow)) {
			newVelocityY = speed;
			animator.SetInteger ("DirectionY", 1);
		} else {
			newVelocityY = 0f;
			animator.SetInteger ("DirectionY", 0);
		}

		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (newVelocityX, newVelocityY);
	}
}
