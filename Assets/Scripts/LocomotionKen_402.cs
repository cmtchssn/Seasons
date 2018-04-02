// LocomotionSimpleAgent.cs
using UnityEngine;

[RequireComponent (typeof (UnityEngine.AI.NavMeshAgent))]
[RequireComponent (typeof (Animator))]
public class LocomotionKen_402 : MonoBehaviour {

//  navigates to waypoints
//	not goal-tagged object

// use boolean states for animation

// working in world space instead of DX and DY

// adding per-waypoint patrol speed
  	 Animator anim;
    UnityEngine.AI.NavMeshAgent agent;
    Vector3 smoothDeltaPosition = Vector3.zero;
    Vector3 velocity = Vector3.zero;

	Transform player;

    // PlayerHealth playerHealth;
    // EnemyHealth enemyHealth;
    // NavMeshAgent nav;

	float vely;
    float velx;
    float velz;
	public float waypointArrivedDistance = 0.1f;
	// public float patrolSpeed = 2f;                          // The nav mesh agent's speed when patrolling.
	public float walkSpeed = 0.33f;
	public float trotSpeed = 0.75f;
    public float runSpeed = 1.1f;
	//public float goalSmoothing = .5f;
	//public float minMoveVel = .1f;
	//public float chaseSpeed = 5f;                           // The nav mesh agent's speed when chasing.
	//public float chaseWaitTime = 5f;                        // The amount of time to wait when the last sighting is reached.
	// public float patrolWaitTime = 1f;                       // The amount of time to wait when the patrol way point is reached.
	public Transform[] patrolWayPoints;                     // An array of transforms for the patrol route.
	public float[] patrolSpeed;
	public float[] patrolWaitTime;
		
	//private EnemySight enemySight;                          // Reference to the EnemySight script.
	// private NavMeshAgent nav;                               // Reference to the nav mesh agent.
		//private Transform player;                               // Reference to the player's transform.
		//private PlayerHealth playerHealth;                      // Reference to the PlayerHealth script.
		//private LastPlayerSighting lastPlayerSighting;          // Reference to the last global sighting of the player.
		//private float chaseTimer;                               // A timer for the chaseWaitTime.
	private float patrolTimer;                              // A timer for the patrolWaitTime.
	private int wayPointIndex;    



    bool shouldMove;


    void Start ()
    {
        anim = GetComponent<Animator> ();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent> ();
        // Don’t update position automatically
        agent.updatePosition = false;
        // agent.updatePosition = true;

		// player = GameObject.FindGameObjectWithTag ("Goal").transform;
        //playerHealth = player.GetComponent <PlayerHealth> ();
        // enemyHealth = GetComponent <EnemyHealth> ();
        // nav = GetComponent <NavMeshAgent> ();
		agent.destination = patrolWayPoints[wayPointIndex].position;
		if ( patrolSpeed[wayPointIndex] > 0.0f)
			agent.speed = patrolSpeed[wayPointIndex];

    }

