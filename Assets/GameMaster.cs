using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour {

	public GameObject player1;
	private int p1Dead;
	private int p1Alive;
	public GameObject p1DeadP;
	public GameObject p1AliveP;
	public GameObject p1ScoreP;
	public GameObject player2;
	private int p2Dead;
	private int p2Alive;
	public GameObject p2DeadP;
	public GameObject p2AliveP;
	public GameObject p2ScoreP;
	public GameObject player3;
	private int p3Dead;
	private int p3Alive;
	public GameObject p3DeadP;
	public GameObject p3AliveP;
	public GameObject p3ScoreP;

	public GameObject finalPanel;

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

		p1Dead = 0;
		p1Alive = 0;
		p2Dead = 0;
		p2Alive = 0;
		p3Dead = 0;
		p3Alive = 0;
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


		if (paddleL.GetComponent<ChildSave>().child == player1)
		{
			p1Alive += 1;
		}
		if (paddleL.GetComponent<ChildSave>().child == player2)
		{
			p2Alive += 1;
		}
		if (paddleL.GetComponent<ChildSave>().child == player3)
		{
			p3Alive += 1;
		}
		newRound();
	}

	void rightBorder()
	{
		paddleL.GetComponent<ChildSave>().child.GetComponent<Player>().addScore(paddleGoThroughScore);
		ball.GetComponent<ChildSave>().child.GetComponent<Player>().addScore(refugeeGoThroughScore);

		if (paddleR.GetComponent<ChildSave>().child == player1)
		{
			p1Alive += 1;
		}
		if (paddleR.GetComponent<ChildSave>().child == player2)
		{
			p2Alive += 1;
		}
		if (paddleR.GetComponent<ChildSave>().child == player3)
		{
			p3Alive += 1;
		}
		newRound();
	}

	void sinkBoat()
	{
		messageBox.GetComponent<Text>().text = "Refugees drowned";
		if (ball.GetComponent<Ball>().lastContact != null)
		{
			ball.GetComponent<ChildSave>().child.GetComponent<Player>().addScore(diedRefugeesScore);
			if (ball.GetComponent<Ball>().lastContact.GetComponent<ChildSave>().child == player1)
			{
				p1Dead += 1;
			}
			if (ball.GetComponent<Ball>().lastContact.GetComponent<ChildSave>().child == player2)
			{
				p2Dead += 1;
			}
			if (ball.GetComponent<Ball>().lastContact.GetComponent<ChildSave>().child == player3)
			{
				p3Dead += 1;
			}
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
			StartCoroutine(showFinalScreen());

		}
	}

	IEnumerator showFinalScreen()
	{
		finalPanel.SetActive(true);
		p1DeadP.GetComponent<Text>().text = p1Dead.ToString();
		p1AliveP.GetComponent<Text>().text = p1Alive.ToString();
		p1ScoreP.GetComponent<Text>().text = player1.GetComponent<Player>().score.ToString();

		p2DeadP.GetComponent<Text>().text = p2Dead.ToString();
		p2AliveP.GetComponent<Text>().text = p2Alive.ToString();
		p2ScoreP.GetComponent<Text>().text = player2.GetComponent<Player>().score.ToString();

		p3DeadP.GetComponent<Text>().text = p3Dead.ToString();
		p3AliveP.GetComponent<Text>().text = p3Alive.ToString();
		p3ScoreP.GetComponent<Text>().text = player3.GetComponent<Player>().score.ToString();

		ball.SetActive(false);

		yield return new WaitForSeconds(10);

		ball.SetActive(true);

		finalPanel.SetActive(false);
		currentRound = 0;
		player1.GetComponent<Player>().score = 0;
		player2.GetComponent<Player>().score = 0;
		player3.GetComponent<Player>().score = 0;
		p1Dead = 0;
		p1Alive = 0;
		p2Dead = 0;
		p2Alive = 0;
		p3Dead = 0;
		p3Alive = 0;
		ball.SendMessage ("reset");
	}
}
