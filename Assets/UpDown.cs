using UnityEngine;
using System.Collections;

public class UpDown : MonoBehaviour {

	public float upperLimit;
	public float lowerLimit;
	private int goinUp;

	public float sensitivity;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void up()
	{
		Vector3 rot = new Vector3(0,0,0);
		transform.eulerAngles = rot;
		if (transform.position.y < upperLimit)
		{
			transform.position += transform.up*sensitivity*Time.deltaTime;
			goinUp = 1;
		}
	}

	void down()
	{
		Vector3 rot = new Vector3(0,0,180);
		transform.eulerAngles = rot;
		if (transform.position.y > lowerLimit) {
			transform.position += transform.up * sensitivity * Time.deltaTime;
			goinUp = -1;
		} else {
			goinUp = 0;
		}
	}

	void soundOfSilence()
	{
		goinUp = 0;
	}

	void shipSwitch(Sprite shipSpr)
	{
		GetComponent<SpriteRenderer>().sprite = shipSpr;
	}

	void OnCollisionExit2D (Collision2D c)
	{
		c.collider.gameObject.GetComponent<Ball>().lastContact = gameObject;
		if (goinUp == 1)
		{	
			Vector2 v = new Vector2 (0, 100);
			c.collider.gameObject.GetComponent<Rigidbody2D> ().AddForce (v);
			Debug.Log ("goin'Up");
		}
		else if (goinUp == -1)
		{	
			Vector2 v = new Vector2 (0, -100);
			Debug.Log ("goin'Down maybe?");
			c.collider.gameObject.GetComponent<Rigidbody2D> ().AddForce (v);
			Debug.Log ("goin'Down");
		}
	}
		
}
