using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Jump : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI myText;
    [SerializeField] GameObject Anton;

    Vector3 velocity;
    Vector3 acceleration;

    float t; 
    float timer;
    float t0 = 0f;
    enum State  { wait,active,finished };
    State myState = State.wait;
    float y0;


    void Start()
    {
        myText.text = t0.ToString();
        t = t0;
        y0 = Anton.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (myState == State.wait ) 
        {
            if (Input.GetMouseButtonUp(0))
            {
                velocity = new Vector3(0, 15f, 0);
                acceleration = new Vector3 (0, -40, 0);

                myState = State.active;
            }
        }

        if (myState == State.active)
        {
            velocity += acceleration * Time.deltaTime;
            Anton.transform.position += velocity * Time.deltaTime;
            t += Time.deltaTime;
            timer = t;
            myText.text = timer.ToString("F3");

            /*
            if(Input.GetMouseButtonUp (1))
            {
                myState = State.finished;
            }
            */
            if(Anton.transform.position.y < y0) {
                velocity = Vector3.zero;
                acceleration = Vector3.zero;
                myState = State.finished;
                Anton.transform.position = new Vector3(Anton.transform.position.x, y0, 0);
            }
        }

        if(myState == State.finished)
        {
            t = 0;
            myState = State.wait;
        }
        
    }
}
