using UnityEngine;

public class Teleport : MonoBehaviour {
	public Transform teleportPoint;

	public static Vector3 position;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		//BEISPIEL!!!
		PlayerSpawner.position = new(10,10,10);
		Teleport.position = new(20,2,2);
	}

	// Update is called once per frame
	void Update() {

	}

	private void OnTriggerEnter(Collider other) {
		other.enabled = false;
		other.transform.position = teleportPoint.position;
		other.transform.rotation = teleportPoint.rotation;
		other.enabled = true;
	}
}
