using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pillar07fallScript : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Enemy")) {
			Debug.Log ("mummy entered trigger.");

			anim.SetBool ("fall", true);
			anim.SetBool ("down", true);
		}
	}
}