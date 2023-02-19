using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerAnimation : MonoBehaviour
{
    public Animator myAnimate;
    public Rigidbody myRig;

    public float Speed = 2f;
    public float MaxSpeed = 2f;
    public float Acceleration = 1.01f;
    public float AttackTimer = 1.5f;

    public bool LastAttack = false;

    public Vector3 LastInput;


    // Start is called before the first frame update
    void Start()
    {
        //Use myAnimate to set the DIR variable to change animation of player
        myAnimate = this.GetComponent<Animator>();

        //Get rigidbody
        myRig = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Mover(InputAction.CallbackContext c)
    {
        if (c.phase == InputActionPhase.Started || c.phase == InputActionPhase.Performed)
        {
            myAnimate.SetInteger("DIR", 1);
        }
        if (c.phase == InputActionPhase.Canceled)
        {
            LastInput = Vector3.zero;
            myAnimate.SetInteger("DIR", 0);
        }
        

    }

    public void Attacker(InputAction.CallbackContext j)
    {
        if (j.phase == InputActionPhase.Started) //if key is pressed
        {
            LastAttack = true;
            myAnimate.SetInteger("DIR", 2);
            Debug.Log("Made it to Attack");
            
        }
        else if (j.phase == InputActionPhase.Canceled) //if key is released
        {
            StartCoroutine(Timeout());
            LastAttack = false;
            Debug.Log("Attack let go");
            
        }

    }


    public IEnumerator Timeout()
    {   
        yield return new WaitForSeconds(AttackTimer);
        myAnimate.SetInteger("DIR", 0);
    }
}