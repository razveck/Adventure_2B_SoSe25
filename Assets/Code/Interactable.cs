using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interactable : MonoBehaviour {

	List<Material> materials = new();

	//C# Event
	//public event System.Action OnInteractCS;

	//Unity Event
	public UnityEvent OnInteract;

	public Material highlightMaterial;
	public MeshRenderer meshRenderer;

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


	public void Interact() {
		OnInteract.Invoke();
	}

	public void SetHighlight(bool active) {
		if(active) {
			meshRenderer.GetMaterials(materials);
			materials.Add(highlightMaterial);
			meshRenderer.SetMaterials(materials);
		} else {
			meshRenderer.GetMaterials(materials);
			//materials.Remove(highlightMaterial);
			materials.RemoveAt(materials.Count - 1);
			meshRenderer.SetMaterials(materials);
		}
	}

}
