using UnityEngine;

public class Camfollow : MonoBehaviour
{
	public Transform target;
	public Vector3 locationOffset;
	public Vector3 rotationOffset;
	private Vector3 lastMousePosition;

	public float followDistance = 5f;
	public float followSpeed = 1f;
	public float rotationSpeed = 1f; // Prêdkoœæ obrotu kamery
	private bool isRotating = false;

	private void FixedUpdate()
	{
		HandleCameraRotation();
		HandleMovement();
	}

	private void HandleCameraRotation()
	{
		if (Input.GetMouseButton(2))
		{
			isRotating = true;
		}
		else
		{
			isRotating = false;
		}

		if (isRotating)
		{
			var currentMousePosition = Input.mousePosition;
			var mouseDelta = currentMousePosition - lastMousePosition;

			var (rotationX, rotationY) = GetRotations(mouseDelta);

			transform.RotateAround(target.position, Vector3.up, rotationY * rotationSpeed);
			transform.RotateAround(target.position, transform.right, rotationX * rotationSpeed);

			lastMousePosition = currentMousePosition;
		}
	}

	private (float, float) GetRotations(Vector3 mouseDelta)
	{
		float rotationX = mouseDelta.y;
		float rotationY = -mouseDelta.x;
		return (rotationX, rotationY);
	}

	private void HandleMovement()
	{
		var targetPosition = target.position - transform.forward * followDistance;
		transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);
		transform.LookAt(target);
	}
}
