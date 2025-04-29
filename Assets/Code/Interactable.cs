using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour {

	//C# Event
	//public event System.Action OnInteractCS;

	//Unity Event
	public UnityEvent OnInteract;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		/* event beispiel
		//OnInteractCS += blabla;
		//OnInteractCS -= blabla;
		//if(OnInteractCS != null)
		//	OnInteractCS.Invoke(); //invoke = ausführen

		//OnInteract.AddListener(blabla);
		//OnInteract.RemoveListener(blabla);
		//OnInteract.Invoke();

		//void blabla() {
		//}
		*/
	}


	public void Interact(){
		OnInteract.Invoke();
	}
	
}
