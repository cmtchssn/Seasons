using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class altarDoorScript : MonoBehaviour {

	public GameObject altarDoor;
	public GameObject pickup01;
	public GameObject pickup02;
	public GameObject pickup03;
	public int items;

	private Animator anim;

	// Use this for initialization
	void Start () {
		altarDoor.gameObject.SetActive (true);
		anim = altarDoor.GetComponent<Animator> ();
		anim.SetBool ("up", true);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			Debug.Log ("Player is in Altar Trigger.");
			if(!pickup01.gameObject.activeSelf && !pickup02.gameObject.activeSelf && !pickup03.gameObject.activeSelf) {
				Debug.Log ("all pickups are inactive");
				items = 3;
				anim.SetBool ("fall", true);
				anim.SetBool ("down", true);
				//altarDoor.gameObject.SetActive (false);
			} else {
				Debug.Log("Requirements not met.");
			}
		}
	}
}