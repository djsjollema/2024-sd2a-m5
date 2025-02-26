using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testAsyn : MonoBehaviour
{
    [SerializeField] float v0 = 5;
    [SerializeField] float g = 10;

    Animator animator;

    enum States { wait, jump, finished};
    States myState = States.wait;
    Vector3 startPos;
    Vector3 velocity = Vector3.zero;
    Vector3 acceleration = Vector3.zero;



    float t = 0;
    float tmax;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(myState == States.wait)
        {
            animator.speed = 0;

            if (Input.GetMouseButtonUp(0))
            {
                tmax = 2 * v0 / g;
                myState = States.jump;
                t = 0;
                velocity = new Vector3(0, v0, 0); ;
                acceleration = new Vector3(0, -g, 0);
                animator.speed = 0.750f/tmax;
            }

        }

        if(myState == States.jump)
        {
            velocity += acceleration * Time.deltaTime;
            transform.position += velocity * Time.deltaTime;
            t += Time.deltaTime;
            if (t > tmax)
            {
                velocity = Vector3.zero;
                acceleration = Vector3.zero;

                myState = States.finished;
                animator.speed = 0;
            }
        }

        if(myState  == States.finished)
        {
            this.transform.position = startPos;
            myState = States.wait;
        }
        
    }
}
