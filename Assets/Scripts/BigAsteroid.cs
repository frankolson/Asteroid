using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigAsteroid : Asteroid
{
    Rigidbody playerRigidBody;

    void Start()
    {
        playerRigidBody = gameObject.GetComponent<Rigidbody>();
        IncreaseMass();
    }

    void IncreaseMass()
    {
        playerRigidBody.mass *= 2;
    }
}
