using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pillar06fallScript : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	void OnTriggerExit(Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			Debug.Log ("trigger exited.");

			anim.SetBool ("fall", true);
			anim.SetBool ("down", true);

		}
	}
}
