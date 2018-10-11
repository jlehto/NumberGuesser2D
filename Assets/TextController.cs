using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {
	public Text objText;
	public Text objTries;
	int intRandomNumber;
	int intGuessedNumber;
	int intNumberOfTries;

	// Use this for initialization
	void Start () {
		InitGame ();
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			InitGame ();
		}	
		if (Input.anyKeyDown) {
			if (int.TryParse (Input.inputString, out intGuessedNumber)) {
				intNumberOfTries++;
				string str;
				if (intRandomNumber < intGuessedNumber) {
					str = "too high";
				} else if (intRandomNumber > intGuessedNumber) {
					str = "too low";
				} else {
					str = "correct! Press spacebar to restart";
				}	
				objTries.text = string.Format ("Number of tries : {0}", intNumberOfTries);
				objText.text = string.Format ("You guessed {0}. That is " + str + ".", intGuessedNumber);
			}
		}	
	}

	private void InitGame() {
		intRandomNumber = Random.Range (1, 10);
		intNumberOfTries = 0;
		objTries.text = "Let's play!";
		objText.text = "Guess a number between 1 and 10";
	}	
}
