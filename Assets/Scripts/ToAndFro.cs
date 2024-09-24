using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToAndFro : MonoBehaviour
{
    [SerializeField] GameObject Base;
    [SerializeField] GameObject Target;
    [SerializeField] Arrow arrow;

    Vector3 velocity = new Vector3(0, -2, 0);
    float speed = 2;
    float distance = 0;
    float tmax ,t;

    private void Start()
    {
        arrow.transform.position = Base.transform.position;
        velocity = Target.transform.position - Base.transform.position;
        distance = velocity.magnitude;
        tmax = distance/speed;
        velocity = velocity.normalized;
        t = 0;
    }

    void Update()
    {
        if (t <= tmax)
        {
            arrow.myVector = velocity * speed;
            arrow.transform.position += velocity * speed * Time.deltaTime;
            t += Time.deltaTime;
        }

    }
}
