using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour {

	Transform cameraTransform;
	InputAction moveAction;
	InputAction interactAction;
	float ySpeed;
	Interactable currentInteractable;

	public CharacterController controller;
	public PlayerInput input;

	public float speed = 7f;
	public float gravity = 9.8f;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		moveAction = input.currentActionMap.FindAction("Move");
		interactAction = input.currentActionMap.FindAction("Interact");
		//C# event
		interactAction.performed += OnInteractAction;

		cameraTransform = FindAnyObjectByType<CameraManager>().activeCamera.transform;
	}

	private void OnDestroy() {
		interactAction.performed -= OnInteractAction;
	}

	private void OnInteractAction(InputAction.CallbackContext obj) {
		if(currentInteractable != null){
			currentInteractable.Interact();
		}
	}

	// Update is called once per frame
	void Update() {
		if(moveAction.WasPressedThisFrame()) {
			//FindAny/FindFirst -> die gesamte Scene nach einem bestimmten Component suchen
			cameraTransform = FindAnyObjectByType<CameraManager>().activeCamera.transform;
		}


		Vector2 moveInput = moveAction.ReadValue<Vector2>();

		Vector3 forward = Vector3.ProjectOnPlane(cameraTransform.forward, Vector3.up).normalized;
		Vector3 right = Vector3.ProjectOnPlane(cameraTransform.right, Vector3.up).normalized;

		//wie viel auf forward + wie viel auf right
		Vector3 move = forward * moveInput.y + right * moveInput.x;

		if(move != Vector3.zero) {
			//Slerp = Spherical Interpolation
			transform.forward = Vector3.Slerp(transform.forward, move, 0.1f);
		}

		CollisionFlags collision = controller.Move(move * Time.deltaTime * speed);
		if(collision != CollisionFlags.Below) {
			ySpeed += gravity * Time.deltaTime;
			controller.Move(Vector3.down * ySpeed * Time.deltaTime);
		} else {
			ySpeed = 0;
		}


		//if(interactAction.WasPressedThisFrame() && currentInteractable != null){
		//}
	}

	private void OnTriggerEnter(Collider other) {
		Interactable interactable = other.GetComponent<Interactable>();
		//wenn 'other' kein Interactable Component hat, ist das Ergebnis 'null'
		if(interactable != null){
			currentInteractable = interactable;
		}
	}

	private void OnTriggerExit(Collider other) {
		Interactable interactable = other.GetComponent<Interactable>();
		if(interactable != null){
			currentInteractable = null;
		}
	}
}
