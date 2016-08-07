using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

	public GameObject player1;
	public GameObject player2;
	public GameObject player3;

	public GameObject paddleL;
	public GameObject paddleR;
	public GameObject ball;

	public GameObject scoreL;
	public GameObject scoreM;
	public GameObject scoreR;

	// Use this for initialization
	void Start () {
		startGame();
	}

	// Update is called once per frame
	void Update () {
		scoreL.GetComponent<Text>().text = paddleL.GetComponent<ChildSave>().child.GetComponent<Player>().score.ToString();
		scoreL.GetComponent<Text>().color = paddleL.GetComponent<ChildSave>().child.GetComponent<Player>().color;

		scoreM.GetComponent<Text>().text = ball.GetComponent<ChildSave>().child.GetComponent<Player>().score.ToString();
		scoreM.GetComponent<Text>().color = ball.GetComponent<ChildSave>().child.GetComponent<Player>().color;

		scoreR.GetComponent<Text>().text = paddleR.GetComponent<ChildSave>().child.GetComponent<Player>().score.ToString();
		scoreR.GetComponent<Text>().color = paddleR.GetComponent<ChildSave>().child.GetComponent<Player>().color;
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

	void leftBorder()
	{
		paddleR.GetComponent<ChildSave>().child.GetComponent<Player>().addScore(1);
		ball.GetComponent<ChildSave>().child.GetComponent<Player>().addScore(1);
	}

	void rightBorder()
	{
		paddleL.GetComponent<ChildSave>().child.GetComponent<Player>().addScore(1);
		ball.GetComponent<ChildSave>().child.GetComponent<Player>().addScore(1);
	}
}
