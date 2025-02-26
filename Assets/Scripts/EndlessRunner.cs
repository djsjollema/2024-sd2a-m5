using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRunner : MonoBehaviour
{
    [SerializeField] GameObject jumper;
    Animator animator;

    enum State { grounded, airborne};
    State myState = State.grounded;

    //float time = 0;

    Vector3 velocity = Vector3.zero;
    Vector3 gravity = Vector3.zero;

    float y0;

    void Start()
    {
        animator = GetComponent<Animator>();
        y0 = jumper.transform.position.y;
    }

    void Update()
    {
        if(myState == State.grounded)
        {
            if(Input.GetMouseButtonUp(0))
            {
                animator.Play("jump");
                velocity = new Vector3(0, 5, 0);
                gravity = new Vector3 (0, -10, 0);
                myState = State.airborne;
            }
            
        }
        
        if(myState == State.airborne)
        {
            velocity += gravity * Time.deltaTime;
            jumper.transform.position += velocity * Time.deltaTime;
            if(jumper.transform.position.y < y0)
            {
                velocity = Vector3.zero;
                gravity = Vector3.zero;
                animator.Play("Run");
                jumper.transform.position = new Vector3(jumper.transform.position.x, y0, 0);
                myState = State.grounded;
            }
        }
    }
}
