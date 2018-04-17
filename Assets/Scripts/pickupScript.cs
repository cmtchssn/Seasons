using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pickupScript : MonoBehaviour {

	public GameObject pickup01;
	public GameObject pickup02;
	public GameObject pickup03;
	public Image pickup01Image;
	public Image pickup02Image;
	public Image pickup03Image;

	// Use this for initialization
	void Awake () 
	{
		pickup01Image.gameObject.SetActive (false);
		pickup02Image.gameObject.SetActive (false);
		pickup03Image.gameObject.SetActive (false);
	}

	void Update ()
	{
		if (!pickup01.gameObject.activeSelf) {
			pickup01Image.gameObject.SetActive (true);
		}

		if (!pickup02.gameObject.activeSelf) {
			pickup02Image.gameObject.SetActive (true);
		}

		if (!pickup03.gameObject.activeSelf) {
			pickup03Image.gameObject.SetActive (true);
		}
			
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
		}
	}
		
}
