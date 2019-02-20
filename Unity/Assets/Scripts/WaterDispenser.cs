using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDispenser : MonoBehaviour {

	public int[] prices;
	public int[] givingAmounts;
	public Sprite[] sprites;
	private int level = 0;
	public float delay;
	public List<GameObject> humansInTarget = new List<GameObject>();

	// Use this for initialization
	void Start () {
		if (ScoreManager.water >= prices [level]) {
			ScoreManager.water -= prices [level];
		} else {
			Destroy (gameObject);
		}
		StartCoroutine (GiveWater());
	}

	IEnumerator GiveWater () {
		while (true) {
			yield return new WaitUntil(() => humansInTarget.Count > 0);
			for (int i = humansInTarget.Count - 1; i >= 0; i--) {
				if (humansInTarget.Count > 0) {
					if (humansInTarget [i].tag == "Human") {
						if (ScoreManager.water >= givingAmounts [level]) {
							ScoreManager.water -= givingAmounts [level];
							if (humansInTarget [i].GetComponent<Human> ().GiveWater (givingAmounts [level])) {
								humansInTarget.Remove (humansInTarget [i]);
							}
						}
					}
					yield return new WaitForSeconds (delay);
				}
			}
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
