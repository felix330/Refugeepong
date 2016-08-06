using UnityEngine;
using System.Collections;

public class UpDown : MonoBehaviour {

	public float sensitivity;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	}

	void up()
	{
		transform.position += transform.up*sensitivity;
	}

	void down()
	{
		transform.position -= transform.up*sensitivity;
	}
}
