using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public int waterAmount;
	public static int water;
	public int maxWaterAmount;
	public static int maxWater;

	Text waterText;

	void Awake () {
		waterText = GetComponent <Text> ();
		water = waterAmount;
		maxWater = maxWaterAmount;
	}
		
	void Update () {
		waterText.text = "Water: " + water + " L";
	}
}