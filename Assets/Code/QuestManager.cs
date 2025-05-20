using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class QuestManager : MonoBehaviour {

	public TextMeshProUGUI objectiveText;
	public GameObject questScreen;
	public GameObject dialogScreen;

	[Header("Quest 1")]
	public Interactable mario;
	public Interactable key;
	public DialogLine dialog2;

	[Header("Quest 2")]
	public DialogLine dialog3;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {
		StartCoroutine(StartQuest1());
	}

	private IEnumerator StartQuest1() {

		yield return WaitForInteractable(mario);
		yield return new WaitUntil(()=>dialogScreen.activeSelf == false);
		objectiveText.text = "Hol den Schlüssel";
		questScreen.SetActive(true);
		key.gameObject.SetActive(true);

		yield return WaitForInteractable(key);
		objectiveText.text = "Geh zurück zu Mario";
		mario.GetComponent<NPC>().dialog = dialog2;
		key.gameObject.SetActive(false);

		yield return WaitForInteractable(mario);
		questScreen.SetActive(false);
	}

	private IEnumerator WaitForInteractable(Interactable interactable) {
		bool talked = false;
		//anonymous function - Funktion ohne Name. Die ist lokal
		UnityAction action = () => {
			talked = true;
		};
		interactable.OnInteract.AddListener(action);
		yield return new WaitUntil(() => talked); //anonyme Funktion, die 'talked' zurückgibt (denn es muss ein bool zurückgeben)
		interactable.OnInteract.RemoveListener(action);
	}

	private IEnumerator WaitForInteractableCounter(List<Interactable> interactable, int count) {
		int counter = 0;
		//anonymous function - Funktion ohne Name. Die ist lokal
		UnityAction action = () => {
			counter++;
		};
		for(int i = 0; i < interactable.Count; i++) {
			interactable[i].OnInteract.AddListener(action);
		}

		yield return new WaitUntil(() => counter >= count); //anonyme Funktion, die 'talked' zurückgibt (denn es muss ein bool zurückgeben)
		
		for(int i = 0; i < interactable.Count; i++) {
			interactable[i].OnInteract.RemoveListener(action);
		}
	}


}
