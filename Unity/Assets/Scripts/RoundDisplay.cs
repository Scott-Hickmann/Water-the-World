using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoundDisplay : MonoBehaviour {

	Text roundText;

	void Awake () {
		roundText = GetComponent <Text> ();
	}

	void Update () {
		roundText.text = "Round: " + GenerateHumans.round;
	}
}
