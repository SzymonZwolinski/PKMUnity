using UnityEngine;

public class Movement : MonoBehaviour
{
	private CharacterController controller;
	private Vector3 playerVelocity;
	private float playerSpeed = 2.0f;
	private float sprintMultiplier = 3.0f; // Mno¿nik przyœpieszenia


	private Transform mainCameraTransform; // Transform kamery
	private Vector3 initialCameraForward; // Pocz¹tkowy wektor kierunku kamery

	private bool IsMovementFrozen = false;

	private Animator playerAnimator;

	private void Start()
	{
		controller = GetComponent<CharacterController>();
		playerAnimator = GameObject.FindGameObjectWithTag("PlayerModel").GetComponentInChildren<Animator>();
		mainCameraTransform = Camera.main.transform;
		initialCameraForward = mainCameraTransform.forward;
	}

	private void FixedUpdate()
	{
		HandleMovement();
	}

	private void HandleMovement()
	{
		if (!IsMovementFrozen)
		{
			if (playerVelocity.y < 0)
			{
				playerVelocity.y = 0f;
			}

			Vector3 move = new Vector3(
				Input.GetAxis("Horizontal"),
				0,
				Input.GetAxis("Vertical"));

			move = Camera.main.transform.TransformDirection(move);
			move.y = 0;

			float currentSpeed = playerSpeed;
			if (Input.GetKey(KeyCode.LeftShift))
			{
				currentSpeed *= sprintMultiplier; 
			}

			controller.Move(move * Time.fixedDeltaTime * currentSpeed);

			float speed = controller.velocity.magnitude / currentSpeed;
			playerAnimator.SetFloat("Speed", speed);
		}
	}

	public void FreezeMovement()
	{
		IsMovementFrozen = true;
	}

	public void UnFreezeMovement()
	{
		IsMovementFrozen = false;
	}
}
