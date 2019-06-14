using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    

    // destinations / targets
    public Transform[] targets;

    // next destination index
    int nextDest = 0;

    // platform speed
    public float speed = 1;

    // flag that sets whether we are moving or not
    bool isMoving = false;

    // ****************************************************
    // Start is called before the first frame update
    void Start()
    {
        // set initial position to first target
        transform.position = targets[nextDest].position;

        // next destination is 1
        incrementDest();
    }

    // Update is called once per frame
    void Update()
    {
        // check input
        HandleInput(); 

        // move platform
        HandleMovement();
    }

    void HandleInput()
    {
        // detect if the fire1 input axis has been acivated
        if (Input.GetButtonDown("Fire1"))
        {
            // if so swap the value of isMoving
            isMoving = !isMoving;
        }
    }

    // take care of movement 
    void HandleMovement()
    {
        //  move only if isMovinng is true
        if (isMoving == false) return;
        
        // calc the distance from targe
        float distance = Vector3.Distance(transform.position, targets[nextDest].position);

        // have we arrived?
        if (distance > 0)
        {
        // calc how much we need to move (step) d = v * t
        float step = speed * Time.deltaTime;

        // move by that step
        transform.position = Vector3.MoveTowards(transform.position, targets[nextDest].position, step);
        }
        // if we have arrive update nextIndex
        else
        {
            // check if last destination
            incrementDest();

            // stop moving
            isMoving = false;
        }
    }

    // check if last destination is reached
    // loop back to 0
    void incrementDest()
    {
        if (nextDest == targets.Length-1) nextDest = 0;
        else nextDest++;
    }
}
