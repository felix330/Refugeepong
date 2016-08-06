using UnityEngine;
using System.Collections;

public class UpDown : MonoBehaviour {

	public float upperLimit;
	public float lowerLimit;

	public float sensitivity;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void up()
	{
		if (transform.position.y < upperLimit)
		{
			transform.position += transform.up*sensitivity*Time.deltaTime;
		}
	}

	void down()
	{
		if (transform.position.y > lowerLimit)
		{
			transform.position -= transform.up*sensitivity*Time.deltaTime;
		}
	}

	void shipSwitch(Sprite shipSpr)
	{
		GetComponent<SpriteRenderer>().sprite = shipSpr;
	}
}
