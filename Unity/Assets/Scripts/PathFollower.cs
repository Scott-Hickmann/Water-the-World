using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PathFollower : MonoBehaviour {
	public GameObject Path;
	private Node[] pathNode;
	//the object who move along the path.
	public float moveSpeed;
	//the speed when moving along the path
	//default time
	//so i forgot make a current to hold current node
	private int currentNode = 0;
	//this will hold current node
	private Vector3 currentPositionHolder;
	//the vector3 hold Node position
	public string gameOverScene;

	// Use this for initialization
	void Start () {
		pathNode = Path.GetComponentsInChildren<Node> ();
		CheckNode ();
	}/// <summary>
	/// we will make a function to check current Node and move to it. by save the node position to CurrenPositionHolder
	/// </summary>
	/// 
	private bool CheckNode(){
		if (currentNode < pathNode.Length) {
			currentPositionHolder = new Vector3 (pathNode [currentNode].transform.position.x, pathNode [currentNode].transform.position.y, 0);
			// we will hold the currentNode position to CurrenPosHolder.
		}
		return currentNode == pathNode.Length;
	}
	void DrawLine(){
		for (int i = 0; i < pathNode.Length - 1; i++) {
			//we will paint from PathNode[0] to 1 , 1 to 2 and like this to end of Pathnode
			Debug.DrawLine (pathNode [i].transform.position, pathNode [i + 1].transform.position, Color.green);
		}
	}
	// Update is called once per frame
	void Update () {
		//DrawLine ();
		//Debug.Log (CurrentPositionHolder.x);
		//this will make the path moving
		if (gameObject.transform.position.x != currentPositionHolder.x || gameObject.transform.position.y != currentPositionHolder.y) {
			//if human position not equal Node position we will move the human to node
			gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, currentPositionHolder, moveSpeed);

		} else {
			if (currentNode < pathNode.Length - 1) {
				//if it equal the node we will go next node
				currentNode++;
				//here 
				CheckNode ();
			} else {
				if (this.GetComponent<SpriteRenderer> ().sprite == this.GetComponent<Human> ().satisfiedSprite) {
					Destroy (gameObject);
				} else {
					SceneManager.LoadScene (gameOverScene);
				}
			}
		}
	}
}
