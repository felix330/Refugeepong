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
	}
		
}
