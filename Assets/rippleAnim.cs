using UnityEngine;
using System.Collections;

public class rippleAnim : MonoBehaviour {

	public Sprite[] rippleStates;
	private int currentState;
	public int interval;
	private float counter;
	// Use this for initialization
	void Start () {
		currentState = 0;
		counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
		counter += 1*Time.deltaTime;

		if (counter >= interval)
		{
			switchState();
			counter = 0;
		}
	}

	private void switchState()
	{
		if (currentState < rippleStates.Length-1)
		{
			currentState += 1;
			GetComponent<SpriteRenderer>().sprite = rippleStates[currentState];
		}
		else
		{
			currentState = 0;
			GetComponent<SpriteRenderer>().sprite = rippleStates[0];
		}
	}
}
