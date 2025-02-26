using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestABC : MonoBehaviour
{

    QuadraticFunction f = new QuadraticFunction(2, -3, -5);
    // Start is called before the first frame update
    void Start()
    {
        print(f.findZero());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
