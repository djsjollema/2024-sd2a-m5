using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AsymJump : MonoBehaviour
{
    [SerializeField] float vb = 5;
    [SerializeField] float g = 10;

    enum States { wait, jump, finished};
    States myState = States.wait;
    Animator animator;

    Vector3 velocity = Vector3.zero;
    Vector3 acceleration = Vector3.zero;

    float t;
    float tmax;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(myState == States.wait) 
        {
            animator.speed = 0;
            if(Input.GetMouseButtonUp(0))
            {
                velocity = new Vector3(1, vb, 0);
                acceleration = new Vector3(0, -g, 0);
                
                myState = States.jump;
                t = 0;
                tmax = 2 * vb / g;
                animator.speed = 0.667f/tmax;
            }
        }

        if(myState == States.jump)
        {
            t += Time.deltaTime;
            velocity += acceleration * Time.deltaTime;
            transform.position += velocity * Time.deltaTime;
            if(t> tmax)
            {
                velocity = Vector3.zero;
                acceleration = Vector3.zero;
                myState = States.finished;
            }
        };

        if(myState == States.finished)
        {
            myState = States.wait;

        }
        
    }
}
