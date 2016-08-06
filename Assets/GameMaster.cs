using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	public GameObject player3;

	public GameObject paddleL;
	public GameObject paddleR;
	public GameObject ball;

	// Use this for initialization
	void Start () {
		startGame();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void startGame () 
	{
		player1.GetComponent<Player>().switchPosition(paddleL);
		player2.GetComponent<Player>().switchPosition(paddleR);
		player3.GetComponent<Player>().switchPosition(ball);
	}

	void swap(GameObject p1,GameObject p2)
	{
		GameObject pParent1 = p1.transform.parent.gameObject;
		GameObject pParent2 = p2.transform.parent.gameObject;

		p1.GetComponent<Player>().switchPosition(p2);
		p2.GetComponent<Player>().switchPosition(p1);
	}
}
