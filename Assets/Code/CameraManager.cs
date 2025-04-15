using Unity.Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour {

	public CinemachineCamera activeCamera;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {

	}

	public void ActivateCamera(CinemachineCamera camera){
		activeCamera.gameObject.SetActive(false);
		
		camera.gameObject.SetActive(true);

		activeCamera = camera;
	}

}
