using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public int score;
	public string upAxis;
	public string downAxis;
	public string leftAxis;
	public string rightAxis;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButton(upAxis))
		{
			transform.parent.SendMessage ("up",SendMessageOptions.DontRequireReceiver);
		}
		if (Input.GetButton(downAxis))
		{
			transform.parent.SendMessage ("down",SendMessageOptions.DontRequireReceiver);
		}
		if (Input.GetButton(leftAxis))
		{
			transform.parent.SendMessage ("left",SendMessageOptions.DontRequireReceiver);
		}
		if (Input.GetButton(rightAxis))
		{
			transform.parent.SendMessage ("right",SendMessageOptions.DontRequireReceiver);
		}
	
	}
}
