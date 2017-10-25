using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrive : AgentBehavior {

    public float targetRadius;
    public float slowRadius;
    public float timeToTarget = 0.1f;



    public override Steering GetSteering()
    {
        Steering steering = new Steering();
        Vector3 direction = target.transform.position - transform.position;
        float distance = direction.magnitude;
        float targetSpeed;

        if(distance <targetRadius)
        {
            return steering;
        }
        if(distance >slowRadius)
        {
            targetSpeed = agent.maxSpeed;

        }
        else
        {
            targetSpeed = agent.maxSpeed * distance / slowRadius;
        }

        // ---------------desiredVelocity-------------------//

        Vector3 desiredVelocity = direction;
        desiredVelocity.Normalize();
        desiredVelocity *= targetSpeed;
        steering.linerar = desiredVelocity - agent.velocity;
        steering.linerar /= timeToTarget;

        if(steering.linerar.magnitude>agent.maxSpeed)
        {
            steering.linerar.Normalize();
            steering.linerar *= agent.maxSpeed;
        }

        return steering;

    }



}
