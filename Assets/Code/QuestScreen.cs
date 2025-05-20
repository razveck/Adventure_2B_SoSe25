using TMPro;
using UnityEngine;

public class QuestScreen : MonoBehaviour {
	Quest currentQuest;

	public TextMeshProUGUI objectiveText;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start() {

	}

	public void StartQuest(Quest quest) {
		if(quest.isCompleted) {
			return; //Funktion abbrechen
		}

		currentQuest = quest;

		objectiveText.text = quest.objective;
		gameObject.SetActive(true);
	}

	public void EndQuest(Quest quest){
		if(quest != currentQuest){
			return;
		}

		currentQuest.isCompleted = true;

		if(currentQuest.nextQuest != null){
			StartQuest(currentQuest.nextQuest);
		} else {
			gameObject.SetActive(false);
		}
	}
}
