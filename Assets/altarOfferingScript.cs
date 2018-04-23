using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class altarOfferingScript : MonoBehaviour {

	public GameObject altar;
	public GameObject offering01;
	public GameObject offering02;
	public GameObject offering03;
	public GameObject pickup01;
	public GameObject pickup02;
	public GameObject pickup03;

	// Use this for initialization
	void Start () {
		offering01.gameObject.SetActive (false);
		offering02.gameObject.SetActive (false);
		offering03.gameObject.SetActive (false);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			Debug.Log ("Player is at the Altar making an offering.");
			offering01.gameObject.SetActive (true);
			offering02.gameObject.SetActive (true);
			offering03.gameObject.SetActive (true);
		}
	}
}
