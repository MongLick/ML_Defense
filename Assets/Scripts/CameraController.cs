using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
	[SerializeField] float moveSpeed;
	[SerializeField] float padding;
	[SerializeField] float zoomSpeed;

	private Vector3 moveDir;

	private void OnMove(InputValue value)
	{
		Vector2 inpuit = value.Get<Vector2>();
		moveDir.x = inpuit.x;
		moveDir.z = inpuit.y;
	}

	private void OnPointer(InputValue value)
	{
		Vector2 input = value.Get<Vector2>();
		
		if(input.x < padding)
		{
			moveDir.x = -1;
		}
		else if(input.x > Screen.width - padding)
		{
			moveDir.x = 1;
		}
		else
		{
			moveDir.x = 0;
		}

		if(input.y < padding)
		{
			moveDir.z = -1;
		}
		else if(input.y > Screen.height - padding)
		{
			moveDir.z = 1;
		}
		else
		{
			moveDir.z = 0;
		}
	}

	private void OnZoom(InputValue value)
	{
		Vector2 scrollInput = value.Get<Vector2>();

		float scrollAmount = scrollInput.y;
		Vector3 moveDir = Vector3.forward * scrollAmount;

		transform.Translate(moveDir * zoomSpeed * Time.deltaTime, Space.Self);
	}

	private void Move()
	{
		transform.Translate(moveDir * moveSpeed * Time.deltaTime, Space.World);
	}

	private void Update()
	{
		Move();
	}

	private void OnEnable()
	{
		Cursor.lockState = CursorLockMode.Confined;
	}

	private void OnDisable()
	{
		Cursor.lockState = CursorLockMode.None;
	}
}
