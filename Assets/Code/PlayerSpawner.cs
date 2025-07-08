using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawner : MonoBehaviour {

	public static Vector3 position;
	public static Quaternion rotation;


	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		//static
		position = transform.position;
		rotation = transform.rotation;
		rotation.SetLookRotation(transform.forward * -1);

		//DontDestroyOnLoad(this);
		//SceneManager.LoadScene("Level2", LoadSceneMode.Additive);

		//SceneManager.UnloadSceneAsync("Level2");
	}

	// Update is called once per frame
	void Update() {

	}
}
