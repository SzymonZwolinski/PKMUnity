using UnityEngine;

public class Movement : MonoBehaviour
{
	private CharacterController controller;
	private Vector3 playerVelocity;
	private bool groundedPlayer;
	private float playerSpeed = 2.0f;
	private float sprintMultiplier = 3.0f; // Mno¿nik przyœpieszenia
	private float jumpHeight = 1.0f;
	private float gravityValue = -9.81f;

	private Transform mainCameraTransform; // Transform kamery
	private Vector3 initialCameraForward; // Pocz¹tkowy wektor kierunku kamery

	private void Start()
	{
		controller = GetComponent<CharacterController>();
		mainCameraTransform = Camera.main.transform;
		initialCameraForward = mainCameraTransform.forward;
	}

	private void FixedUpdate()
	{
		HandleMovement();
	}

	private void HandleMovement()
	{
		groundedPlayer = controller.isGrounded;
		if (groundedPlayer && playerVelocity.y < 0)
		{
			playerVelocity.y = 0f;
		}

		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

		move = Quaternion.LookRotation(initialCameraForward) * move; // Transformacja wektora ruchu wzglêdem kierunku kamery

		float currentSpeed = playerSpeed;
		if (Input.GetKey(KeyCode.LeftShift))
		{
			currentSpeed *= sprintMultiplier; // Przyœpieszenie przy wciœniêtym lewym Shift
		}

		controller.Move(move * Time.deltaTime * currentSpeed);

		if (move != Vector3.zero)
		{
			gameObject.transform.forward = move;
		}

		// Zmiana wysokoœci gracza
		if (Input.GetButtonDown("Jump") && groundedPlayer)
		{
			playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
		}

		playerVelocity.y += gravityValue * Time.deltaTime;
		controller.Move(playerVelocity * Time.deltaTime);
	}
}
