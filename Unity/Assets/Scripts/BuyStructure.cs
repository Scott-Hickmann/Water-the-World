using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyStructure : MonoBehaviour {

	private bool dragging = false;
	private bool place = true;
	private bool onMap = false;
	private float distance;
	private Transform clone;
	public GameObject structure;
	public int price;

	void OnTriggerEnter2D (Collider2D other) {
		if (other.name == "Path" || other.tag == "Structure") {
			place = false;
		}
		if (other.name == "Map") {
			onMap = true;
			Debug.Log ("On Map");
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		place = true;
		if (other.name == "Map") {
			onMap = false;
			Debug.Log ("Off Map");
		}
	}

	void OnMouseDown()
	{
		if (ScoreManager.water >= price) {
			if (place == true) {
				distance = Vector3.Distance (transform.position, Camera.main.transform.position);
				dragging = !dragging;
				if (dragging == true) {
					onMap = false;
					clone = Instantiate (transform, transform.parent.transform);
					clone.name = this.name;
				} else {
					if (onMap == true) {
						clone = Instantiate (structure.transform);
						clone.transform.position = new Vector3(transform.position.x, transform.position.y, 3);
						clone.name = structure.name;
						clone.gameObject.SetActive (true);
						Destroy (gameObject);
					} else {
						dragging = true;
					}
				}
			}
		}
	}

	void Update()
	{
		if (dragging == true)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			Vector2 rayPoint = ray.GetPoint(distance);
			transform.position = rayPoint;
		}
	}
}
