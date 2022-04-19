using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using UXF;

public class PlayerController : MonoBehaviour
{
    public Session session;

    public TrialTimer TrialTimer;

    private bool repeatTrial;
    public float speed = 0;

    private Rigidbody rb;

    private float movementX;
    private float movementY;


    int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();

        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        Vector3 obj_pos = other.transform.position;

        if(other.CompareTag("Collectable"))
        {
            Debug.Log("Collision :: " + other.name + " " + obj_pos);
        }
        
        
        
        if(other.gameObject.CompareTag("Collectable"))
        {
            other.gameObject.GetComponent<Renderer>().material.color = Color.cyan;
    
        }

        if(other.name == "Start_Bar" & !session.InTrial)
        {
            session.BeginNextTrial();
            counter ++;
            Debug.Log("Trial " + counter + " Started");

            // start the Trial Timer
            TrialTimer.StartTrialTimer();
        }


        if(other.name == "End_Bar" & session.InTrial)
        {
            session.EndCurrentTrial();
            
            TrialTimer.EndTrialTimer();

            Debug.Log("Trial " + counter + " Ended");
        }

    }

}