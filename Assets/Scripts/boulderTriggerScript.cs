using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boulderTriggerScript : MonoBehaviour {

	public GameObject boulders;

	// Use this for initialization
	void Start () {
		boulders.SetActive (false);
	}

	private void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag ("Player")) {
			boulders.SetActive (true);
		}
	}
}
