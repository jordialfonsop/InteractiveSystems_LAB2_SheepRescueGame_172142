using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmilRotate : MonoBehaviour
{
    public Vector3 rotationspeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationspeed * Time.deltaTime);
    }
}
