﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;

[RequireComponent(typeof(RigidbodyFirstPersonController))]
public class FlyingRigidbodyFirstPersonController : MonoBehaviour {

	private new Rigidbody rigidbody;
	private RigidbodyFirstPersonController rigidbodyFPC;
	private HeadBob headBob;

	public bool flying = false;
	public float flyingDrag = 5f;
	public float flightToggleTimeThreshold = 0.5f;
	private float lastAscendKeyHit = float.MinValue;

	void Start()
    {
		Cursor.lockState = CursorLockMode.None;
		Cursor.visible = true;
	}

	void Awake()
	{
		rigidbody = GetComponent<Rigidbody> ();
		rigidbodyFPC = GetComponent<RigidbodyFirstPersonController> ();
		headBob = GetComponentInChildren<HeadBob> ();
	}

	void Update ()
	{
		if (AscendKeyDoubleHit())
		{
			flying = !flying;
			rigidbody.useGravity = !flying;
			rigidbodyFPC.enabled = !flying;
			headBob.enabled = !flying;

			if (flying)
			{
				rigidbody.drag = flyingDrag;
			}
		}
		 
		if (flying)
		{
			rigidbodyFPC.mouseLook.LookRotation (transform, rigidbodyFPC.cam.transform);
		}
	}
	
	void FixedUpdate()
	{
		if (flying)
		{
			Vector2 input = GetInput();
			Vector3 verticalInput = Vector3.up * ((CrossPlatformInputManager.GetButton("Jump") ? 1f : 0f) - (CrossPlatformInputManager.GetButton("Crouch") ? 1f : 0f));

			if ((Mathf.Abs(input.x) > float.Epsilon || Mathf.Abs(input.y) > float.Epsilon) || Mathf.Abs(verticalInput.y) > float.Epsilon)
			{
				Vector3 desiredMove = rigidbodyFPC.cam.transform.forward*input.y + rigidbodyFPC.cam.transform.right*input.x;
				desiredMove += verticalInput;
				desiredMove = desiredMove.normalized*rigidbodyFPC.movementSettings.CurrentTargetSpeed;
				if (rigidbodyFPC.Velocity.sqrMagnitude <
				    (rigidbodyFPC.movementSettings.CurrentTargetSpeed*rigidbodyFPC.movementSettings.CurrentTargetSpeed))
				{
					rigidbody.AddForce(desiredMove, ForceMode.Impulse);
				}
			}
		}
	}

	private Vector2 GetInput()
	{
		Vector2 input = new Vector2
		{
			x = CrossPlatformInputManager.GetAxis("Horizontal"),
			y = CrossPlatformInputManager.GetAxis("Vertical")
		};
		rigidbodyFPC.movementSettings.UpdateDesiredTargetSpeed(input);
		return input;

	}

	private bool AscendKeyDoubleHit()
	{
		bool result = false;
		if (CrossPlatformInputManager.GetButtonDown("Jump"))
		{
			result = Time.time - lastAscendKeyHit < flightToggleTimeThreshold;
			lastAscendKeyHit = Time.time;
		}
		return result;
	}
}
