using UnityEngine;
using System.Collections;

public class EnterBorder : MonoBehaviour {

	public string message;
	public GameObject gamemaster;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D (Collider2D c)
	{
		gamemaster.SendMessage(message);
	}
}
