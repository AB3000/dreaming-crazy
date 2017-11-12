using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {

	public GameObject textBox;
	public Text theText;

	public TextAsset textFile;//textasset = block of text
	public string[] textLines;

	public int currentLine; 
	public int endAtLine; 

	public AndroControl player;

	public bool isActive;

	public bool stopPlayerMovement; 
	// Use this for initialization
	void Start () {

		player = FindObjectOfType<AndroControl> ();
		if (textFile != null) {
			textLines = (textFile.text.Split('\n'));
		}

		//can break up dialogue with this code!
		if (endAtLine == 0) {
			endAtLine = textLines.Length - 1; 
		}


		if (isActive) {
			EnableTextBox ();
		} else {
			DisableTextBox ();
		}
	}

	void Update() {
		if (!isActive) {
			return;
		}
		theText.text = textLines[currentLine]; 

		if (Input.GetKeyDown (KeyCode.Return)) {
			currentLine++;
		}

		if (currentLine > endAtLine) {
			DisableTextBox ();
		}
			
	}

	public void EnableTextBox(){
		textBox.SetActive (true);
		isActive = true;
	//	stopPlayerMovement = true;
	 if (stopPlayerMovement) {
			player.CanMove = false;
		}
	}

	public void DisableTextBox(){
		textBox.SetActive (false);
		isActive = false;
	//	stopPlayerMovement = false;
		player.CanMove = true;
	}

	public void ReloadScript(TextAsset theText){
		if (theText != null) {
			textLines = new string[1];
			textLines = (theText.text.Split('\n'));

		}
		
	}

}