    void Update ()
    {

    	// float walkSpeed = 0.5f;
    	// float trotSpeed = 1.0f;
    	// float runSpeed = 1.5f;
    	//float minMoveVel = .1f;
    	// bool shouldMove;
    	float oldVelX2 = 0.0f;
    	float oldVelY2 = 0.0f;
    	float oldVelZ2 = 0.0f;
    	float oldVelX = 0.0f;
    	float oldVelY = 0.0f;
    	float oldVelZ = 0.0f;

    	float distance = 0.0f;
    	Vector3 offset;

		// agent.SetDestination (player.position);

        Vector3 worldDeltaPosition = agent.nextPosition - transform.position;

        // Map 'worldDeltaPosition' to local space
        //float dx = Vector3.Dot (transform.right, worldDeltaPosition);
        //float dy = Vector3.Dot (transform.forward, worldDeltaPosition);
        //Vector2 deltaPosition = new Vector2 (dx, dy);



        // Low-pass filter the deltaMove
        //float updateSpeed = 1.0f;
        float updateSpeed = 1.0f;

        float smooth = Mathf.Min(1.0f, Time.deltaTime/updateSpeed);

        // smoothDeltaPosition = Vector2.Lerp (smoothDeltaPosition, deltaPosition, smooth);

		// smoothDeltaPosition = Vector3.Lerp (new Vector3( 0.0f, 0.0f, 0.0f), worldDeltaPosition, smooth);
		// smoothDeltaPosition = Vector3.Lerp ( smoothDeltaPosition, worldDeltaPosition, smooth);

		smoothDeltaPosition = worldDeltaPosition;

		// smoothDeltaPosition = deltaPosition;
		// smoothDeltaPosition = Vector2.Lerp ( new Vector2( 0.0f, 0.0f), deltaPosition, goalSmoothing );

        // Update velocity if time advances
        if (Time.deltaTime > 1e-5f)
            velocity = smoothDeltaPosition / Time.deltaTime;

         //Debug.Log("velocity.y = ");
         //Debug.Log( velocity.y );

        //bool shouldMove = velocity.magnitude > minMoveVel && agent.remainingDistance > agent.radius;
        //shouldMove = velocity.y > minMoveVel;

        // Update animation parameters
        //anim.SetBool("move", shouldMove);

        // bracket the speed so we get better animation playback
        //if (false)
        //{
        // average speeds for consistency
		//velx = ( velocity.x + oldVelX + oldVelX2)/3.0f;
        //vely = ( velocity.y + oldVelY + oldVelY2)/3.0f;
		//velz = ( velocity.z + oldVelZ + oldVelZ2)/3.0f;

		velx = velocity.x;
		vely = velocity.y;
		velz = velocity.z;

		offset = new Vector3( velx, vely, velz);

		distance = offset.magnitude;

		//Debug.Log("vely = ");
        Debug.Log( distance );

        if ( distance > runSpeed )
        	{
        	//vely = runSpeed;
			anim.SetBool ("stop", false);
			anim.SetBool ("walk", false);
			anim.SetBool ("trot", false);
			anim.SetBool ("run", true);
        	}
        else if ( distance > trotSpeed )
        	{
        	// vely = trotSpeed;
			anim.SetBool ("stop", false);
			anim.SetBool ("walk", false);
			anim.SetBool ("trot", true);
			anim.SetBool ("run", false);
        	}
        else if ( distance > walkSpeed )
        	{
        	// vely = walkSpeed;
			anim.SetBool ("stop", false);
			anim.SetBool ("walk", true);
			anim.SetBool ("trot", false);
			anim.SetBool ("run", false);
        	}
        else
			{
        	// vely = stop;
			anim.SetBool ("stop", true);
			anim.SetBool ("walk", false);
			anim.SetBool ("trot", false);
			anim.SetBool ("run", false);
        	}

        	//oldVelY2 = oldVelY;
        	//oldVelX2 = oldVelX;
        	//oldVelZ2 = oldVelZ;
        	//oldVelX = velocity.x;
        	//oldVelY = velocity.y;
			//oldVelZ = velocity.z;

        //	}


		//anim.SetFloat ("velx", velx);
        //anim.SetFloat ("vely", vely);

		//anim.SetFloat ("velx", velocity.x);
        //anim.SetFloat ("vely", velocity.y);

		//anim.SetFloat ("velx", smoothDeltaPosition.x);
        //anim.SetFloat ("vely", smoothDeltaPosition.y);



        // GetComponent<LookAt>().lookAtTargetPosition = agent.steeringTarget + transform.forward;

        Patrolling();
    }



	//void FixedUpdate ()
	//	{
			// If the player is in sight and is alive...
			//if(enemySight.playerInSight && playerHealth.health > 0f)
				// ... shoot.
				//Shooting();
			
			// If the player has been sighted and isn't dead...
			//else if(enemySight.personalLastSighting != lastPlayerSighting.resetPosition && playerHealth.health > 0f)
				// ... chase.
			//	Chasing();
			
			// Otherwise...
			//else
				// ... patrol.
		//		Patrolling();
		//}


    void OnAnimatorMove ()
    {
     // Update position to agent position
     //if (shouldMove )
     //  	{

       transform.position = agent.nextPosition;
		// transform.position = smoothDeltaPosition;

      


		// transform.position = Vector2.Lerp ( transform.position, agent.nextPosition, goalSmoothing );
     //  	}
	
    }

	void Patrolling ()
		{
			// Set an appropriate speed for the NavMeshAgent.
			// nav.speed = patrolSpeed;

			
			// If near the next waypoint or there is no destination...
			// if( nav.remainingDistance < nav.stoppingDistance)
			if( agent.remainingDistance < waypointArrivedDistance )
				{
				// agent.speed = walkSpeed;
				// shouldMove = false;
				// ... increment the timer.
				patrolTimer += Time.deltaTime;

				// If the timer exceeds the wait time...
				if(patrolTimer >= patrolWaitTime[wayPointIndex])
					{
					// ... increment the wayPointIndex.
					if(wayPointIndex == patrolWayPoints.Length - 1)
						wayPointIndex = 0;
					else
						wayPointIndex++;

					agent.destination = patrolWayPoints[wayPointIndex].position;
					if ( patrolSpeed[wayPointIndex] > 0.0f)
						agent.speed = patrolSpeed[wayPointIndex];
					
					// Reset the timer.
					patrolTimer = 0;
					}
				}
			else
				{
				// If not near a destination, reset the timer.
				patrolTimer = 0;
				}
			
			// Set the destination to the patrolWayPoint.
		// agent.destination = patrolWayPoints[wayPointIndex].position;
		// agent.SetDestination (patrolWayPoints[wayPointIndex].position);
		}
}