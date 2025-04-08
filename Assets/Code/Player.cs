using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {

	InputAction moveAction;

	public CharacterController controller;
	public PlayerInput input;

	public float speed = 7f;

	public blabla b;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		moveAction = input.currentActionMap.FindAction("Move");
		b.einbool = true;
	}

	// Update is called once per frame
	void Update() {
		Vector2 moveInput = moveAction.ReadValue<Vector2>();
		Vector3 direction = new(moveInput.x, 0, moveInput.y);
		Vector3 move = Camera.main.transform.TransformDirection(direction);
		move.y = 0;
		move.Normalize();

		controller.Move(move * Time.deltaTime * speed);
	}
}
