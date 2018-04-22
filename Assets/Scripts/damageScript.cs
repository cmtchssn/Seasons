using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class damageScript : MonoBehaviour {

	public int startingHealth = 3;
	public int currentHealth;
	public Image damageImage;
	public Image healthHeart01;
	public Image healthHeart02;
	public Image healthHeart03;
	public Sprite emptyHeart;
	public Sprite fullHeart;
	public GameObject player;
	//public AudioClip hurtClip;
	//public AudioClip deathClip;
	public float flashSpeed = 5f;
	public Color flashColor = new Color (1f, 0f, 0, 0.1f);

	//private AudioSource playerAudio;

	bool damaged;
	bool isDead;

	//ken's vars
	public int NPCLayer = 9;
	// public float minHitVelocity = 3.0f;
	// public float yHitVelocity = -.2f;
	public Text gameOverText;
	public float waitBetweenHits = 1.0f;
	public GameObject hitParticleSystem;
	public float destroyParticlesSeconds = 2.0f;

	private float collisionCheckCountdown = 0.0f;
	//private Animator anim;
	//private AudioSource audioSource;
	//private int playerHealth;


	void Start () {
		gameOverText.gameObject.SetActive (false);
		currentHealth = startingHealth;

		healthHeart01 = GetComponent<Image> ();
		healthHeart02 = GetComponent<Image> ();
		healthHeart03 = GetComponent<Image> ();
		/*
		fullHeart = Resources.Load<Sprite> ("heartFull");
		emptyHeart = Resources.Load<Sprite> ("heartEmpty");
		*/

		//playerAudio = GetComponent <AudioSource> ();

		//ken's script 
		//audioSource = GetComponent<AudioSource>();
		//anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		// If the player has just been damaged...
		if(damaged)
		{
			// ... set the colour of the damageImage to the flash colour.
			damageImage.color = flashColor;
		}
		// Otherwise...
		else
		{
			// ... transition the colour back to clear.
			damageImage.color = Color.Lerp (damageImage.color, Color.clear, flashSpeed * Time.deltaTime);
		}
		// Reset the damaged flag.
		damaged = false;

		//ken's script
		collisionCheckCountdown -= Time.deltaTime;

	}


	void OnCollisionEnter(Collision other) 
	{
		//Debug.Log ("OnCollisionEnter");
		if (other.gameObject.CompareTag ("Boulders"))
		{
			TakeDamage (1);
		}

		//ken's script
		int otherLayer;

		GameObject thisInstance;

		otherLayer = other.gameObject.layer;

		// Debug.Log ( "reduceHealth otherLayer = " + otherLayer + ", timer = " + waitTime );

		if ( collisionCheckCountdown < 0.0f )
		{
			if (otherLayer == NPCLayer )
			{
				TakeDamage (1);
				collisionCheckCountdown = waitBetweenHits;

				foreach (ContactPoint contact in other.contacts) 
				{
					thisInstance = Instantiate (hitParticleSystem, contact.point, Quaternion.identity);
					Destroy (thisInstance, destroyParticlesSeconds);
				}

				//audioSource.Play();

			}
		}

	}


	public void TakeDamage (int amount)
	{
		// Set the damaged flag so the screen will flash.
		damaged = true;

		// Reduce the current health by the damage amount.
		currentHealth -= amount;
		Debug.Log (currentHealth);
		//Heart ();
		if (currentHealth == 3) {
			healthHeart01.sprite = fullHeart;
			healthHeart02.sprite = fullHeart;
			healthHeart03.sprite = fullHeart;
		}
		if (currentHealth == 2) {
			healthHeart01.sprite = emptyHeart;
			healthHeart02.sprite = fullHeart;
			healthHeart03.sprite = fullHeart;
		}

		if (currentHealth == 1) {
			healthHeart01.sprite = emptyHeart;
			healthHeart02.sprite = emptyHeart;
			healthHeart03.sprite = fullHeart;
		}

		if (currentHealth == 0) {
			healthHeart01.sprite = emptyHeart;
			healthHeart02.sprite = emptyHeart;
			healthHeart03.sprite = emptyHeart;
		}

		// Play the hurt sound effect.
		//playerAudio.Play ();

		// If the player has lost all it's health and the death flag hasn't been set yet...
		if(currentHealth <= 0 && !isDead)
		{
			// ... it should die.
			Death ();
		}
	}


	void Death ()
	{
		// Set the death flag so this function won't be called again.
		isDead = true;

		// Set the audiosource to play the death clip and play it (this will stop the hurt sound from playing).
		//playerAudio.clip = deathClip;
		//playerAudio.Play ();

		gameOverText.gameObject.SetActive (true);

		// Turn off the movement and shooting scripts.
		//playerMovement.enabled = false;
	}  

	/*
	public void Heart ()
	{
		if (currentHealth == 3) {
			healthHeart01.sprite = fullHeart;
			healthHeart02.sprite = fullHeart;
			healthHeart03.sprite = fullHeart;
		}
		if (currentHealth == 2) {
			healthHeart01.sprite = emptyHeart;
			healthHeart02.sprite = fullHeart;
			healthHeart03.sprite = fullHeart;
		}

		if (currentHealth == 1) {
			healthHeart01.sprite = emptyHeart;
			healthHeart02.sprite = emptyHeart;
			healthHeart03.sprite = fullHeart;
		}

		if (currentHealth == 0) {
			healthHeart01.sprite = emptyHeart;
			healthHeart02.sprite = emptyHeart;
			healthHeart03.sprite = emptyHeart;
		}
	}
	*/
}