using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereBehavior : MonoBehaviour
{
    public float force = 10000;
    public Rigidbody rb;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            if (Vector3.Distance(transform.position, other.transform.position) > 10)
            {
                transform.LookAt(other.transform);
                rb.AddRelativeForce(Vector3.forward * force);
            }
        }
    }
}
