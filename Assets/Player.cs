using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int score;
	public string upAxis;
	public string downAxis;
	public string leftAxis;
	public string rightAxis;

	public Sprite associatedPaddleSprite;
	public Sprite associatedBallSprite;

	public GameObject gamemaster;


	public Color color;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {



		if (Input.GetButton (upAxis)) {
			transform.parent.SendMessage ("up", SendMessageOptions.DontRequireReceiver);
		} else if (Input.GetButton (downAxis)) {
			transform.parent.SendMessage ("down", SendMessageOptions.DontRequireReceiver);
		} else if (Input.GetButton (leftAxis)) {
			transform.parent.SendMessage ("left", SendMessageOptions.DontRequireReceiver);
		} else if (Input.GetButton (rightAxis)) {
			transform.parent.SendMessage ("right", SendMessageOptions.DontRequireReceiver);
		} else {
			transform.parent.SendMessage ("soundOfSilence", SendMessageOptions.DontRequireReceiver);
		}

		if (Input.GetButtonDown (upAxis)) {
			transform.parent.SendMessage ("upPush", SendMessageOptions.DontRequireReceiver);
		} else if (Input.GetButtonDown (downAxis)) {
			transform.parent.SendMessage ("downPush", SendMessageOptions.DontRequireReceiver);
		}
		else if (Input.GetButtonDown (leftAxis)) {
			transform.parent.SendMessage ("leftPush", SendMessageOptions.DontRequireReceiver);
		} else if (Input.GetButtonDown (rightAxis)) {
			transform.parent.SendMessage ("rightPush", SendMessageOptions.DontRequireReceiver);
		}


	
	
	}

	public void switchPosition(GameObject ship)
	{
		transform.parent = ship.transform;
		transform.parent.SendMessage("shipSwitch",associatedPaddleSprite, SendMessageOptions.DontRequireReceiver);
		transform.parent.SendMessage("boatSwitch",associatedBallSprite,SendMessageOptions.DontRequireReceiver);
		transform.parent.gameObject.GetComponent<ChildSave>().child = gameObject;
	}

	public void addScore (int toAdd)
	{
		score += toAdd;
		StartCoroutine(gamemaster.GetComponent<GameMaster>().showScoreChange(gameObject, toAdd));
	}
		
}
