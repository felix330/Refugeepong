using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		Vector2 v = new Vector2 (50, -100);
		GetComponent<Rigidbody2D> ().AddForce (v);
	}

	// Update is called once per frame
	void Update ()
	{
		Vector2 v = GetComponent<Rigidbody2D> ().velocity;
		if (v.magnitude < 1.5) {
			GetComponent<Rigidbody2D> ().AddForce (v);
		}
		GetComponent<Rigidbody2D> ().AddForce (v*0.001f);

		Quaternion rot = Quaternion.LookRotation (v);
		Debug.Log (rot.eulerAngles);
		transform.eulerAngles = new Vector3(0,0,rot.eulerAngles.x-rot.eulerAngles.y);

	}
}