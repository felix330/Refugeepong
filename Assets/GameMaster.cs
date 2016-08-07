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

	public GameObject messageBox;

	public int numberOfRounds;
	private int currentRound;

	public int paddleGoThroughScore;
	public int refugeeGoThroughScore;
	public int killedRefugeesScore;
	public int diedRefugeesScore;


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
		currentRound = 0;
		player1.GetComponent<Player>().switchPosition(paddleL);
		player2.GetComponent<Player>().switchPosition(ball);
		player3.GetComponent<Player>().switchPosition(paddleR);
	}

	void swap(GameObject p1,GameObject p2)
	{
		GameObject pParent1 = p1.transform.parent.gameObject;
		GameObject pParent2 = p2.transform.parent.gameObject;

		p1.GetComponent<Player>().switchPosition(pParent2);
		p2.GetComponent<Player>().switchPosition(pParent1);
	}

	void leftBorder()
	{
		paddleR.GetComponent<ChildSave>().child.GetComponent<Player>().addScore(paddleGoThroughScore);
		ball.GetComponent<ChildSave>().child.GetComponent<Player>().addScore(refugeeGoThroughScore);
		newRound();
	}

	void rightBorder()
	{
		paddleL.GetComponent<ChildSave>().child.GetComponent<Player>().addScore(paddleGoThroughScore);
		ball.GetComponent<ChildSave>().child.GetComponent<Player>().addScore(refugeeGoThroughScore);
		newRound();
	}

	void sinkBoat()
	{
		messageBox.GetComponent<Text>().text = "Refugees drowned";
		if (ball.GetComponent<Ball>().lastContact != null)
		{
			ball.GetComponent<ChildSave>().child.GetComponent<Player>().addScore(diedRefugeesScore);
			GameObject toSwitch = ball.GetComponent<Ball>().lastContact.GetComponent<ChildSave>().child;
			toSwitch.GetComponent<Player>().addScore(killedRefugeesScore);
			swap(toSwitch,ball.GetComponent<ChildSave>().child);
		}
		newRound();

	}

	void newRound()
	{
		if (currentRound<numberOfRounds)
		{
			currentRound++;
			ball.SendMessage ("reset");
		}
		else
		{
			messageBox.GetComponent<Text>().text = "Round over!";
			currentRound = 0;
			player1.GetComponent<Player>().score = 0;
			player2.GetComponent<Player>().score = 0;
			player3.GetComponent<Player>().score = 0;
			ball.SendMessage ("reset");
		}
	}
}
