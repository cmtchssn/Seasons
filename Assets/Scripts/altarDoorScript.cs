using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class altarDoorScript : MonoBehaviour {

	public GameObject altarDoor;

	// Use this for initialization
	void Start () {
		altarDoor.gameObject.SetActive (true);
	}

	void onTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Player") /* && Player has all 3 items*/) {
			altarDoor.gameObject.SetActive (false);
		}
	}
}
