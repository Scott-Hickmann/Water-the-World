using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScavenger : MonoBehaviour {

	public int[] prices;
	public int[] generatingAmounts;
	public Sprite[] sprites;
	private int level = 0;

	void Start () {
		if (ScoreManager.water >= prices [level]) {
			ScoreManager.water -= prices [level];
		} else {
			Destroy (gameObject);
		}
		StartCoroutine(Generate());
	}

	IEnumerator Generate() {
		yield return new WaitUntil(() => GenerateHumans.round == GenerateHumans.previousRound);
		while (true) {
			yield return new WaitUntil(() => GenerateHumans.round > GenerateHumans.previousRound);
			int amount = Random.Range (1, generatingAmounts [level]);
			Debug.Log (1);
			if (ScoreManager.water + amount <= ScoreManager.maxWater) {
				Debug.Log (2);
				ScoreManager.water += amount;
			} else {
				Debug.Log (3);
				ScoreManager.water = ScoreManager.maxWater;
			}
			yield return new WaitUntil(() => GenerateHumans.round == GenerateHumans.previousRound);
		}
	}

	// Upgrade
	private bool clicked = false;
	void OnMouseOver () {
		if (Input.GetMouseButton (1) && !clicked) {
			if (level < prices.Length - 1) {
				if (ScoreManager.water >= prices [level + 1]) {
					level += 1;
					ScoreManager.water -= prices [level];
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
