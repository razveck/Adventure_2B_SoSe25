using UnityEngine;

public class DialogLine : MonoBehaviour {
	[Multiline(10)]
	public string text;
	public Sprite portrait;
	public DialogChoice[] choices;
	public DialogLine defaultNextLine;
}
