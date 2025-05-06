using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogScreen : MonoBehaviour {

	DialogLine currentDialog;
	NPC currentNPC;

	public TextMeshProUGUI textDialog;
	public TextMeshProUGUI textCharName;
	public Image imagePortrait;
	public Button[] choiceButtons;
	public Button continueButton;

	public PlayerInput input;

	private void Start() {
		gameObject.SetActive(false);
	}

	public void ShowDialog(DialogLine dialog, NPC npc) {
		currentDialog = dialog;
		currentNPC = npc;

		textDialog.text = dialog.text;
		textCharName.text = npc.name;
		imagePortrait.sprite = dialog.portrait;

		if(dialog.choices != null && dialog.choices.Length > 0) {
			for(int i = 0; i < dialog.choices.Length; i++) {
				choiceButtons[i].gameObject.SetActive(true);
				choiceButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = dialog.choices[i].name;
				//choiceButtons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = dialog.choices[i].name;
			}
			EventSystem.current.SetSelectedGameObject(choiceButtons[0].gameObject);
		} else {
			continueButton.gameObject.SetActive(true);
			for(int i = 0; i < choiceButtons.Length; i++) {
				choiceButtons[i].gameObject.SetActive(false);
			}
			
			EventSystem.current.SetSelectedGameObject(continueButton.gameObject);
		}

		gameObject.SetActive(true);

		input.SwitchCurrentActionMap("UI");
	}

	public void EndDialog() {
		gameObject.SetActive(false);

		for(int i = 0; i < choiceButtons.Length; i++) {
			choiceButtons[i].gameObject.SetActive(false);
		}
		continueButton.gameObject.SetActive(false);

		input.SwitchCurrentActionMap("Player");
	}

	public void SelectChoice(int index) {
		ShowDialog(currentDialog.choices[index].nextLine, currentNPC);
	}

}
