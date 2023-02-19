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
    public int lives = 3;
    public float speed = 2f;
    public float maxSpeed = 2f;
    public float acceleration = 1.01f;
    public bool collideSide = false;
    public bool collideUnder = false;
    public Vector3 Velocity;
    public Vector3 LastVel;
    public Vector3 LastInput;
    public Camera cam;


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
        cam = GameObject.FindGameObjectWithTag("GameCam").GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newVel = LastInput * speed;
        Vector3 oldVel = new Vector3(myRig.velocity.x, 0, myRig.velocity.z);
        Vector3 velDif = newVel - oldVel;

        if (newVel.magnitude < .1f && oldVel.magnitude < .1f)
        {
            myRig.velocity = Vector3.zero + new Vector3(0, myRig.velocity.y, 0);
        }
        else
        {
            myRig.velocity += velDif.normalized * acceleration * Time.deltaTime; 

            if (new Vector3(myRig.velocity.x, 0, myRig.velocity.z).magnitude > maxSpeed)
            {
                myRig.velocity = new Vector3(myRig.velocity.x, 0, myRig.velocity.z).normalized * maxSpeed
                    + new Vector3(0, myRig.velocity.y, 0);
            }
        }

        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            transform.LookAt(hit.point); // Look at the point
            transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));
        }
    }

    public void Movement(InputAction.CallbackContext move)
    {
        if (move.phase == InputActionPhase.Started || move.phase == InputActionPhase.Performed)
        {
            Vector2 temp = move.ReadValue<Vector2>();
            LastInput = new Vector3(temp.x, 0, temp.y);
        }
        if (move.phase == InputActionPhase.Canceled)
        {
            LastInput = Vector3.zero;
        }
    }

    public void Death()
    {
        if(this.playerHP <= 0)
        {
            Destroy(this.gameObject);
            lives--;
            if(lives <= 0)
            {
                SceneManager.LoadScene(3);
            }
        }
    }

    public void OnCollisionEnter(Collision c)
    {

    }
}
