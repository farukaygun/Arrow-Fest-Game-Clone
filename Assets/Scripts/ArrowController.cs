using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ArrowController : MonoBehaviour
{
	private Rigidbody rb;

	[SerializeField] private float speed = 8f;
	[SerializeField] private InputAction movementInput;

	private float horizontal;

	private void Start() {
		rb = GetComponent<Rigidbody>();	
	}

	private void OnEnable() {
		movementInput.Enable();
	}

	private void OnDisable() {
		movementInput.Disable();
	}

	private void Update() {
		GetInput();
	}

	private void FixedUpdate() {
		Move();
	}

	private void GetInput() {
		horizontal = movementInput.ReadValue<Vector2>().x;
	}

	private void Move() {
		Vector3 localHorizontalVector = transform.right * horizontal;
		Vector3 localVerticalVector = transform.forward;

		Vector3 movementVector = localVerticalVector + localHorizontalVector;
		movementVector.Normalize();
		movementVector *= speed * Time.deltaTime * 100f;

		rb.velocity = movementVector;
	}
}
