using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class TempPlayerController : MonoBehaviour
{
    public Rigidbody myRig;

    public float Speed = 2f;
    public float MaxSpeed = 2f;
    public float Acceleration = 1.01f;
    public float AttackTimer = 1.5f;

    public bool LastAttack = false;
    public Vector3 LastInput;

    Quaternion PlayerRotation;

    // Start is called before the first frame update
    void Start()
    {
        //Get rigidbody
        myRig = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newVel = LastInput * Speed;
        Vector3 oldVel = new Vector3(myRig.velocity.x, 0, myRig.velocity.z);


        //Correct Way
        Vector3 velDif = newVel - oldVel;

        // stop char if the current vector value is close to 0,0,0 but not actually 0. Remove vector value noise and prevent jitter
        if (newVel.magnitude < .1f && oldVel.magnitude < .1f)
        {
            myRig.velocity = Vector3.zero + new Vector3(0, myRig.velocity.y, 0);
        }

        else
        {
            myRig.velocity += velDif.normalized * Acceleration * Time.deltaTime; //deltaTime makes the acceleration increase proportional to the update()'s fps

            if (new Vector3(myRig.velocity.x, 0, myRig.velocity.z).magnitude > MaxSpeed)
            {
                myRig.velocity = new Vector3(myRig.velocity.x, 0, myRig.velocity.z).normalized * MaxSpeed
                    + new Vector3(0, myRig.velocity.y, 0);
            }
        }

        if (newVel == Vector3.zero)
        {
            //do absolute jack shiz we arent looking to change look direction if the velocity is 0

            myRig.angularVelocity = Vector3.zero;
        }
        else
        {
            PlayerRotation = Quaternion.LookRotation(myRig.velocity);
            myRig.MoveRotation(PlayerRotation);
            PlayerRotation = Quaternion.RotateTowards(transform.rotation, PlayerRotation, 360 * Time.deltaTime);
        }

    }


    public void Mover(InputAction.CallbackContext c)
    {
        if (c.phase == InputActionPhase.Started || c.phase == InputActionPhase.Performed)
        {
            //Get the values from the peripheral/keyboard/gamepad
            Vector2 temp = c.ReadValue<Vector2>();

            LastInput = new Vector3(temp.x, 0, temp.y);

        }
        if (c.phase == InputActionPhase.Canceled)
        {
            LastInput = Vector3.zero;

        }


    }

    public void Attacker(InputAction.CallbackContext j)
    {
        if (j.phase == InputActionPhase.Started) //if key is pressed
        {
            LastAttack = true;
            
            Debug.Log("Made it to Attack");

        }
        else if (j.phase == InputActionPhase.Canceled) //if key is released
        {
            LastAttack = false;
            Debug.Log("Attack let go");
        }

    }

    public void Death()
    {
        GameObject.Destroy(this.gameObject);

    }

    public IEnumerator Timeout()
    {
        yield return new WaitForSeconds(AttackTimer);
    }
}