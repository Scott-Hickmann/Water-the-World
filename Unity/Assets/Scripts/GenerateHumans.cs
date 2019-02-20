using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateHumans : MonoBehaviour {

	public GameObject[] humans;
	private Transform clone;
	private int[,] rounds = new int[48, 12]{
		{2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 2
		{4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 4
		{6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 6
		{8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 8
		{8, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 10
		{8, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 12
		{8, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 14
		{8, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 16
		{8, 8, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 18
		{8, 8, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 20
		{6, 8, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 20
		{4, 8, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0}, // 20
		{2, 8, 8, 2, 0, 0, 0, 0, 0, 0, 0, 0}, // 20
		{2, 6, 8, 4, 0, 0, 0, 0, 0, 0, 0, 0}, // 20
		{2, 4, 8, 6, 0, 0, 0, 0, 0, 0, 0, 0}, // 20
		{2, 2, 8, 8, 0, 0, 0, 0, 0, 0, 0, 0}, // 20
		{2, 2, 7, 8, 1, 0, 0, 0, 0, 0, 0, 0}, // 20
		{2, 2, 6, 8, 2, 0, 0, 0, 0, 0, 0, 0}, // 20
		{2, 2, 5, 8, 3, 0, 0, 0, 0, 0, 0, 0}, // 20
		{2, 2, 4, 8, 4, 0, 0, 0, 0, 0, 0, 0}, // 20
		{2, 2, 3, 8, 4, 1, 0, 0, 0, 0, 0, 0}, // 20
		{2, 2, 2, 8, 4, 2, 0, 0, 0, 0, 0, 0}, // 20
		{2, 2, 2, 7, 4, 3, 0, 0, 0, 0, 0, 0}, // 20
		{2, 2, 2, 6, 4, 4, 0, 0, 0, 0, 0, 0}, // 20
		{2, 2, 2, 5, 4, 4, 1, 0, 0, 0, 0, 0}, // 20
		{2, 2, 2, 4, 4, 4, 2, 0, 0, 0, 0, 0}, // 20
		{2, 2, 2, 3, 4, 4, 3, 0, 0, 0, 0, 0}, // 20
		{2, 2, 2, 2, 4, 4, 4, 0, 0, 0, 0, 0}, // 20
		{2, 2, 2, 2, 3, 4, 4, 1, 0, 0, 0, 0}, // 20
		{2, 2, 2, 2, 2, 4, 4, 2, 0, 0, 0, 0}, // 20
		{2, 2, 2, 2, 1, 4, 4, 3, 0, 0, 0, 0}, // 20
		{2, 2, 2, 2, 1, 3, 4, 4, 0, 0, 0, 0}, // 20
		{2, 2, 2, 2, 1, 2, 4, 4, 1, 0, 0, 0}, // 20
		{2, 2, 2, 2, 1, 1, 4, 4, 2, 0, 0, 0}, // 20
		{2, 2, 2, 2, 1, 1, 3, 4, 3, 0, 0, 0}, // 20
		{2, 2, 2, 2, 1, 1, 2, 4, 4, 0, 0, 0}, // 20
		{2, 2, 2, 2, 1, 1, 1, 4, 4, 1, 0, 0}, // 20
		{2, 2, 2, 2, 1, 1, 1, 3, 4, 2, 0, 0}, // 20
		{2, 2, 2, 2, 1, 1, 1, 2, 4, 3, 0, 0}, // 20
		{2, 2, 2, 2, 1, 1, 1, 1, 4, 4, 0, 0}, // 20
		{2, 2, 2, 2, 1, 1, 1, 1, 3, 4, 1, 0}, // 20
		{2, 2, 2, 2, 1, 1, 1, 1, 2, 4, 2, 0}, // 20
		{2, 2, 2, 2, 1, 1, 1, 1, 1, 4, 3, 0}, // 20
		{2, 2, 2, 2, 1, 1, 1, 1, 1, 3, 4, 0}, // 20
		{2, 2, 2, 2, 1, 1, 1, 1, 1, 2, 4, 1}, // 20
		{2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 3, 2}, // 20
		{2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 3, 3}, // 20
		{2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 2, 4}, // 20
	};
	public float roundDelay;
	public float spawnDelay;
	public static int round;
	public static int previousRound;

	// Use this for initialization
	void Start () {
		round = 1;
		previousRound = round;
		StartCoroutine(Generate());
	}

	IEnumerator Generate() {
		Debug.Log (rounds.Length / humans.Length);
		for (int roundNumber = 0; roundNumber < rounds.Length / humans.Length; roundNumber++) {
			for (int humanNumber = 0; humanNumber < humans.Length; humanNumber++) {
				for (int i = 0; i < rounds[roundNumber, humanNumber]; i++) {
					yield return new WaitForSeconds (spawnDelay);
					clone = Instantiate (humans[humanNumber].transform, transform);
					clone.gameObject.SetActive (true);
				}
			}
			yield return new WaitUntil(() => transform.childCount == 0);
			round += 1;
			yield return new WaitForSeconds (roundDelay);
			previousRound += 1;
		}
	}
}
