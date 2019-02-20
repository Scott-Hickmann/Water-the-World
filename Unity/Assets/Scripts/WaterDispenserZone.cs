using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDispenserZone : MonoBehaviour {

	public GameObject waterDispenser;

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Human") {
			waterDispenser.GetComponent<WaterDispenser> ().humansInTarget.Add (other.gameObject);
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		if (other.tag == "Human") {
			waterDispenser.GetComponent<WaterDispenser> ().humansInTarget.Remove (other.gameObject);
		}
	}
}
