﻿using UnityEngine;
using System.Collections;

public class boatDecay : MonoBehaviour {

	public float boatCondition;
	public float decayRatePerS;
	public float randomRate;
	public bool running;
	public GameObject gamemaster;

	private float countTime;
	// Use this for initialization
	void Start () {
		countTime = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (running) {
			countTime += Time.deltaTime;
		

			if (boatCondition < 80) {
				boatCondition += decayRatePerS * Time.deltaTime;
			}
		}

		float randomValue = Random.Range(1,100);

		if (countTime > randomRate)
		{
			if (randomValue<boatCondition)
			{
				Debug.Log("Boat Sunk");
				gamemaster.SendMessage("sinkBoat");
				boatCondition = 0;
			}
			countTime = 0;
		}
	}

	void reset () {

	}
}
