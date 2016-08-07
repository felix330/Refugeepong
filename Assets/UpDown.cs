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
		if (goinUp == 1) {	
			Vector2 v = new Vector2 (0, 30);
			c.collider.gameObject.GetComponent<Rigidbody2D> ().AddForce (v);
		} else if (goinUp == -1) {	
			Vector2 v = new Vector2 (0, -30);
			c.collider.gameObject.GetComponent<Rigidbody2D> ().AddForce (v);
		} 
			int sign = 1;
			if (gameObject.name == "PaddleR") {
				sign = -1;
			}
			Vector2 vv = new Vector2 (sign*100, 0);
			c.collider.gameObject.GetComponent<Rigidbody2D> ().AddForce (vv);

	}
		
}
