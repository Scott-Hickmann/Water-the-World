using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Well : MonoBehaviour {

	public int[] prices;
	public int[] storingAmounts;
	public Sprite[] sprites;
	private int level = 0;
	private int currentStoringAmount;

	// Use this for initialization
	void Start () {
		if (ScoreManager.water >= prices [level]) {
			ScoreManager.water -= prices [level];
		} else {
			Destroy (gameObject);
		}
		ScoreManager.maxWater += storingAmounts [level];
		currentStoringAmount = storingAmounts [level];
	}

	// Upgrade
	private bool clicked = false;
	void OnMouseOver () {
		if (Input.GetMouseButton (1) && !clicked) {
			if (level < prices.Length - 1) {
				if (ScoreManager.water >= prices [level + 1]) {
					level += 1;
					ScoreManager.water -= prices [level];
					ScoreManager.maxWater += storingAmounts [level] - currentStoringAmount;
					currentStoringAmount = storingAmounts [level];
					this.GetComponent<SpriteRenderer> ().sprite = sprites [level];
					Debug.Log (level);
					clicked = true;
				}
			}
		}
		if (!Input.GetMouseButton (1)) {
			clicked = false;
		}
	}
}
