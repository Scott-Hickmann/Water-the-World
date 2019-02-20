using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Human : MonoBehaviour {

	public int water;
	public Sprite satisfiedSprite;

	public bool GiveWater (int amount) {
		water -= amount;
		Debug.Log (water);
		if (water <= 0) {
			this.tag = "Satisfied Human";
			this.GetComponent<SpriteRenderer> ().sprite = satisfiedSprite;
			return true;
		}
		return false;
	}
}
