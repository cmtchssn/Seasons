using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pillar06fallScript : MonoBehaviour {

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void onTriggerExit(Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			anim.SetBool ("fall", true);
		}
	}
}
