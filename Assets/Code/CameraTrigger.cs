using Unity.Cinemachine;
using UnityEngine;

public class CameraTrigger : MonoBehaviour {

	public CameraManager cameraManager;
	public CinemachineCamera camera;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {

	}

	private void OnTriggerEnter(Collider other) {
		cameraManager.ActivateCamera(camera);
	}
}
