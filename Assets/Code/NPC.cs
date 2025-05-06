using UnityEngine;

public class NPC : MonoBehaviour {

	public DialogLine dialog;
	public DialogScreen dialogScreen;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
	}

	public void StartDialog(){
		//dialogscreen den Dialog geben (anzeigen)
		dialogScreen.ShowDialog(dialog, this);
	}
}
