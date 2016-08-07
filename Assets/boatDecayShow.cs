using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class boatDecayShow : MonoBehaviour {

	public GameObject boat;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		int state = 100 - (int)boat.GetComponent<boatDecay>().boatCondition;
		GetComponent<Text>().text = state.ToString();
		GetComponent<Text>().text = GetComponent<Text>().text.Insert(GetComponent<Text>().text.Length, "%");
	}
}
