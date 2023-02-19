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

            }
            SceneManager.LoadScene(3);
        }
    }

    public void OnCollisionEnter(Collision c)
    {

    }
}
