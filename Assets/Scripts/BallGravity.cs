using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGravity : MonoBehaviour
{

    Rigidbody ballRigidBody;

    [Range(-100,100)]
    public float gravity = 0;

    // Start is called before the first frame update
    void Start()
    {
        // get the RB from the ball
        ballRigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ballRigidBody.AddForce(Vector3.down * gravity);
    }
}
