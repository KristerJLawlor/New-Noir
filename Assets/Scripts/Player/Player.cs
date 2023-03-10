using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody myRig;
    //public Animator playerAnimator;
    //public AudioSource audioSrc;
    public int playerHP = 100;
    public int playerMaxHP;
    public int power = 50;
    public int lives = 10;
    public float speed = 2f;
    public float maxSpeed = 2f;
    public float acceleration = 1.01f;
    public bool collideSide = false;
    public bool collideUnder = false;
    public Vector3 Velocity;
    public Vector3 LastVel;
    public Vector3 LastInput;
    public Camera cam;
    public bool lastFire=false;
    public bool canShoot=true;
    public GameObject bulletPrefab;
    public int ammoCount = 6;
    public AmmoCan counter;
    public UIScripting UISCRIPT;


    // Start is called before the first frame update
    void Start()
    {
        //playerAnimator = GetComponent<Animator>();
        myRig = GetComponent<Rigidbody>();
        if (myRig == null)
        {
            throw new System.Exception("Player has no rigidbody");
        }
        
        //audioSrc = GetComponent<AudioSource>();
        cam = GameObject.FindGameObjectWithTag("GameCam").GetComponent<Camera>();
    }
    public IEnumerator ROF()
    {
        yield return new WaitForSeconds(.1f);
        canShoot = true;
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 newVel = (LastInput) * speed;
        LastVel = Vector3.zero;
        Vector3 velDif = newVel - LastVel;
        myRig.velocity = new Vector3(LastInput.x, 0, LastInput.y) * speed + new Vector3(0, myRig.velocity.y, 0);

        LastVel += ((velDif.normalized * acceleration)) * Time.deltaTime;
        LastVel = newVel;


        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            transform.LookAt(hit.point); // Look at the point
            transform.rotation = Quaternion.Euler(new Vector3(0, transform.rotation.eulerAngles.y, 0));
        }
        if (ammoCount > 0)
        {
            if (lastFire && canShoot)
            {
                GameObject temp = GameObject.Instantiate(bulletPrefab, myRig.position + this.transform.forward * .9f + this.transform.up, this.transform.rotation);
                temp.GetComponent<Rigidbody>().velocity = this.transform.forward *8;
                ammoCount--;
                lastFire= false;
                canShoot = false;
                //enemycounter.KillEnemy();
                StartCoroutine(ROF());
            }
        }
        else
        {
            canShoot=false;
            StartCoroutine(Reloading());
        }
        counter.UpdateBullet(ammoCount);
        UISCRIPT.changeLives(lives);
        if(lives<=0)
        {
            SceneManager.LoadScene(3);
        }
    }

    public void Movement(InputAction.CallbackContext c)
    {
        if (c.phase == InputActionPhase.Started || c.phase == InputActionPhase.Performed)
        {
            Vector2 temp = c.ReadValue<Vector2>();
            LastInput = new Vector3(temp.x, 0, temp.y);
        }
        if (c.phase == InputActionPhase.Canceled)
        {
            LastInput = Vector3.zero;

        }
    }
    public void Shoot(InputAction.CallbackContext s)
    {
        if (ammoCount > 0)
        {
            if (s.phase == InputActionPhase.Started)
            {
                lastFire = true;
                

            }
            else if (s.phase == InputActionPhase.Canceled)
            {
                lastFire = false;
            }
        }
        else
        {
            lastFire = false;
        }
    }
    public void Reload(InputAction.CallbackContext r)
    { 
        canShoot= false;
        StartCoroutine(Reloading());
    }
    public IEnumerator Reloading()
    {
        yield return new WaitForSeconds(1);
        ammoCount = 6;
        canShoot= true;

    }

    public void Death()
    {
        if(this.playerHP <= 0)
        {
            lives--;
            if(lives <= 0)
            {
                SceneManager.LoadScene(3);
            }
        }
    }

    public void OnCollisionEnter(Collision c)
    {
        if(c.gameObject.tag == "Goal")
        {
            SceneManager.LoadScene(4);
        }
        if (c.gameObject.tag == "Enemy")
        {
            lives--;
        }
    }
}
