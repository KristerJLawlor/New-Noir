using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BadGuy : MonoBehaviour
{
    //Navmesh Goals for Enemy
    public GameObject goalObject1;
    public GameObject goalObject2;
    public Vector3 goalLoc1;
    public Vector3 goalLoc2;

    //Get player info
    public GameObject Player;
    public Vector3 PlayerLocation;
    public Vector3 LastPlayerLocation;

    public bool isTrackingPlayer = false;
    public NavMeshAgent myNav = null;

    public Animator myAnimate;
    public AudioSource gunshot;



    // Start is called before the first frame update
    void Start()
    {
        myNav = this.gameObject.GetComponent<NavMeshAgent>();
        goalLoc1 = goalObject1.transform.position;
        goalLoc2 = goalObject2.transform.position;
        PlayerLocation = Player.transform.position;
        myNav.destination = goalLoc2;

        //Setting isStopped to false replaces .Resume()
        //myNav.isStopped = false;

        myAnimate = this.GetComponent<Animator>();
        myAnimate.SetInteger("DIR", 0);

    }

    // Update is called once per frame
    void Update()
    {
        //Get player location
        PlayerLocation = Player.transform.position;
        PlayerTracker();

        //Code block meant only for patrolling units, not stationary ones
        if (this.tag == "Patrol")
        {
            if (isTrackingPlayer == false)
            {
                //Move between the 2 goals
                if ((myNav.transform.position.x - goalLoc2.x) == 0)
                {

                    myNav.destination = goalLoc1;
                    myNav.isStopped = false;
                    myAnimate.SetInteger("DIR", 1);
                }
                if ((myNav.transform.position.x - goalLoc1.x) == 0)
                {

                    myNav.destination = goalLoc2;
                    myNav.isStopped = false;
                    myAnimate.SetInteger("DIR", 1);
                }
                if ((myNav.transform.position.x - LastPlayerLocation.x) == 0)
                {

                    myNav.destination = goalLoc2;
                    myNav.isStopped = false;
                    myAnimate.SetInteger("DIR", 1);
                }
            }


            if (isTrackingPlayer == true)
            {
                myNav.destination = PlayerLocation;
            }
        }

        //Code block meant only for the non-patrolling units
        if (this.tag == "Guard")
        {
            if (isTrackingPlayer == true)
            {
                //Set the new destination to the current players location
                myNav.destination = PlayerLocation;
                myAnimate.SetInteger("DIR", 1);
            }
            if (isTrackingPlayer == false)
            {
                //Stop unit in place
                myNav.isStopped = true;
                myAnimate.SetInteger("DIR", 0);
            }
        }

    }

        public void PlayerTracker()
    {
        if (Vector3.Distance(PlayerLocation, this.transform.position) <= 5)
        {
            isTrackingPlayer = true;
            LastPlayerLocation = PlayerLocation;
        }
        else if (Vector3.Distance(PlayerLocation, this.transform.position) > 5)
        {
            isTrackingPlayer = false;
        }
    }
}
