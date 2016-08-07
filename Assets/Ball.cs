using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ball : MonoBehaviour {

	public GameObject lastContact;
	public GameObject messageBox;
	// Use this for initialization
	void Start ()
	{
		StartCoroutine (reset ());
	}

	// Update is called once per frame
	void Update ()
	{
		Vector2 v = GetComponent<Rigidbody2D> ().velocity;
		if (v.magnitude < 1.5) {
			GetComponent<Rigidbody2D> ().AddForce (v);
		}
		GetComponent<Rigidbody2D> ().AddForce (v*0.01f);

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
		Vector2 v = new Vector2(0,10);
		GetComponent<Rigidbody2D>().AddForce(v);
	}

	void downPush()
	{
		Vector2 v = new Vector2(0,-10);
		GetComponent<Rigidbody2D>().AddForce(v);
	}

	void rightPush()
	{
		Vector2 v = new Vector2(10,0);
		GetComponent<Rigidbody2D>().AddForce(v);
	}

	void leftPush()
	{
		Vector2 v = new Vector2(-10,0);
		GetComponent<Rigidbody2D>().AddForce(v);
	}


	IEnumerator reset()
	{
		GetComponent<Rigidbody2D> ().velocity = Vector2.zero;



		float r1 = Random.value;

		float r2 = Random.value;

		int x = (Random.Range(100,150));
		int y = (Random.Range(100,150));

		Vector2 v = new Vector2(0,0);

		if (r1 >= 0.5)
		{
			Debug.Log("Plus");
			if (r2 > 0.5)
			{
				v = new Vector2 (x,y);
			}
			else
			{
				v = new Vector2 (x,-y);
			}
		}

		if (r1 <= 0.5)
		{
			Debug.Log("Minus");
			if (r2 > 0.5)
			{
				v = new Vector2 (-x,y);
			}
			else
			{
				v = new Vector2 (-x,-y);
			}
		}

		GetComponent<boatDecay> ().running = false;
		yield return new WaitForSeconds (1);
		transform.position = Vector2.zero;
		GetComponent<Rigidbody2D> ().velocity = Vector2.zero;
		yield return new WaitForSeconds (1);
		lastContact = null;
		messageBox.GetComponent<Text>().text = "";
		GetComponent<boatDecay> ().running = true;
		GetComponent<boatDecay>().boatCondition = 0;
		GetComponent<Rigidbody2D> ().AddForce (v);
	}

	void boatSwitch(Sprite shipSpr)
	{
		GetComponent<SpriteRenderer>().sprite = shipSpr;
	}

}