using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class DialogScreen : MonoBehaviour {

	DialogLine currentDialog;
	NPC currentNPC;
	Coroutine typewriter;

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

		

		textCharName.text = npc.name;
		imagePortrait.sprite = dialog.portrait;

		for(int i = 0; i < choiceButtons.Length; i++) {
			choiceButtons[i].gameObject.SetActive(false);
		}

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

		//Entweder oder
		//StopAllCoroutines();
		if(typewriter != null)
			StopCoroutine(typewriter);

		typewriter = StartCoroutine(TypewriterCoroutine(dialog.text));

		input.SwitchCurrentActionMap("UI");
	}

	IEnumerator TypewriterCoroutine(string text){
		textDialog.text = text;
		textDialog.maxVisibleCharacters = 0;

		for(int i = 0; i < text.Length; i++) {
			//nicht-optimal
			//textDialog.text = text.Substring(0, i);
			textDialog.maxVisibleCharacters = i;
			yield return new WaitForSeconds(0.01f);
		}
		textDialog.maxVisibleCharacters = 9999999;



	}





	public void EndDialog() {
		gameObject.SetActive(false);

		
		continueButton.gameObject.SetActive(false);

		input.SwitchCurrentActionMap("Player");
	}

	public void Continue() {
		if(currentDialog.defaultNextLine != null) {
			ShowDialog(currentDialog.defaultNextLine, currentNPC);
		} else {
			EndDialog();
		}
	}

	public void SelectChoice(int index) {
		currentDialog.choices[index].onSelected.Invoke();
		ShowDialog(currentDialog.choices[index].nextLine, currentNPC);
	}

}
