using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody myRig;
    public Animator playerAnimator;
    public AudioSource audioSrc;
    public int playerHP = 100;
    public int playerMaxHP;
    public int power = 50;
    public bool collideSide = false;
    public bool collideUnder = false;
    public Vector3 Velocity;
    public Vector3 LastVel;


    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
        myRig = GetComponent<Rigidbody>();
        if (myRig == null)
        {
            throw new System.Exception("Player has no rigidbody");
        }
        audioSrc = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Death()
    {
        GameObject.Destroy(this.gameObject);
    }

    public void OnCollisionEnter(collision c)
    {

    }
}
