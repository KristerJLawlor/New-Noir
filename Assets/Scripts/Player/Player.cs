using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody myRig;
    public Animator playerAnimator;
    public int playerHP;
    public int playerMaxHP;
    public int power;
    public float speed;
    public float fireRate;
    public bool canShoot = false;
    public bool collideSide = false;
    public bool collideUnder = false;
    public Vector3 Velocity;
    public Vector3 LastVel;
    public Vector3 LastInput;


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

    public IEnumerator WaitForShoot()
    {
        //yield return new WaitForSecondsRealtime(.5f);
        //animation between shots
        //playerAnimator.SetInteger("State", 0);
        //canShoot = true;
    }

    public void Shooter(InputAction.CallbackContext shoot)
    {
        if (shoot.phase == InputActionPhase.Started && canShoot)
        {
            canShoot = false;
            //set animation state
                //playerAnimator.Set" "("", #);
            //any audio trigger
                //source.clip = exampleSound
                //source.Play();
        }
        else if ()
        {
            StartCoroutine(WaitForShoot());
        }
    }

    public void Movement(InputAction.CallbackContext move)
    {
        if(move.phase == InputActionPhase.Started || move.phase == InputActionPhase.Performed)
        {
            Vector2 temp = move.ReadValue<Vector2>();
            LastInput = new Vector3(temp.x, 0, temp.y);
            speed = 5.0f;
        }
        if(move.phase == InputActionPhase.Canceled)
        {
            LastInput = Vector3.zero;
            speed = 1.0f;
        }
    }

    public void Death()
    {
        GameObject.Destroy(this.gameObject);
    }
}
