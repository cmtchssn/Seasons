using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winnerScript : MonoBehaviour {

	public altarOfferingScript itemTotal;
	public float restartDelay = 10f;

	Animator anim;
	float restartTimer;

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if (itemTotal.items == 3) {
			anim.SetTrigger ("win");

			restartTimer += Time.deltaTime;

			if (restartTimer >= restartDelay) {
				SceneManager.LoadScene ("05thDraft.025");
				Debug.Log("reload level here");
			}
		}
	}

}

