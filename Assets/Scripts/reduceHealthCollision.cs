using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class reduceHealthCollision : MonoBehaviour {

public int NPCLayer = 9;

// public float minHitVelocity = 3.0f;
// public float yHitVelocity = -.2f;

public int healthPoints = 3;
public Image healthHeart01;
public Image healthHeart02;
public Image healthHeart03;
public Sprite emptyHeart;
public Sprite fullHeart;
public Text gameOverText;

public float waitBetweenHits = 1.0f;

public GameObject hitParticleSystem;
public float destroyParticlesSeconds = 2.0f;

private float collisionCheckCountdown = 0.0f;

private Animator anim;

private AudioSource audioSource;


// Use this for initialization
void Start () 
	{
	audioSource = GetComponent<AudioSource>();
	//healthText.text = healthTextString + " " + healthPoints.ToString();
	anim = GetComponent<Animator> ();
	}

	
// Update is called once per frame
void Update () 
	{
	collisionCheckCountdown -= Time.deltaTime;
	}



void OnCollisionEnter( Collision other )
	{
	int otherLayer;

	GameObject thisInstance;

	otherLayer = other.gameObject.layer;

	// Debug.Log ( "reduceHealth otherLayer = " + otherLayer + ", timer = " + waitTime );

	if ( collisionCheckCountdown < 0.0f )
		{
		if (otherLayer == NPCLayer )
			{
			collisionCheckCountdown = waitBetweenHits;

			foreach (ContactPoint contact in other.contacts) 
				{
				thisInstance = Instantiate (hitParticleSystem, contact.point, Quaternion.identity);
				Destroy (thisInstance, destroyParticlesSeconds);
				}

        	audioSource.Play();
			healthPoints--;
			//healthText.text = healthTextString + " " + healthPoints.ToString();

			if ( healthPoints < 1 )
				{
				anim.SetBool ("isDead", true);

				gameOverText.gameObject.SetActive( true );

				//healthText.gameObject.SetActive (false);
				}
			}
		}
	}
}
