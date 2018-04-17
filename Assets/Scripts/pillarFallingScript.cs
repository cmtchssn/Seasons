using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pillarFallingScript : MonoBehaviour {

	public GameObject pillar06;
	public GameObject pillar07;
	public GameObject pillar09;
	public BoxCollider pillar06Trigger;
	public BoxCollider pillar07Trigger;
	public BoxCollider pillar09Trigger;

	private Animator anim06;
	private Animator anim07;
	private Animator anim09;

	// Use this for initialization
	void Start () {
		anim06 = pillar06.GetComponent<Animator> ();
		anim07 = pillar07.GetComponent<Animator> ();
		anim09 = pillar09.GetComponent<Animator> ();
		pillar06Trigger = GetComponent<BoxCollider> ();
		pillar07Trigger = GetComponent<BoxCollider> ();
		pillar09Trigger = GetComponent<BoxCollider> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void onTriggerExit (Collider other) {
		if(other.gameObject.CompareTag ("Player")/*player exits pillar06 trigger*/) {
			anim06.SetBool ("fall", true); //needs to stay down
			/*disable pillar06 trigger*/
		}
		if(other.gameObject.CompareTag ("Player")/*player exits pillar09 trigger*/) {
			anim09.SetBool ("fall", true); //needs to stay down
			/*disable pillar09 trigger*/
		}
	}

	void onTriggerEnter (Collider other) {
		if(other.gameObject.CompareTag ("Player")/*anim06 is down && anim09 is down && mummy enters pillar07 trigger*/) {
			anim07.SetBool ("fall", true); //needs to stay down
			/*disable pillar07 trigger*/
			/*reveal cave02*/		
		}
	}
}
