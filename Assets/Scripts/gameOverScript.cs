using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gameOverScript : MonoBehaviour {

	public damageScript playerHealth;
	public float restartDelay = 5f;

	Animator anim;
	float restartTimer;

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (playerHealth.currentHealth <= 0) {
			anim.SetTrigger ("GameOver");

			restartTimer += Time.deltaTime;

			if (restartTimer >= restartDelay) {
				SceneManager.LoadScene ("05thDraft.026");
				Debug.Log("reload level here");
			}
		}
	}

}
