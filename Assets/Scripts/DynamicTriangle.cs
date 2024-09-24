using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicTriangle : MonoBehaviour
{
    [SerializeField] Transform A;
    [SerializeField] Transform B;
    [SerializeField] Transform C;

    [SerializeField] LineRenderer AB;


    void Update()
    {
        AB.SetPosition(0, A.position);
        AB.SetPosition(1, B.position);
        
    }
}
