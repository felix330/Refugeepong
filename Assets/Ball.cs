using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	public GameObject lastContact;
	// Use this for initialization
	void Start ()
	{
		reset ();
	}

	// Update is called once per frame
	void Update ()
	{
		Vector2 v = GetComponent<Rigidbody2D> ().velocity;
		if (v.magnitude < 1.5) {
			GetComponent<Rigidbody2D> ().AddForce (v);
		}
		GetComponent<Rigidbody2D> ().AddForce (v*0.001f);

		Quaternion rot = Quaternion.LookRotation (GetComponent<Rigidbody2D>().velocity);
		if (rot.eulerAngles.y == 90) {
			transform.eulerAngles = new Vector3 (0, 0, -rot.eulerAngles.x - rot.eulerAngles.y);
		}
		if (rot.eulerAngles.y == 270) {
			transform.eulerAngles = new Vector3 (0, 0, rot.eulerAngles.x - rot.eulerAngles.y);
		}
	}

	void upPush()
	{
		Vector2 v = new Vector2(0,5);
		GetComponent<Rigidbody2D>().AddForce(v);
	}

	void downPush()
	{
		Vector2 v = new Vector2(0,-5);
		GetComponent<Rigidbody2D>().AddForce(v);
	}

	void reset()
	{
		GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		transform.position = Vector2.zero;
		lastContact = null;
		Vector2 v = new Vector2 (50, -100);
		GetComponent<boatDecay>().boatCondition = 0;
		GetComponent<Rigidbody2D> ().AddForce (v);
	}

	void boatSwitch(Sprite shipSpr)
	{
		GetComponent<SpriteRenderer>().sprite = shipSpr;
	}

}